using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exchange_Rates.Model.Mappings;

namespace Exchange_Rates.Model.Services
{
    /// <summary>
    /// Klasa implementująca metody do obsługi zapytań o waluty z serwera.
    /// </summary>
    public class DataAccessServices : IDataAccessServices
    {
        Services services = new Services();

        /// <summary>
        /// Implementacja metody pobierające dane głównych kursów walut
        /// </summary>
        /// <param name="callback">Delegat zwracający kursy walut lub błędy pobierania</param>
        public void GetGeneralCurrencies(Action<General, Exception> callback)
        {
            var item = services.GetGeneral((error) => callback(null, error));
            if (item != null)
            {
                callback(item, null);
            }
        }

        /// <summary>
        /// Implementacja metody pobierające dane szczególowych kursów walut
        /// </summary>
        /// <param name="callback">Delegat zwracający kursy walut lub błędy pobierania</param>
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
