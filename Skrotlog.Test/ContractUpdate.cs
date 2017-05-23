using System;
using Skrotlog.Domain;
using Skrotlog.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Skrotlog.Test
{
    [TestClass]
    public class ContractUpdate
    {
        ContractRepository cr;

        [TestInitialize]
        public void Setup()
        {
            cr = new ContractRepository();
        }

        [TestMethod]
        public void ContractUpdate_AddAmount_DeliveredAmountIncreased()
        {
            Material testMaterial = new Material("E1", "Jern");
            Customer testCustomer = new Customer(1, "STENA", "Danmark");
            ContractLine testContractLine = new ContractLine(1, testMaterial, 1000, 0, 0, true, "test comment");
        
            cr.AddContract(testCustomer, DateTime.Now, 0, "SH");
            Contract actual = cr.Contracts[0];
            actual.Id = 1;
            actual.ContractLines.Add(testContractLine);

            Assert.AreEqual(0, actual.ContractLines.First().DeliveredAmount);
            cr.AddAmount(actual.Id, testContractLine.Id, 25);
            actual = cr.Contracts[0];
            Assert.AreEqual(25, actual.ContractLines.First().DeliveredAmount);

            cr.AddAmount(actual.Id, testContractLine.Id, -25);
        }
    }
}
