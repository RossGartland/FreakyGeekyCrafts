using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Secure
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        //Sets up string array which stores all the product names in the database
        String[] productNames = ProductList.getProductNames();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if the page is postback, then checks if the user is still logged in.
            if (IsPostBack)
            {
                if (!User.Identity.IsAuthenticated)
                {
                    //Redirects user to index page if they aren't logged in anymore.
                    Response.Redirect("..//Pages//index.aspx");
                }
            }
            //Only runs on the first time the page has opened in an instance
            else if (!(IsPostBack))
            {
                int loop = 0;
                //Loops through and fills drop down with all product names.
                while (productNames[loop] != null)
                {
                    ddlProducts.Items.Add(productNames[loop]);
                    loop = loop + 2;
                }
            }                                        
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String selectedItem = ddlProducts.SelectedValue;
                lblName.Text = selectedItem;
                Product tmpProduct = new Product();
                tmpProduct.loadProduct(getID());
                // display the data within the tmpProduct object    
                lblDescription.Text = tmpProduct.getStrProductDesc();
                imgProduct.ImageUrl = tmpProduct.getStrImageFile();

                lblPrice.Text = tmpProduct.getDblPrice().ToString();
                //Sets all page components to visible once an item has been selected.
                Panel1.Visible = true;
            }
            catch(Exception ex)
            {
                lblWarning.Text = "Error";
            }
        }

        //Submits any new details to be edited in the database for the selected product.
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Product tmpProduct = new Product();
            tmpProduct.loadProduct(getID());
            String name = tmpProduct.getStrProductName();
            double price = tmpProduct.getDblPrice();
            String description = tmpProduct.getStrProductDesc();
            //Goes through each item and checks if the textbox has anything entered into it. If it does, the entered data is saved to a variable.
            if (txtName.Text != "")
            {
                name = txtName.Text;
            }

            if (txtPrice.Text != "")
            {
                price = Convert.ToDouble(txtPrice.Text);
            }

            if (txtDescription.Text != "")
            {
                description = txtDescription.Text;
            }
            //Updates the product with any altered data
            Product.updateProduct(getID(), name, price, description);

            Response.Redirect("..//Pages//ProductView.aspx");      
        }

        //Clears all the textboxes.
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        //Uploads the new image.
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            strFolder = Server.MapPath("../Images/Products");
            // Retrieve the name of the file that is posted.            
            strFileName = filProductImage.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (strFileName != "")
            {
                // Create the folder if it does not exist.
                if (!Directory.Exists(strFolder))
                {
                    Directory.CreateDirectory(strFolder);
                }
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;

                //Prevents duplicate images from being uploaded, at least with the same name.
                if (File.Exists(strFilePath))
                {
                    lblWarning.Text = strFileName + " already exists on the server!";
                }
                else
                {
                    filProductImage.PostedFile.SaveAs(strFilePath);
                    //Update image link in database
                    String databasePath = "../Images/Products" + filProductImage.PostedFile.FileName;
                    Product.updateImage(databasePath, getID());
                    // Display the result of the upload.
                    lblWarning.Text = "Upload successful";
                    imgProduct.ImageUrl = databasePath;
                }
            }
            else
            {
                lblWarning.Text = "Error.";
            }           
        }

        protected void btnRestock_Click1(object sender, EventArgs e)
        {
            try
            {
                //Call query
                Product.restock(getID());
                //Success message
                lblWarning.Text = "Restock successful";
            }
            catch(Exception)
            {
                lblWarning.Text = "Restock unsuccessful";
            }
        }

        //Method to find the ID of the selected item.
        public int getID()
        {
            int id;
            int test = Array.IndexOf(productNames, ddlProducts.SelectedValue);          
            String selectedID = productNames[test + 1];
            id = Convert.ToInt32(selectedID);
            return id;
        }

        //Button to delete the selected product from the database.
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Check a product is selected
            if (ddlProducts.SelectedItem != null)
            {
                //Double check delete
                if (chkDelete.Checked == true)
                {
                    //Delete product
                    Product.deleteProduct(getID());
                    //Confirmation message
                    lblWarning.Text = "Product deleted";
                    //Update page to reflect deletion
                    Response.Redirect("..//Pages//ProductView.aspx");
                }
                else
                {
                    Label5.Text = "Must click textbox to confirm deletion";
                }
            }
        }

        public void clear()
        {
            txtDescription.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            imgProduct.ImageUrl = "";
            lblWarning.Text = "";
        }
    }
}