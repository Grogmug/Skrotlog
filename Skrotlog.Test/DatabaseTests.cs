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
    public class DatabaseTests
    {
        DatabaseController dbc;

        [TestInitialize]
        public void Setup()
        {
            dbc = new DatabaseController();
        }

        [TestMethod]
        public void Database_GetMaterial_MaterialFound()
        {
            Material m = dbc.GetMaterial(1);

            Assert.AreEqual("Jern", m.Type);
            Assert.AreEqual("J", m.Designation);
        }

        [TestMethod]
        public void Database_GetContractLine_LineFound()
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
        public void Database_GetContracts_ContractsFound()
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
            Assert.AreEqual(0.50m, actual.ContractLines[0].Price);
        }

        [TestMethod]
        public void Database_CreateCustomer_CustomerInDatabase()
        {
            Customer c = new Customer("TestCust", "Denmark");

            dbc.AddCustomer(c);
            Customer actual = dbc.GetCustomers().Last();

            Assert.AreEqual("TestCust", actual.Name);
            Assert.AreEqual("Denmark", actual.Country);
        }

        [TestMethod]
        public void Database_CreateContract_ContractInDatabase()
        {
            Customer customer = new Customer(3, "TestCust", "Denmark");
            Material material = new Material(1, "Jern", "J");
            ContractLine contractLine = new ContractLine(material, 0.50m, 1000, 0, true, "Nothing");
            DateTime date = new DateTime(2017, 5, 16);
            Contract contract = new Contract(4, customer, date, Currency.DKK, "MR");
            contract.ContractLines.Add(contractLine);

            dbc.AddContract(contract);
            Contract actual = dbc.GetContract(4);

            Assert.AreEqual("TestCust", actual.Customer.Name);
            //Assert.AreEqual(1, actual.ContractLines.Count);
            Assert.AreEqual("Jern", actual.ContractLines[0].Material.Type);
            Assert.AreEqual(1000, actual.ContractLines[0].TotalAmount);
            Assert.AreEqual(0, actual.ContractLines[0].DeliveredAmount);
            Assert.AreEqual(1000, actual.ContractLines[0].RemainingAmount);
            Assert.AreEqual(0.50m, actual.ContractLines[0].Price);
            Assert.AreEqual(2017, actual.Date.Year);
            Assert.AreEqual(5, actual.Date.Month);
            Assert.AreEqual(16, actual.Date.Day);
        }
    }
}
