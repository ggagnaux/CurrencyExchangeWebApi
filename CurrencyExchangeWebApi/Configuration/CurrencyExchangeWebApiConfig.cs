#region Namespaces 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
#endregion

namespace CurrencyExchangeWebApi.Configuration
{
    /// <summary>
    /// TODO - Add Summary
    /// </summary>
    public static class CurrencyExchangeWebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}