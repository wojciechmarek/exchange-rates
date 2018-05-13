using Exchange_Rates.Model.Mappings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rates.Model.Services
{
    public class Services
    {
        HttpClient httpClient = new HttpClient();

        public General GetGeneral(Action<Exception> exceptionCall)
        {
            try
            {
                var querry = string.Format($@"http://api.nbp.pl/api/exchangerates/tables/a/?format=json");
                var jsonData = httpClient.GetStringAsync(querry).Result;
                var currency = JsonConvert.DeserializeObject<List<General>>(jsonData);
                return currency[0];
            }
            catch (Exception ex)
            {
                exceptionCall(ex);
                return null;
            }

        }


       public Specific GetSpecific(Action<Exception> exceptionCall)
        {
            try
            {
                var querry = string.Format($@"http://api.nbp.pl/api/exchangerates/tables/c/?format=json");
                var jsonData = httpClient.GetStringAsync(querry).Result;
                var currency = JsonConvert.DeserializeObject<List<Specific>>(jsonData);
                return currency[0];
            }
            catch (Exception ex)
            {
                exceptionCall(ex);
                return null;
            }
        }
    }
}
