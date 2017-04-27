using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.Domain;
using Skrotlog.BL;

namespace Skrotlog.Test
{
    [TestClass]
    public class CustomerCreation
    {
        CustomerRepository cr;

        [TestInitialize]
        public void Setup()
        {
            cr = new CustomerRepository();
        }

        [TestMethod]
        public void CustomerCreation_AddCustomer_NewCustomer()
        {
            Customer testCustomer = new Customer("TestCompany", "Denmark");
            cr.AddCustomer(testCustomer);

            Assert.AreEqual(1, cr.Count);

        }
    }
}
