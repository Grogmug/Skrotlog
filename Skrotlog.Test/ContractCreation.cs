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
            //Contract testContract = new Contract(testCustomer, new DateTime(2017, 1, 1), Currency.DKK, "SH");

            cr.AddContract(testCustomer, new DateTime(2017, 1, 1), Currency.DKK, "SH");
            Contract actual = cr.Contracts.Find(x => x.Customer.Name == "TestCompany");
            
            Assert.AreEqual("TestCompany", actual.Customer.Name);
            Assert.AreEqual(2017, actual.Date.Year);
            Assert.AreEqual(1, actual.Date.Month);
            Assert.AreEqual(1, actual.Date.Day);
            Assert.AreEqual("SH", actual.Initials);
        }

        [TestMethod]
        public void ContractCreation_GetMaterial_ListOfMaterials()
        {
            List<Material> testList = new List<Material>();

            Assert.AreEqual(0,testList.Count);
            testList = BLFacade.Instance.GetMaterials();

            Assert.AreEqual(5, testList.Count);
        }

        [TestMethod]
        public void ContractCreation_GetContracts_ListOfContracts()
        {
            List<Contract> testContracts;
            testContracts = cr.GetContracts();

            Assert.IsTrue(testContracts.Count > 0);
        }
    }
}
