#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace CurrencyExchangeWebApi.Models
{
    // TODO - Add Summary
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class CurrencyExchangeOutputItem
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    {
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        public bool Success { get; set; }

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

        // TODO - Add Summary
        public override bool Equals(Object obj)
        {
            if (obj is CurrencyExchangeOutputItem)
            {
                var that = obj as CurrencyExchangeOutputItem;
                return this.Success == that.Success && 
                       this.PreTaxTotal == that.PreTaxTotal && 
                       this.TaxAmount == that.TaxAmount && 
                       this.GrandTotal == that.GrandTotal && 
                       this.ExchangeRate == that.ExchangeRate;
            }

            return false;
        }
    }
}