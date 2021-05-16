#region Namespaces
using System.Collections.Generic;
using System.Linq;
#endregion

namespace CurrencyExchangeWebApi.Utility
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    public class TaxRates
    {
        #region Private Variables
        private Dictionary<CurrencyCodeEnum, decimal> _rates;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor
        /// </summary>
        public TaxRates()
        {
            _rates = new Dictionary<CurrencyCodeEnum, decimal>();
            _rates.Add(CurrencyCodeEnum.CDN, 0.11M);
            _rates.Add(CurrencyCodeEnum.USD, 0.10M);
            _rates.Add(CurrencyCodeEnum.EUR, 0.09M);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        /// <returns></returns>
        public Dictionary<CurrencyCodeEnum, decimal> GetRates()
        {
            return _rates;
        }

        /// <summary>
        /// TODO - Add Summary
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <returns></returns>
        public decimal GetRateByCurrencyCode(CurrencyCodeEnum currencyCode)
        {
            return _rates.FirstOrDefault(t => t.Key == currencyCode).Value;
        }
        #endregion
    }
}