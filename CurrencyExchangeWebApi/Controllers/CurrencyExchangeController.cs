#region Namespaces
using CurrencyExchangeWebApi.Models;
using CurrencyExchangeWebApi.Services;
using CurrencyExchangeWebApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
#endregion

namespace CurrencyExchangeWebApi.Controllers
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    public class CurrencyExchangeController : ApiController
    {
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        /// <param name="_invoiceDate"></param>
        /// <param name="_preTaxAmount"></param>
        /// <param name="_baseCurrency"></param>
        /// <param name="_paymentCurrency"></param>
        /// <returns></returns>
        [HttpGet]
        public CurrencyExchangeOutputItem Calculate(DateTime _invoiceDate, decimal _preTaxAmount, CurrencyCodeEnum _baseCurrency, CurrencyCodeEnum _paymentCurrency)
        {
            // TODO - Validate all incoming data
            // For now, the happy path is assumed.

            var service = new CurrencyExchangeService();

            var input = new CurrencyExchangeInputItem
            {
                InvoiceDate = _invoiceDate,
                PreTaxAmount = _preTaxAmount,
                BaseCurrency = _baseCurrency,
                PaymentCurrency = _paymentCurrency
            };

            var output = service.Calculate(input);

            return output;
        }
    }
}
