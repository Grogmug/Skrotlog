using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skrotlog.Domain;
using Skrotlog.BL;
using System.Linq;

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
            Customer actual = cr.Customers.Find(x => x.Name == "TestCompany");
            
            Assert.AreEqual("TestCompany", actual.Name);
            Assert.AreEqual("Denmark", actual.Country);
        }
    }
}
