using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class ProductView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Populates a dataset with all products in the database
            System.Data.DataSet ds = ProductList.getProducts();
            //Fills the data grid view with the products
            dvgProducts.DataSource = ds.Tables["dtProducts"];
            dvgProducts.AllowPaging = true;
            dvgProducts.PageSize = 5;
            dvgProducts.DataBind();
        }//PageLoad
     

        public void productProcess(String productNo)
        {
            Session["selectedProduct"] = productNo;
            Response.Redirect("SelectedProduct.aspx");
        }//productProcess

        protected void dvgProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Allows another page of the gridview to be displayed.
            dvgProducts.PageIndex = e.NewPageIndex;
            dvgProducts.DataBind();
        }//dvgProducts

        protected void dvgProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Runs when user selects a product and sends the product details to the SelectedProduct page
            Session["SelectedProductID"] = dvgProducts.Rows[dvgProducts.SelectedIndex].Cells[1].Text;
            Response.Redirect("SelectedProduct.aspx");
        }//selectedIndexChanged
    }
}