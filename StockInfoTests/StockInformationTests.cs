using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockInfo.Tests
{
    [TestClass()]
    public class StockInformationTests
    {
        [TestMethod()]
        public void validTest()
        {
            StockInformation stockinfoclass = new StockInformation(1234,"pass","1ab23");
            int market = stockinfoclass.marketCapitilisationInMillions;
            Assert.AreEqual("QA",stockinfoclass.companyName);

        }

        [TestMethod()]
        public void validSymbol()
        {
            bool exceptionFound = false;
            try
            {
                StockInformation stockinfoclass = new StockInformation(1234, "pass", "1ab23");
            }
            catch (Exception es)
            {
                exceptionFound = true;
            }
            Assert.IsFalse(exceptionFound);
        }

        [TestMethod()]
        public void inValidSymbolEnd()
        {
            bool exceptionFound = false;
            try
            {
                StockInformation stockinfoclass = new StockInformation(1234, "pass", "1ab23@");
            }
            catch (Exception)
            {
                exceptionFound = true;
            }
            Assert.IsTrue(exceptionFound);
        }
        [TestMethod()]
        public void inValidSymbolStart()
        {
            bool exceptionFound = false;
            try
            {
                StockInformation stockinfoclass = new StockInformation(1234, "pass", "!1ab23");
            }
            catch (Exception)
            {
                exceptionFound = true;
            }
            Assert.IsTrue(exceptionFound);
        }
        [TestMethod()]
        public void inValidSymbolMixed()
        {
            bool exceptionFound = false;
            try
            {
                StockInformation stockinfoclass = new StockInformation(1234, "pass", "^1a$2*");
            }
            catch (Exception)
            {
                exceptionFound = true;
            }
            Assert.IsTrue(exceptionFound);
        }

        [TestMethod()]
        public void invalidUserId()
        { 
            StockInformation stockinfoclass = new StockInformation(110000, "pass", "aaaa");
            Assert.AreEqual("Not allowed",stockinfoclass.companyName);
        }
       //I didn't see any point in testing the boundries of the userid as it was being tested by someone else and developed by someone else.
       // the class you are writting isn't interacting with the password, it just needs to make sure that when false is returned the dummy values are assigned.
        [TestMethod()]
        public void invalidPassword()
        {
            StockInformation stockinfoclass = new StockInformation(1000000, "dodgypassword", "aaaa");
            Assert.AreEqual(0,stockinfoclass.currentPrice);
        }
        [TestMethod()]
        public void invalidUsernameAndPassword()
        {
            StockInformation stockinfoclass = new StockInformation(1000000, "dodgypassword", "aaaaa");
            Assert.AreEqual(" ", stockinfoclass.symbol);
        }
        //checking a wrong formated dodgy symbol throws an exception
        [TestMethod()]
        public void dodgySymbol()
        {
            bool exceptionFound = false;
            try
            {
                StockInformation stockinfoclass = new StockInformation(1234, "asdasd", "dodgysymbol");
            }
            catch (Exception)
            {
                exceptionFound = true;
            }
            Assert.IsTrue(exceptionFound);
        }
        //checking that the market cap in get works
        [TestMethod()]
        public void MarketCapTest()
        {
            //valid stock information should return
            StockInformation stockInfoClass = new StockInformation(1234, "pass", "lab123");
            //expected result: which is 1,000,000 times 5000 divided by 1,000,000
            int expected = 5000;
            //the actual variable
            int actual = stockInfoClass.marketCapitilisationInMillions;
            Assert.AreEqual(expected, actual);
        }
        //checking that the to string funciton works
        [TestMethod()]
        public void ToStringTest()
        {
            //valid stock information should return
            StockInformation stockInfoClass = new StockInformation(1234, "pass", "validsymb");
            //expected result 
            string expected = "QA[validsymb]1000000";
            string actual = stockInfoClass.toString();
            Assert.AreEqual(expected, actual);
        }
    }
}