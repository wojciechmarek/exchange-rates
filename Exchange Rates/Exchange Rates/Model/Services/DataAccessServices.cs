using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange_Rates.Model.Mappings;

namespace Exchange_Rates.Model.Services
{
    public class DataAccessServices : IDataAccessServices
    {
        Services services = new Services();

        public void GetGeneralCurrencies(Action<General, Exception> callback)
        {
            var item = services.GetGeneral((error) => callback(null, error));
            if (item != null)
            {
                callback(item, null);
            }
        }

        public void GetSpecificCurrencies(Action<Specific, Exception> callback)
        {
            var item = services.GetSpecific((error) => callback(null, error));
            if (item != null)
            {
                callback(item, null);
            }
        }


    }
}
