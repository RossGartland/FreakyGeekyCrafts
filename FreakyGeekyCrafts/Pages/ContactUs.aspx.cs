using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FreakyGeekyCrafts.Pages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = "Message Sent";//Text to be displayed.
            string script = String.Format("alert('{0}');", message);//Type and value of script.
            //Adds script to page.
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "msgbox", script, true);
            txtEmail.Text = "";
            txtForename.Text = "";
            txtSurname.Text = "";
            return;
        }
    }
}