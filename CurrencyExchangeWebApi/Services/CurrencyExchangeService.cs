#region Namespaces
using CurrencyExchangeWebApi.Interfaces;
using CurrencyExchangeWebApi.Models;
using CurrencyExchangeWebApi.Utility;
using FixerSharp;
using System;
#endregion

namespace CurrencyExchangeWebApi.Services
{
    /// <summary>
    /// Service that does the actual calculations
    /// </summary>
    public class CurrencyExchangeService : ICurrencyExchangeService
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CurrencyExchangeService() { }
        #endregion

        #region Public Methods
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CurrencyExchangeOutputItem Calculate(CurrencyExchangeInputItem input)
        {
            var invoiceDate = input.InvoiceDate;
            var preTaxAmount = input.PreTaxAmount;
            var baseCurrency = input.BaseCurrency;
            var paymentCurrency = input.PaymentCurrency;

            Fixer.SetApiKey(Constants.FixerAPIKey);

            // Get the amount after conversion
            var preTaxTotal = Fixer.Convert(MapCurrencyType(baseCurrency), MapCurrencyType(paymentCurrency), Convert.ToDouble(preTaxAmount), invoiceDate);

            // Get the Exchange rate on this particular date 
            var rate = Fixer.Rate(MapCurrencyType(baseCurrency), MapCurrencyType(paymentCurrency), invoiceDate);

            // Calculate the tax amount
            var taxAmount = 1M;

            // Calculate the grand total
            var grandTotal = 2M;

            return new CurrencyExchangeOutputItem
            {
                ExchangeRate = Convert.ToDecimal(rate.Rate),
                PreTaxTotal = Convert.ToDecimal(preTaxTotal),
                TaxAmount = taxAmount,
                GrandTotal = grandTotal
            };
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Map local CurrencyCodeEnum to FixerSharp's Symbol type (string)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private string MapCurrencyType(CurrencyCodeEnum _currencyCode)
        {
            var rval = Symbols.CAD;

            switch (_currencyCode)
            {
                case CurrencyCodeEnum.USD:
                    rval = Symbols.USD;
                    break;

                case CurrencyCodeEnum.EUR:
                    rval = Symbols.EUR;
                    break;

                default:
                    // Developer Note: Note really necessary but added for completeness
                    break;
            }

            return rval;
        }

        #endregion
    }
}