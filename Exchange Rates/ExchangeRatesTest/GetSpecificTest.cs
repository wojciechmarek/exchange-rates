using Exchange_Rates.Model.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatesTest
{
    [TestClass]
    public class GetSpecificTest
    {
        DataAccessServices dataAccessServices = new DataAccessServices();

        [TestMethod]
        public void SpecificCurrenciesTest()
        {
            dataAccessServices.GetSpecificCurrencies(
                (item, error) =>
                {
                    Assert.IsNotNull(error);
                    Assert.IsNull(item);

                }
            );
        }
    }
}

