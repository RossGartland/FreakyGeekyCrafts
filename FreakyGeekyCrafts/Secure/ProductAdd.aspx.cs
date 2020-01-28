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
    public partial class ProductAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblWarning.Text = "";
            try
            {
                if (txtStock != null && txtPrice.Text != null && txtName.Text != null && txtDesc.Text != null)
                { 
                    String proImgPath = imageHandling();
                    if (proImgPath != null)
                    {
                        Product.addProduct(ddlType.SelectedItem.ToString(), txtName.Text, txtDesc.Text, Convert.ToDouble(txtPrice.Text), proImgPath, Convert.ToInt32(txtStock.Text));
                        Response.Redirect("..//Pages//ProductView.aspx");
                    }
                }
                else
                {
                    
                }
            }
            catch(Exception)
            {
                lblWarning.Text = "Invalid inputs ";
            }
        }

        public String imageHandling()
        {
            string strFileName;
            string strFilePath;
            string strFolder;
            
            strFolder = Server.MapPath("../Images/Products");
            // Retrieve the name of the file that is posted.            
            strFileName = filImage.PostedFile.FileName;
            strFileName = Path.GetFileName(strFileName);
            if (strFileName != "")
            {
                // Save the uploaded file to the server.
                strFilePath = strFolder + strFileName;
                if (File.Exists(strFilePath))
                {
                    lblWarning.Text = strFileName + " already exists on the server!";
                }
                else
                {
                    filImage.PostedFile.SaveAs(strFilePath);
                }
            }
            else
            {
                lblWarning.Text += " An image must be uploaded.";
                return null;
            }
            String databasePath = "../Images/Products" + filImage.PostedFile.FileName;
            return databasePath;
        }

    }
}