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
    public class CartItemTests
    {

        [TestMethod()]
        public void getIDTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            int expectedResult = 3;
            int actualResult = test.getID();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void setIDTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            int expectedResult = 21;
            test.setID(21);
            int actualResult = test.getID();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getNameTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            String expectedResult = "Earring";
            String actualResult = test.getName();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void setNameTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            String expectedResult = "Ruby Ring";
            test.setName("Ruby Ring");
            String actualResult = test.getName();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getPriceTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            double expectedResult = 5.00;
            double actualResult = test.getPrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void setPriceTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            double expectedResult = 8.43;
            test.setPrice(8.43);
            double actualResult = test.getPrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getQtyTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            int expectedResult = 4;
            int actualResult = test.getQty();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void setQtyTest()
        {
            CartItem test = new CartItem(3, "Earring", 5.00, 4);
            int expectedResult = 15;
            test.setQty(15);
            int actualResult = test.getQty();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}