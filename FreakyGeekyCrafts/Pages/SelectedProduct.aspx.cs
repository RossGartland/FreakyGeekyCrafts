using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class SelectedProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Redirects the user if they get to the page with no product selected
            if (Session["SelectedProductID"] == null)
            {
                Response.Redirect("Products.aspx");
            }
            Product tmpProduct = new Product();
            tmpProduct.loadProduct(Convert.ToInt32(Session["SelectedProductID"]));
            if (!IsPostBack)
            {
                    // display the data within the tmpProduct object    
                    lblTitle.Text = tmpProduct.getStrProductName();
                    lblDescription.Text = tmpProduct.getStrProductDesc();
                    imgProduct.ImageUrl = tmpProduct.getStrImageFile();
                    lblPrice.Text =tmpProduct.getDblPrice().ToString("##.00");
                    ddlStock.Items.Clear();
                    lblTotalPrice.Text = "£" + lblPrice.Text;

                   
                    //using the inStock value to populate the drop down list 

                    //Populates stock drop down with all values up to the maximum available stock.
                    if (tmpProduct.getIntStock() > 0)
                    {
                        for (int index = 1; index <= tmpProduct.getIntStock(); index++)
                        {
                            ddlStock.Items.Add(index.ToString());
                        }//for
                    }//if
                    else
                    {
                        ddlStock.Items.Add("0");
                        btnAdd.Visible = false;
                        ddlStock.Visible = false;
                        lblWarning.Text = "0 items in stock. Stock resupply required.";
                    }//else
            }//if
            //Loads all reviews for the selected product
            getReviews(tmpProduct.getStrProductID().ToString());


            if (tmpProduct.getIntStock() > 0)
            {
                btnAdd.Visible = true;
                ddlStock.Visible = true;
                Label4.Visible = true;
                lblTotalPrice.Visible = true;
            }



        }//Page_Load

        protected void btnAdd_Click(object sender, EventArgs e)
        {
                ArrayList basket;
                CartItem item = new CartItem(Convert.ToInt32(Session["SelectedProductID"]), lblTitle.Text, Convert.ToDouble(lblPrice.Text), Convert.ToInt32(ddlStock.SelectedValue.ToString()));
                if (Session["ShoppingBasket"] != null)
                {
                    basket = (ArrayList)Session["ShoppingBasket"];
                }//if
                else
                {
                    basket = new ArrayList();
                }//else
                basket.Add(item);
                //create ShoppingBasket session variable
                Session["ShoppingBasket"] = basket;
                Response.Redirect("ProductView.aspx");
        }//btnAdd_Click


        //Whenever stock value is changed, the total price is changed.
        protected void ddlStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(lblPrice.Text.ToString());
            int stock = Convert.ToInt32(ddlStock.SelectedItem.ToString());
            double currentPrice = (price * stock);
            lblTotalPrice.Text = "£" + currentPrice.ToString();
        }//ddlStockIndexChanged

        //Adds a newly entered review by the user.
        protected void btnReview_Click(object sender, EventArgs e)
        {
            String review = "";
            //Saves entered review to string
            if (TextBox1.Text != "")
            {
                 review = TextBox1.Text;
            }
            else
            {
                lblReviewWarning.Text = "Can't submit review without text in textbox";
                return;
            }
            //Gets the user name
            String name;
            UserLogin customer = (UserLogin)Session["customerObj"];
            if (customer != null)
            {
                name = customer.getFullName();              
            }
            else
            {
                name = "Anonymous";
            }
            String date = DateTime.Now.ToShortDateString();

            //Adds the review to the database
            Reviews.addReview(Session["SelectedProductID"].ToString(), name, review, date);
            TextBox1.Text = "";
            Response.Redirect(Request.RawUrl);
        }//btnReview_Click

        //Retrieves all existing reviews for the selected product
        public void getReviews(String productID)
        {
            try
            {
                String[] allReviews = Reviews.returnReviews(productID);
                if (allReviews[0] != null)
                {
                    for (int index = 0; index < allReviews.Length; index++)
                    {
                        ArrayList reviews = new ArrayList();
                        reviews.Add("Review");
                        StringBuilder sb = new StringBuilder();
                        Label feedback = new Label();
                        int pFrom = allReviews[index].IndexOf("?") + 1;
                        int pTo = allReviews[index].LastIndexOf("?");
                        String name = allReviews[index].Substring(pFrom, pTo - pFrom);

                        pFrom = allReviews[index].IndexOf("%") + 1;
                        pTo = allReviews[index].LastIndexOf("%");
                        String review = allReviews[index].Substring(pFrom, pTo - pFrom);

                        pFrom = allReviews[index].IndexOf("^") + 1;
                        pTo = allReviews[index].LastIndexOf("^");
                        String date = allReviews[index].Substring(pFrom, pTo - pFrom);

                        sb.Append("Name : " + name + "<br>");
                        sb.Append("Review: " + review + "<br>");
                        sb.Append("Date: " + date + "<br> <hr>");
                        feedback.Text = sb.ToString();
                        pnlReviews.Controls.Add(feedback);
                    }
                }
                else
                {
                    Label reviews = new Label();
                    StringBuilder sb = new StringBuilder();
                    sb.Append("No reviews for this product. Be the first to add one.");
                    reviews.Text = sb.ToString();
                    pnlReviews.Controls.Add(reviews);
                }
            }//try
            catch(Exception)
            {
            }//catch
        }//getReviews
    }//SelectedProduct
}//namespace
