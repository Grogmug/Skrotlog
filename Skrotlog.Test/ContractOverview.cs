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
        public void ContractOverview_GetMaterial_MaterialFound()
        {
            Material m = dbc.GetMaterial(1);

            Assert.AreEqual("Jern", m.Type);
            Assert.AreEqual("J", m.Designation);
        }

        [TestMethod]
        public void ContractOverview_GetContractLine_LineFound()
        {
            Material expectedMaterial = new Material("Jern", "J");

            List<ContractLine> lines = dbc.GetContractLines(1);
            ContractLine actual = lines.First();

            Assert.AreEqual(expectedMaterial.Type, actual.Material.Type);
            Assert.AreEqual(expectedMaterial.Designation, actual.Material.Designation);
            Assert.AreEqual(0.50m, actual.Price);
            Assert.AreEqual(1000, actual.TotalAmount);
            Assert.AreEqual(0, actual.DeliveredAmount);
            Assert.AreEqual(true, actual.Active);
            Assert.AreEqual("Hej", actual.Comment);
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
