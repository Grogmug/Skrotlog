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
            Customer testCustomer = new Customer(1 ,"STENA", "Danmark");

            cr.AddContract(testCustomer, new DateTime(2017, 1, 1), Currency.DKK, "SH");
            Contract actual = cr.GetContracts().Last();
            
            Assert.AreEqual("STENA", actual.Customer.Name);
            Assert.AreEqual(2017, actual.Date.Year);
            Assert.AreEqual(1, actual.Date.Month);
            Assert.AreEqual(1, actual.Date.Day);
            Assert.AreEqual("SH", actual.Initials);
        }

        [TestMethod]
        public void ContractCreation_GetMaterials_ListOfMaterials()
        {
            List<Material> testList = new List<Material>();

            Assert.AreEqual(0,testList.Count);
            testList = BLFacade.Instance.GetMaterials();

            Assert.AreEqual(5, testList.Count);
        }

        [TestMethod]
        public void ContractCreation_AddContractLine_NewContractLine()
        {
            Material testMaterial = new Material(1, "Jern", "J");
            Contract testContract = cr.GetContracts().Last();

            cr.AddContractLine(testContract.Id, testMaterial, 10, 1000, "TestComment");
            ContractLine actual = cr.GetContracts().Last().ContractLines.Last();

            Assert.AreEqual("Jern", actual.Material.Type);
            Assert.AreEqual(10, actual.Price);
            Assert.AreEqual(1000, actual.TotalAmount);
            Assert.AreEqual("TestComment", actual.Comment);
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
