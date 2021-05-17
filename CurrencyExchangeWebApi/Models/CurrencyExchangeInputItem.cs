#region Namespaces
using CurrencyExchangeWebApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace CurrencyExchangeWebApi.Models
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    public class CurrencyExchangeInputItem
    {
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public decimal PreTaxAmount { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public CurrencyCodeEnum BaseCurrency { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public CurrencyCodeEnum PaymentCurrency { get; set; }
    }
}