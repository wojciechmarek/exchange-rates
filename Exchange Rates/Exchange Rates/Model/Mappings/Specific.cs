using System.Collections.Generic;

namespace Exchange_Rates.Model.Services
{
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