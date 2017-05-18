using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.DAL;
using Skrotlog.Domain;
using Skrotlog.BL;

namespace Skrotlog.Test
{
    [TestClass]
    public class ShowContractsOnCustomer
    {

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ShowContractsOnCustomer_GetCustomerContracts_ListOfContracts()
        {
            Customer testCustomer = new Customer(3, "TestCust", "Denmark");
            Customer testCustomer2 = new Customer(2, "TestCust", "Denmark");
            Contract testContract1 = new Contract(3, testCustomer, DateTime.Now, 0, "MR");
            Contract testContract2 = new Contract(4, testCustomer, DateTime.Now, 0, "MR");
            Contract testContract3 = new Contract(1, testCustomer2, DateTime.Now, 0, "MR");

            List<Contract> testList = new List<Contract>();
            List<Contract> resultList = new List<Contract>();

            testList.Add(testContract1);
            testList.Add(testContract2);
            testList.Add(testContract3);

            resultList = BLFacade.Instance.GetCustomerContracts(2);

            Assert.AreEqual(1, resultList.Count);
            Assert.AreNotEqual(resultList.Count, testList.Count);

            for (int i = 0; i < resultList.Count - 1; i++)
            {
                Assert.AreEqual(testList[i].Customer.Id, resultList[i].Customer.Id);
            }

        }
    }
}
