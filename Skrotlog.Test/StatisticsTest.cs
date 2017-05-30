using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Skrotlog.Domain;
using Skrotlog.BL;

namespace Skrotlog.Test
{
    [TestClass]
    public class StatisticsTest
    {
        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void StatisticsTest_ReturnMaterialAndCountryOverview_ListOfStatContainers()
        {
            List<StatContainer> sc = BLFacade.Instance.ReturnMaterialAndCountryOverview(DateTime.MinValue, DateTime.MaxValue);

            Assert.IsNotNull(sc);
        }
    }
}
