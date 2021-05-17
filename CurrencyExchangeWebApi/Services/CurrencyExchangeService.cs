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
        /// <param name="_input"></param>
        /// <returns></returns>
        public CurrencyExchangeOutputItem Calculate(CurrencyExchangeInputItem _input)
        {
            try
            {
                var invoiceDate = _input.InvoiceDate;
                var preTaxAmount = _input.PreTaxAmount;
                var baseCurrency = _input.BaseCurrency;
                var paymentCurrency = _input.PaymentCurrency;

                // TODO - Move this call elsewhere
                // We only need to call it once at app startup.
                Fixer.SetApiKey(Constants.FixerAPIKey);

                // Get the amount after conversion and round off to two (2) decimal places
                var preTaxTotal = Convert.ToDecimal(Fixer.Convert(MapCurrencyType(baseCurrency), 
                                                                  MapCurrencyType(paymentCurrency), 
                                                                  Convert.ToDouble(preTaxAmount), 
                                                                  invoiceDate));
                preTaxTotal = Decimal.Round(preTaxTotal, Constants.DecimalPlaces);

                // Get the Exchange rate on this particular date 
                var exchangeRate = Fixer.Rate(MapCurrencyType(baseCurrency), MapCurrencyType(paymentCurrency), invoiceDate);
                var exchangeRateVal = Convert.ToDecimal(exchangeRate.Rate);

                // Look up the tax rate
                var taxRate = TaxRates.GetRateByCurrencyCode(paymentCurrency);

                // Calculate the tax amount (preTaxAmount * taxRate) and round to two (2) decimal places)
                var taxAmount = Decimal.Round(preTaxTotal * taxRate, Constants.DecimalPlaces);

                // Calculate the grand total (preTaxTotal + taxAmount)
                var grandTotal = Decimal.Round(preTaxTotal + taxAmount, Constants.DecimalPlaces);

                return new CurrencyExchangeOutputItem
                {
                    Success = true,
                    ExchangeRate = exchangeRateVal,
                    PreTaxTotal = preTaxTotal,
                    TaxAmount = taxAmount,
                    GrandTotal = grandTotal
                };
            }
            catch (Exception)
            {
                return new CurrencyExchangeOutputItem
                {
                    Success = false,
                    ExchangeRate = 0M,
                    PreTaxTotal = 0M,
                    TaxAmount = 0M,
                    GrandTotal = 0M
                };
            }
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