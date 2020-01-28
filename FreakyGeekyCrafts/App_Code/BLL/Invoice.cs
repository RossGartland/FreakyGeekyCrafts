using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL
{
    public class Invoice
    {
        private int customerID;
        private double totalPrice;
        private String purchaseDate;
        private int invoiceID;

        public Invoice(int customerID, String purchaseDate, double totalPrice)
        {
            this.customerID = customerID;
            this.purchaseDate = purchaseDate;
            this.totalPrice = totalPrice;
        }

        public Invoice()
        {
            this.purchaseDate = DateTime.Today.ToString();
            this.totalPrice = 0.00;
        }


        public Invoice(int invoiceID, int customerID, String purchaseDate, double totalPrice)
        {
            this.invoiceID = invoiceID;
            this.customerID = customerID;
            this.purchaseDate = purchaseDate;
            this.totalPrice = totalPrice;
        }



        public static void addInvoice(Invoice inv)
        {
            DataAccess.addInvoice(inv);
        }

        public static Invoice getRecentInvoice()
        {
            Invoice inv = DataAccess.getRecentInvoice();
            return inv;
        }

        public static String[] getAllUserInvoices(String userID)
        {
            String[] inv = DataAccess.getAllUserInvoices(userID);
            return inv;
        }


        public int getCustomerID()
        {
            return customerID;
        }

        public void setCustomerID(int customerID)
        {
            this.customerID = customerID;
        }

        public double gettotalPrice()
        {
            return totalPrice;
        }

        public void settotalPrice(double totalPrice)
        {
            this.totalPrice = totalPrice;
        }

        public String getpurchaseDate()
        {
            return purchaseDate;
        }

        public void setpurchaseDate(String setpurchaseDate)
        {
            this.purchaseDate = setpurchaseDate;
        }

        public int getInvoiceID()
        {
            return invoiceID;
        }

        public void setInvoiceID(int invoiceID)
        {
            this.invoiceID = invoiceID;
        }


    }



}