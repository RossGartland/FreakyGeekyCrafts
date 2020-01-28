using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class OrderConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Find most recent Invoice details
            Invoice inv = Invoice.getRecentInvoice();
    
            //Set to labels
            lblPriceDisplay.Text = inv.gettotalPrice().ToString();
            lblInvoiceDisplay.Text = inv.getInvoiceID().ToString();
            lblDateDisplay.Text = inv.getpurchaseDate().ToString();
        }//Page_Load

        //Directs the user to the Account page if they want to see past invoices.
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("..//Secure//Account.aspx");
        }//Button1_Click

    }//OrderConfirmation
}//namespace