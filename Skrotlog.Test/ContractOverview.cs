using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.DAL;
using Skrotlog.Domain;

namespace Skrotlog.Test
{
    [TestClass]
    public class ContractOverview
    {
        DatabaseController dbc;

        [TestInitialize]
        public void Setup()
        {
            dbc = new DatabaseController();
        }

        [TestMethod]
        public void ContractOverview_GetContracts_ContractsFound()
        {
            List<Contract> contracts;

            contracts = dbc.GetContracts();
            Contract actual = contracts.First();

            Assert.AreEqual("STENA", actual.Customer.Name);
            Assert.AreEqual(2, actual.ContractLines.Count);
            Assert.AreEqual("Jern", actual.ContractLines[0].Material.Type);
            Assert.AreEqual(1000, actual.ContractLines[0].TotalAmount);
            Assert.AreEqual(0, actual.ContractLines[0].DeliveredAmount);
            Assert.AreEqual(1000, actual.ContractLines[0].RemainingAmount);
            Assert.AreEqual(0.50, actual.ContractLines[0].Price);
        }
    }
}
