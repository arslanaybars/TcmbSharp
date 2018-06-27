using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            var rate = Tcmb.GetRate("USD");

            // Assest
            Assert.AreNotEqual(rate, null);
            Assert.IsTrue(rate > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Invalid_Currency_Code_Should_Throw()
        {
            // Act
            Tcmb.GetRate("ASD");
        }

        [TestMethod]
        public void Valid_Currency_Codes_Should_Returns_Value()
        {
            // Assest
            Assert.AreNotEqual(Tcmb.GetRate("USD"), null);
            Assert.AreNotEqual(Tcmb.GetRate("AUD"), null);
            Assert.AreNotEqual(Tcmb.GetRate("DKK"), null);
            Assert.AreNotEqual(Tcmb.GetRate("EUR"), null);
            Assert.AreNotEqual(Tcmb.GetRate("GBP"), null);
            Assert.AreNotEqual(Tcmb.GetRate("CHF"), null);
            Assert.AreNotEqual(Tcmb.GetRate("SEK"), null);
            Assert.AreNotEqual(Tcmb.GetRate("CAD"), null);
            Assert.AreNotEqual(Tcmb.GetRate("KWD"), null);
            Assert.AreNotEqual(Tcmb.GetRate("NOK"), null);
            Assert.AreNotEqual(Tcmb.GetRate("SAR"), null);
            Assert.AreNotEqual(Tcmb.GetRate("JPY"), null);
            Assert.AreNotEqual(Tcmb.GetRate("BGN"), null);
            Assert.AreNotEqual(Tcmb.GetRate("RON"), null);
            Assert.AreNotEqual(Tcmb.GetRate("RUB"), null);
            Assert.AreNotEqual(Tcmb.GetRate("IRR"), null);
            Assert.AreNotEqual(Tcmb.GetRate("CNY"), null);
            Assert.AreNotEqual(Tcmb.GetRate("PKR"), null);
        }
    }
}
