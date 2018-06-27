using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TcmbSharp;

namespace TcmbSharp.Tests
{
    [TestClass]
    public class TcmbTest
    {
        [TestMethod]
        public void Valid_Currency_Code_Should_Returns_Value()
        {
            // Arrange

            // Act
            var rate = Tcmb.Rate("USD"); 

            // Assest
            Assert.AreNotEqual(rate, null);
            Assert.IsTrue(rate > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Currency_Code_Should_Throw()
        {
            // Act
            Tcmb.Rate("ASD");
        }

        [TestMethod]
        public void Valid_Currency_Codes_Should_Returns_Value()
        {
            // Assest
            Assert.AreNotEqual(Tcmb.Rate("USD"), null);
            Assert.AreNotEqual(Tcmb.Rate("AUD"), null);
            Assert.AreNotEqual(Tcmb.Rate("DKK"), null);
            Assert.AreNotEqual(Tcmb.Rate("EUR"), null);
            Assert.AreNotEqual(Tcmb.Rate("GBP"), null);
            Assert.AreNotEqual(Tcmb.Rate("CHF"), null);
            Assert.AreNotEqual(Tcmb.Rate("SEK"), null);
            Assert.AreNotEqual(Tcmb.Rate("CAD"), null);
            Assert.AreNotEqual(Tcmb.Rate("KWD"), null);
            Assert.AreNotEqual(Tcmb.Rate("NOK"), null);
            Assert.AreNotEqual(Tcmb.Rate("SAR"), null);
            Assert.AreNotEqual(Tcmb.Rate("JPY"), null);
            Assert.AreNotEqual(Tcmb.Rate("BGN"), null);
            Assert.AreNotEqual(Tcmb.Rate("RON"), null);
            Assert.AreNotEqual(Tcmb.Rate("RUB"), null);
            Assert.AreNotEqual(Tcmb.Rate("IRR"), null);
            Assert.AreNotEqual(Tcmb.Rate("CNY"), null);
            Assert.AreNotEqual(Tcmb.Rate("PKR"), null);
        }
    }
}
