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
        public void ContractUpdate_AddAmount_DeliveredAmountIncreased()
        {
            Material testMaterial = new Material("E1", "Jern");
            Customer testCustomer = new Customer("testCompany", "testland");
            ContractLine testContractLine = new ContractLine(1, testMaterial, 1000, 0, 0, true, "test comment");
        
            cr.AddContract(testCustomer, DateTime.Now, 0, "SH");
            Contract testContract = cr.Contracts[0];
            testContract.Id = 1;
            testContract.ContractLines.Add(testContractLine);

            Assert.AreEqual(0, testContract.ContractLines.Find(x => x.Material.Type.Equals("E1")).DeliveredAmount);
            cr.AddAmount(testContract.Id, testContractLine.Id, 25);
            Assert.AreEqual(25, testContract.ContractLines.Find(x => x.Material.Type.Equals("E1")).DeliveredAmount);
        }
    }
}
