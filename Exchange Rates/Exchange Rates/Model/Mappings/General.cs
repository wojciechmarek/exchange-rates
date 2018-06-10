using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rates.Model.Mappings
{ 
    /// <summary>
    /// Klasa mapująca tabelę głównych kursów walut pobranych z serwera.
    /// </summary>
    public class General
    {
        public string effectiveDate { get; set; }
        public List<Symbols> rates { get; set; }

        public class Symbols
        {
            public float mid { get; set; }
        }
    } 
}
