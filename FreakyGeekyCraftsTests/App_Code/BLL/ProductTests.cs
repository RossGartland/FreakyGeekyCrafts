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
    public class ProductTests
    {
        [TestMethod()]
        public void ProductTest()
        {
            
        }
        
        [TestMethod()]
        public void getSetStrProductNameTest()
        {
            Product test = new Product();
            String expectedResult = "Earring";
            test.setStrProductName(expectedResult);        
            String actualResult = test.getStrProductName();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod()]
        public void getSetStrProductDescTest()
        {
            Product test = new Product();
            String expectedResult = "For that perfect event";
            test.setStrProductDesc(expectedResult);
            String actualResult = test.getStrProductDesc();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod()]
        public void getSetStrImageFileTest()
        {
            Product test = new Product();
            String expectedResult = "../Images/image.jpg";
            test.setStrImageFile(expectedResult);
            String actualResult = test.getStrImageFile();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetDblPriceTest()
        {
            Product test = new Product();
            double expectedResult = 7.43;
            test.setDblPrice(expectedResult);
            double actualResult = test.getDblPrice();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetIntStockTest()
        {
            Product test = new Product();
            int expectedResult = 12;
            test.setIntStock(expectedResult);
            int actualResult = test.getIntStock();
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod()]
        public void loadProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void updateProductTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void restockTest()
        {
            Assert.Fail();
        }
    }
}