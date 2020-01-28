using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserLogin logInUser = (UserLogin)Session["customerObj"];

            //If the page is loaded for the first time, the items in the cart are displayed.
            if (!IsPostBack)
            {
                displayItems();
            }

            if (!(User.Identity.IsAuthenticated) || logInUser == null)
            {
                btnPurchase.Visible = false;
                lblWarning.Text = "Must login to finalize purchase";                
            }
            else if (lstName.Items.Count > 0)
            {
                btnPurchase.Visible = true;
                lblWarning.Text = "";
            }
            else
            {
                btnPurchase.Visible = false;
                lblWarning.Text = "Must have items in cart to purchase.";
            }

        }//PageLoad

        public void displayItems()
        {
            ArrayList basket;
            //Checks if the Session variable that stores the cart items is not null.
            if (Session["ShoppingBasket"] != null)
            {
                //Fills ArrayList basket with contents of the session variable.
                basket = (ArrayList)Session["ShoppingBasket"];
                int size = basket.Count;
                double totalCost = 0;
                double preDelivery = 0;
                //Goes through each item in the basket and adds them to the page so they can be displayed.
                foreach (CartItem item in basket)
                {
                    double lineCost = item.getPrice() * item.getQty();
                    preDelivery = preDelivery + lineCost;
                    totalCost = preDelivery + 2;
                    lstName.Items.Add(item.getName());
                    lstPrice.Items.Add(item.getPrice().ToString());
                    lstQuantity.Items.Add(item.getQty().ToString());
                }
                //Sets the prices to different labels.
                lblPrice.Text = preDelivery.ToString();
                lblTotal.Text = totalCost.ToString();
            }
            else
            {
                //If no items are in cart, price is set to 0.
                lblTotal.Text = "0.00";
                btnEmpty.Visible = false;
                btnRemove.Visible = false;
            }
        }//displayItems

        //Method to clear the listboxes of all data.
        private void clearListboxes()
        {
            lstName.Items.Clear();
            lstPrice.Items.Clear();
            lstQuantity.Items.Clear();
        }//clearListboxes

        //Button to empty the cart of all items.
        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            try
            {
                clearListboxes();
                ArrayList basket = (ArrayList)Session["ShoppingBasket"];
                basket.Clear();
                Session["ShoppingBasket"] = basket;
            }
            catch (Exception ex)
            {
                lblWarning.Text = "No items to clear";
            }
            Response.Redirect(Request.RawUrl);
        }//btnEmpty

        //Remove a selected item from the cart
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                //Provided that the selected index isn't nothing, the selected item will be removed from the cart.
                if (lstName.SelectedIndex != -1)
                {
                    ArrayList basket = (ArrayList)Session["ShoppingBasket"];
                    basket.RemoveAt(lstName.SelectedIndex);
                    Session["ShoppingBasket"] = basket;
                    clearListboxes();
                    displayItems();
                }//if

                if (lstName.Items.Count > 0)
                {
                    btnPurchase.Visible = false;
                }
                Response.Redirect(Request.RawUrl);

            }
            catch (Exception ex)
            {
                lblWarning.Text = "No items selected.";
            }


        }//btnRemove

        //Click method which allows the user to purchase the items in the cart.
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Create invoice
                String todayDate = DateTime.Today.ToString();
                String[] sds = ProductList.getProductNames();
                int test = 0;
                do
                {
                    lblPrice.Text += (sds[test] + " ");
                    test++;
                } while (sds[test] != null);
               

                todayDate = todayDate.Substring(0, 10);
                //Find User 
                UserLogin getuserid = (UserLogin) Session["customerObj"];
                
                Invoice inv = new Invoice(Convert.ToInt32(getuserid.getID()), todayDate, Convert.ToDouble(lblTotal.Text));
                Invoice.addInvoice(inv);
                //Remove stock
                for (int index = 0; index < lstQuantity.Items.Count; index++)
                {
                    //Compare names against product id to getting match id
                    String currentName = lstName.Items[index].ToString();
                    int id = 0;

                    for (int index2 = 0; index2 < sds.Length; index2++)
                    {
                        if (sds[index2].Equals(currentName))
                        {
                            id = Convert.ToInt32(sds[index2 + 1]);
                        }

                        if (sds[index2 + 1] == null)
                        {
                            break;
                        }
                    }
                    ProductList.changeStock(id, Convert.ToInt32(lstQuantity.Items[index].ToString()));
                }
                //Bring to order confirmation screen
                clearListboxes();
                ArrayList basket = (ArrayList)Session["ShoppingBasket"];
                basket.Clear();
                Session["ShoppingBasket"] = basket;
                Response.Redirect("OrderConfirmation.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }//Purchase

        //Click method to handle voucher discounts
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (txtVoucherInput.Text == "BUYME2020")
            {
                double discount = 0.90;
                double total = Convert.ToDouble(lblTotal.Text);
                total = total * discount;
                lblTotal.Text = total.ToString();
                lblVoucher.Text = "Voucher successfully applied";
            }
            else
            {
                lblVoucher.Text = "Invalid voucher code";
            }
        }//button1
    }//class
}//namespace