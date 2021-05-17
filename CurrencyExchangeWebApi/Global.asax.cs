#region Namespaces
using System.Web.Http;
#endregion

namespace CurrencyExchangeWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
