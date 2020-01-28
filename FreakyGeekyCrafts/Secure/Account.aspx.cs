using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //If the user signs out, this checks and sends them off the page if they are.
                if (!User.Identity.IsAuthenticated)
                {
                    Response.Redirect("..//Pages//index.aspx");
                }//if
                UserLogin custObj = (UserLogin)Session["customerObj"];


                lblName.Text = "Name: " + custObj.getFullName();
                lblAddress.Text = "Address: " + custObj.getAddress();
                lblAccountStatus.Text = "Status: " + custObj.getStatus();

                //Set up Invoice listbox
                String[] invoices = Invoice.getAllUserInvoices(custObj.getID());

                for (int index = 0; index < invoices.Length; index++)
                {
                    lstInvoices.Items.Add(invoices[index]);
                }//for
                 //Gets the status of the current logged in user.
                String status = custObj.getStatus();

                //Checks if the user is a staff member, sets the edit product button to visible if they are staff.
                if (status == "Staff")
                {
                    Button1.Visible = true;
                    btnAdd.Visible = true;
                }//if
                else
                {
                    Button1.Visible = false;
                    btnAdd.Visible = false;
                }//else

            }
            catch (Exception)
            {
                Response.Redirect("..//Pages//Login.aspx");
            }
        }//Page_Load

        //Click method for Edit Product button
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Opens the ProductEdit form.
            Response.Redirect("ProductEdit.aspx");           
        }//Button1_Click

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //Open the ProductAdd form
            Response.Redirect("ProductAdd.aspx");
        }//btnAdd_Click
    }
}