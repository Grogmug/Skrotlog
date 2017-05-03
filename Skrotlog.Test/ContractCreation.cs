using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.Domain;
using Skrotlog.BL;

namespace Skrotlog.Test
{
    [TestClass]
    public class ContractCreation
    {
        ContractRepository cr;

        [TestInitialize]
        public void Setup()
        {
            cr = new ContractRepository();
        }
        [TestMethod]
        public void ContractCreation_AddContract_NewContract()
        {
            Material testMaterial = new Material("E1", "Jern");
            List<Material> testList = new List<Material>();
            testList.Add(testMaterial);
            Customer testCustomer = new Customer("TestCompany", "Denmark");
            Contract testContract = new Contract(testCustomer,20000,testList, 100, new DateTime(2017,1,1), 0, "SH") ;

            cr.AddContract(testContract);
            Assert.AreEqual(1, cr.Count);
        }
    }
}
