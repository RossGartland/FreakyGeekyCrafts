using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreakyGeekyCrafts.App_Code.BLL
{
    public class CartItem
    {
        private int strID;
        private string strName;
        private double dblPrice;
        private int intQty;

        public CartItem(int pID, string pName, double pPrice, int pQty)
        {
            this.strID = pID;
            this.strName = pName;
            this.dblPrice = pPrice;
            this.intQty = pQty;
        }
        // end of constructor  
        public int getID()
        {
            return this.strID;
        } // end of getID accessor 
        public void setID(int parID)
        {
            this.strID = parID;
        } // end of setID modifier 
        public string getName()
        {
            return this.strName;
        } // end of getName accessor   
        public void setName(string parName)
        {
            this.strName = parName;
        } // end of setName modifier 
        public double getPrice()
        {
            return this.dblPrice;
        } // end of getPrice accessor   
        public void setPrice(double parPrice)
        {
            this.dblPrice = parPrice;
        } // end of setPrice modifier  
        public int getQty()
        {
            return this.intQty;
        }  // end of getQty accessor  
        public void setQty(int parQty)
        {
            this.intQty = parQty;
        } // end of setQty modifier



    }
}