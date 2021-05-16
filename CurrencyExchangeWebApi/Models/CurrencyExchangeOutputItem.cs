#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace CurrencyExchangeWebApi.Models
{
    public class CurrencyExchangeOutputItem
    {
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public decimal PreTaxTotal { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public decimal TaxAmount { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public decimal GrandTotal { get; set; }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public decimal ExchangeRate { get; set; }
    }
}