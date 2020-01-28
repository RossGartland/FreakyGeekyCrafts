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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }//PageLoad

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //Checks that the entered details matches a login stored in the database
            UserLogin custObj = UserLogin.checkLogin(txtUsername.Text, txtPassword.Text);

            //If the login is correct, it is saved and the user is logged in.
            if (custObj != null)
            {
                Session["customerObj"] = custObj;
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(custObj.getFullName(), chkPersist.Checked); 
            }
            //If login is incorrect, textboxes are made blank and an error message is displayed.
            else
            {
                txtUsername.Text = "";
                lblWarning.Text = "Invalid credentials. Please try again.";
            }
        }//btnLogin

        //Directs the user to the Register page if they want to make a new account.
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }//button2
    }//class
}//namespace