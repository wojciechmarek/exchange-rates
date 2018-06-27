using System;
using Exchange_Rates.Model.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExchangeRatesTest
{
    [TestClass]
    public class GetGeneralTest 
    {
        DataAccessServices dataAccessServices = new DataAccessServices();

        [TestMethod]
        public void GeneralCurrenciesTest()
        {
            dataAccessServices.GetGeneralCurrencies(
                (item, error) =>
                {
                    Assert.IsNotNull(error);
                    Assert.IsNull(item);
                }
            );
        }
    }
}
