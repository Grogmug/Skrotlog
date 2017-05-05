using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.Domain;
using Skrotlog.BL;
using System.Linq;

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
            Contract actual = cr.Contracts.First();

            Assert.AreEqual(1, cr.Count);
            Assert.AreEqual("TestCompany", actual.Customer.Name);
            Assert.AreEqual(2017, actual.Date.Year);
            Assert.AreEqual(1, actual.Date.Month);
            Assert.AreEqual(1, actual.Date.Day);
            Assert.AreEqual("SH", actual.Initials);
        }
    }
}
