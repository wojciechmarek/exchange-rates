using Exchange_Rates.Model.Mappings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rates.Model.Services
{
    /// <summary>
    /// Klasa dostarcza metody do pobierania danych z serwera.
    /// </summary>
    public class Services
    {
        HttpClient httpClient = new HttpClient();

        /// <summary>
        /// Metoda pobiera główne kursy walut.
        /// </summary>
        /// <param name="exceptionCall">Parametr zwrotny z ewentualnym błędem pobierania danych.</param>
        /// <returns>Zwraca zmapowany obiekt głównych kursów walut.</returns>
        public General GetGeneral(Action<Exception> exceptionCall)
        {
            var table_a_url = ConfigurationManager.AppSettings["table_a_url"];

            try
            {
                var querry = string.Format(@table_a_url);
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

        /// <summary>
        /// Metoda pobiera szczegółowe kursy walut.
        /// </summary>
        /// <param name="exceptionCall">Parametr zwrotny z ewentualnym błędem pobierania danych.</param>
        /// <returns>Zwraca zmapowany obiekt szczegółowych kursów walut.</returns>
        public Specific GetSpecific(Action<Exception> exceptionCall)
        {

            var table_c_url = ConfigurationManager.AppSettings["table_c_url"];

            try
            {
                var querry = string.Format(table_c_url);
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
