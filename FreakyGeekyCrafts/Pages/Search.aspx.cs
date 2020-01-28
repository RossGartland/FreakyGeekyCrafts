using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FreakyGeekyCrafts.App_Code.BLL;

namespace FreakyGeekyCrafts.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        //Fills string with all product names in database
        String[] sds = ProductList.getProductNames();
        protected void Page_Load(object sender, EventArgs e)
        {       
        }//PageLoad

        //Updates whenever the text is changed in the textbox.
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Clears the listbox of any potential previous results.
            lstResults.Items.Clear();
            String[] work = new String[20];
            int loop = 0;
            //Fills the array with all the product names
            do
            {
                work[loop] = sds[loop];
                loop++;
            }
            while (sds[loop] != null);
            
            //Initializes string to the entered details in the textbox. Converts them to lower so the entered case doesn't matter.
            String searchResult = txtSearch.Text.ToLower();

            if (searchResult != null && work[0] != null)
            {
                for (int index = 0; index < loop; index++)
                {
                    if (work[index].ToLower().StartsWith(searchResult))
                    {
                        lstResults.Items.Add(work[index]);
                    }                   
                }
            }
            else
            {
                lblResults.Text = "ERROR";
            }
        }//txtSearch_TextChanged

        //Runs when button is selected
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            //Saves selected item to a string
            String selectedItem = lstResults.SelectedItem.ToString();
            int ID = 0;
            
            for (int index = 0; index < sds.Length; index++)
            {
                if (sds[index] == selectedItem)
                {
                    ID = Convert.ToInt32(sds[index + 1]);
                }
            }
            //Saves Product ID to session variable so it can be passed through to next form.
            Session["SelectedProductID"] = ID;
            Response.Redirect("SelectedProduct.aspx");
        }//btnSelect
    }//Search
}//namespace