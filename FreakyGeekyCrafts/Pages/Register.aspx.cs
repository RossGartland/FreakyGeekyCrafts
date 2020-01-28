using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }//PageLoad

        protected void btnSubmit_Click(object sender, EventArgs e)
        { 
            try
            {
                //Registers a new user using entered details and directs them to the Login page.
                UserLogin reg = new UserLogin(txtEmail.Text, txtSurname.Text, txtForename.Text, txtAddress.Text, txtCity.Text, txtPostcode.Text, txtPhone.Text, txtPassword.Text, ddlStaff.Text);
                UserLogin.register(reg);
                Response.Redirect("Login.aspx");
            }
            catch (Exception)
            {
                lblWarning.Text = "Invalid input";
            }
        }//btnSubmit

        //Method to check the entered email, and displays options to create a staff account if the email matches the right domain. 
        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Contains("@fgc.com") && !(ddlStaff.Items.Contains(new ListItem ("Staff"))))
                {
                    ddlStaff.Items.Add("Staff");
                }
                else if (!(txtEmail.Text.Contains("@fgc.com")))
                {
                    ddlStaff.Items.Remove("Staff");
                }
            }
            catch (Exception)
            {
            }
        }//txtEmail_TextChanged
    }//Register
}//namespace