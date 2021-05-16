#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace CurrencyExchangeWebApi.Utility
{
    public class Constants
    {
        /// <summary>
        /// External API key
        /// Developer Note: This should be stored in some kind of encrypted format
        /// </summary>
        public const string FixerAPIKey = "03364a1b87ee84f155cb7b334920b92c";

        /// <summary>
        /// Fixer External API Url
        /// </summary>
        public const string FixerAPIUrl = @"http://data.fixer.io/api/";
    }
}