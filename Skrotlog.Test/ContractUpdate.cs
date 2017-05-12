using System;
using Skrotlog.Domain;
using Skrotlog.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void ContractUpdate_AddAmount_DeliveredAmountEncreased()
        {
            Material testMaterial = new Material("E1", "Jern");
            Customer testCustomer = new Customer("testCompany", "testland");
            Contract testContract = new Contract(testCustomer, new DateTime(2017, 1, 2), 0, "SH");
            ContractLine testContractLine = new ContractLine(testMaterial, 10, 200);
            testContract.ContractLines.Add(testContractLine);
            testContract.Id = 1;

            Assert.AreEqual(0, testContractLine.DeliveredAmount);

            cr.AddContract(testContract);
            cr.AddAmount(testContract.Id, testMaterial, 25);

            Assert.AreEqual(25, testContractLine.DeliveredAmount);
        }
    }
}
