#region Namespaces
using System.Collections.Generic;
using System.Linq;
#endregion

namespace CurrencyExchangeWebApi.Utility
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    class TaxRate
    {
        public CurrencyCodeEnum currencyCode;
        public decimal rate;
    }

    public static class TaxRates
    {
        // Build the rates lookup table
        static List<TaxRate> _rates = new List<TaxRate> {
            new TaxRate { currencyCode = CurrencyCodeEnum.CDN, rate = 0.11M },
            new TaxRate { currencyCode = CurrencyCodeEnum.USD, rate = 0.10M },
            new TaxRate { currencyCode = CurrencyCodeEnum.EUR, rate = 0.09M },
        };

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public static decimal GetRateByCurrencyCode(CurrencyCodeEnum currencyCode)
        {
            return _rates.FirstOrDefault(t => t.currencyCode == currencyCode).rate;
        }
    }
}