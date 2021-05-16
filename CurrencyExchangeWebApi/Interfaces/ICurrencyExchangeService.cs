#region Namespaces
using CurrencyExchangeWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace CurrencyExchangeWebApi.Interfaces
{
    public interface ICurrencyExchangeService
    {
        CurrencyExchangeOutputItem Calculate(CurrencyExchangeInputItem input);
    }
}
