using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreakyGeekyCrafts.App_Code.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreakyGeekyCrafts.App_Code.DAL;

namespace FreakyGeekyCrafts.App_Code.BLL.Tests
{
    [TestClass()]
    public class UserLoginTests
    {

        //Test default constructor
        [TestMethod()]
        public void UserLoginTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void checkLoginTest()
        {
            Assert.Fail();
        }


        [TestMethod()]
        public void getFullNameTest()
        {
            UserLogin us1 = new UserLogin ("email@email.com", "Jamesson","James", "3 Real Street", "Belfast", "BT23 FD4", "03433433434");
            String expectedDetails = "James Jamesson";
            String actualDetails = us1.getForename() + " " + us1.getSurname(); ;
            Assert.AreEqual(expectedDetails, actualDetails);
        }

        [TestMethod()]
        public void getAddressTest()
        {
            UserLogin us1 = new UserLogin("email@email.com", "Jamesson", "James", "3 Real Street", "Belfast", "BT23 FD4", "03433433434");
            String expectedDetails = "3 Real Street\nBelfast\nBT23 FD4";
            String actualDetails = us1.getVarAddress() + "\n" + us1.getCity() + "\n" + us1.getPostcode();
            Assert.AreEqual(expectedDetails, actualDetails);
        }

        [TestMethod()]
        public void getSetEmailTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "email@test.com";
            us1.setEmail(expectedResult);
            String actualResult = us1.getEmail();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetForenameTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "Luke";
            us1.setForename(expectedResult);
            String actualResult = us1.getForename();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetSurnameTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "Smith";
            us1.setSurname(expectedResult);
            String actualResult = us1.getSurname();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetStatusTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "Customer";
            us1.setStatus(expectedResult);
            String actualResult = us1.getStatus();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetVarAddressTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "6 Kings Road";
            us1.setAddress(expectedResult);
            String actualResult = us1.getVarAddress();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetPostcodeTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "BT23 7SD";
            us1.setPostcode(expectedResult);
            String actualResult = us1.getPostcode();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetPhoneTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "05454534534";
            us1.setPhone(expectedResult);
            String actualResult = us1.getPhone();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetCityTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "Belfast";
            us1.setCity(expectedResult);
            String actualResult = us1.getCity();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void getSetPasswordTest()
        {
            UserLogin us1 = new UserLogin();
            String expectedResult = "Password1";
            us1.setPassword(expectedResult);
            String actualResult = us1.getPassword();
            Assert.AreEqual(expectedResult, actualResult);
        }

        

        [TestMethod()]
        public void registerTest()
        {
            Assert.Fail();
        }
    }
}