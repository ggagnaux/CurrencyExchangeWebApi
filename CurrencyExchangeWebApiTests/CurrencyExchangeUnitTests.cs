#region Namespaces
using CurrencyExchangeWebApi;
using CurrencyExchangeWebApi.Interfaces;
using CurrencyExchangeWebApi.Models;
using CurrencyExchangeWebApi.Services;
using CurrencyExchangeWebApi.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
#endregion

namespace CurrencyExchangeWebApiTests
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    [TestClass]
    public class CurrencyExchangeUnitTests
    {
        public ICurrencyExchangeService _service = new CurrencyExchangeService();

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        [TestMethod]
        public void VerifyTestCase1()
        {
            // Input:
            //      Invoice Date:     Aug 5, 2020,
            //      Pre-Tax Amount:   123.45 EUR,
            //      Payment Currency: USD
            //
            // Expected Output:
            //      Pre-Tax Total:    146.57 USD,
            //      Tax Amount:       14.66 USD,
            //      Grand Total:      161.23 USD,
            //      Exchange Rate:    1.187247

            // Arrange
            var input = new CurrencyExchangeInputItem
            {
                InvoiceDate = new DateTime(2020, 8, 5),
                PreTaxAmount = 123.45M,
                BaseCurrency = CurrencyCodeEnum.EUR,
                PaymentCurrency = CurrencyCodeEnum.USD
            };
            var expectedOutput = new CurrencyExchangeOutputItem
            {
                Success = true,
                PreTaxTotal = 146.57M,
                TaxAmount = 14.66M,
                GrandTotal = 161.23M,
                ExchangeRate = 1.187247M
            };

            // Act
            var actualOutput = _service.Calculate(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        [TestMethod]
        public void VerifyTestCase2()
        {
            // Input:
            //      Invoice Date:     Jul 12, 2019,
            //      Pre-Tax Amount:   1,000.00 EUR,
            //      Payment Currency: EUR
            //
            // Expected Output:
            //      Pre-Tax Total:    1,000.00 EUR,
            //      Tax Amount:       90.00 EUR,
            //      Grand Total:      1,090.00 EUR,
            //      Exchange Rate: 1

            // Arrange
            var input = new CurrencyExchangeInputItem
            {
                InvoiceDate = new DateTime(2019, 7, 12),
                PreTaxAmount = 1000.00M,
                BaseCurrency = CurrencyCodeEnum.EUR,
                PaymentCurrency = CurrencyCodeEnum.EUR
            };
            var expectedOutput = new CurrencyExchangeOutputItem
            {
                Success = true,
                PreTaxTotal = 1000.00M,
                TaxAmount = 90.00M,
                GrandTotal = 1090.00M,
                ExchangeRate = 1M
            };

            // Act
            var actualOutput = _service.Calculate(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        [TestMethod]
        public void VerifyTestCase3()
        {
            // Input:
            //      Invoice Date:     Aug 19, 2020,
            //      Pre-Tax Amount:   6,543.21 EUR,
            //      Payment Currency: CAD
            //
            // Expected Output:
            //      Pre-Tax Total:    10,239.07 CAD,
            //      Tax Amount:       1,126.30 CAD,
            //      Grand Total:      11,365.37 CAD,
            //      Exchange Rate:    1.564839

            // Arrange
            var input = new CurrencyExchangeInputItem
            {
                InvoiceDate = new DateTime(2020, 8, 19),
                PreTaxAmount = 6543.21M,
                BaseCurrency = CurrencyCodeEnum.EUR,
                PaymentCurrency = CurrencyCodeEnum.CDN
            };
            var expectedOutput = new CurrencyExchangeOutputItem
            {
                Success = true,
                PreTaxTotal = 10239.07M,
                TaxAmount = 1126.30M,
                GrandTotal = 11365.37M,
                ExchangeRate = 1.564839M
            };

            // Act
            var actualOutput = _service.Calculate(input);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}
