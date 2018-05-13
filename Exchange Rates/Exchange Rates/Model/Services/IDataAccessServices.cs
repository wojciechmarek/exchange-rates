using Exchange_Rates.Model.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rates.Model.Services
{
    public interface IDataAccessServices
    {
         void GetGeneralCurrencies(Action<General, Exception> callback);
         void GetSpecificCurrencies(Action<Specific, Exception> callback);
    }
}
