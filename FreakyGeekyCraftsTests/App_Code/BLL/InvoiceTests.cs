using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreakyGeekyCrafts.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyGeekyCrafts.App_Code.BLL.Tests
{
    [TestClass()]
    public class InvoiceTests
    {
        //Tests the default constructor
        [TestMethod()]
        public void InvoiceTest1()
        {
            Invoice inv1 = new Invoice();
            Invoice inv2 = new Invoice(0, 1, DateTime.Today.ToString(), 0.00);
            String invoice1 = inv1.getInvoiceID() + inv1.getCustomerID() + inv1.getpurchaseDate() + inv1.gettotalPrice();
            String invoice2 = inv2.getInvoiceID() + inv2.getCustomerID() + inv2.getpurchaseDate() + inv2.gettotalPrice();
            Assert.AreEqual(invoice2, invoice1);
        }

        [TestMethod()]
        public void addInvoiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getRecentInvoiceTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getAllUserInvoicesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void getSetCustomerIDTest()
        {
            Invoice inv1 = new Invoice();
            int expectedResult = 4;
            inv1.setCustomerID(expectedResult);
            int actualResult = inv1.getCustomerID();
            Assert.AreEqual(expectedResult, actualResult); 
        }


        [TestMethod()]
        public void getSettotalPriceTest()
        {
            Invoice inv1 = new Invoice();
            double expectedResult = 12.45;
            inv1.settotalPrice(expectedResult);
            double actualResult = inv1.gettotalPrice();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod()]
        public void getSetpurchaseDateTest()
        {
            Invoice inv1 = new Invoice();
            String expectedResult = "03/11/2019";
            inv1.setpurchaseDate(expectedResult);
            String actualResult = inv1.getpurchaseDate();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod()]
        public void getSetInvoiceIDTest()
        {
            Invoice inv1 = new Invoice();
            int expectedResult = 3;
            inv1.setInvoiceID(expectedResult);
            int actualResult = inv1.getInvoiceID();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}