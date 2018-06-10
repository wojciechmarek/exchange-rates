using System.Collections.Generic;

namespace Exchange_Rates.Model.Services
{

    /// <summary>
    /// Klasa mapująca tabelę szczególowych kursów walut pobranych z serwera.
    /// </summary>
    public class Specific
    {
        public List<Symbols> rates { get; set; }

        public class Symbols
        {
            public string currency { get; set; }
            public string code { get; set; }
            public float bid { get; set; }
            public float ask { get; set; }
        }
    }
}