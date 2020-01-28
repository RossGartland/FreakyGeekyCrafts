using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks if a person has logged in.
            if (Session["customerObj"] != null)
            {
                //Gets the username of current user and sets the label to their name.
                UserLogin custObj = (UserLogin)Session["customerObj"];
                lblUsername.Text = custObj.getForename() + " " + custObj.getSurname();
                //Sets the signout button to visible.
                btnSignOut.Visible = true;
                Login.Visible = false;
            }//if
            else
            {
                //If a user isn't logged in, the signout button isn't visible.
                btnSignOut.Visible = false;
            }//else          
        }//Page_Load

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            //Signs out the user and sets the username label to blank.
            System.Web.Security.FormsAuthentication.SignOut();
            Session["customerObj"] = null;
            lblUsername.Text = "";
            btnSignOut.Visible = false;
            Login.Visible = true;
        }//btnSignOut
    }//class
}//namespace