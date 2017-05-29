using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;
using Skrotlog.DAL;

namespace Skrotlog.BL
{
    public class CustomerRepository
    {
        private List<Customer> listOfCustomers;
        private DALFacade dal;

        public int Count
        {
            get { return listOfCustomers.Count; }
        }

        public CustomerRepository()
        {
            dal = DALFacade.Instance;
            listOfCustomers = dal.GetCustomers();
        }

        public  void AddCustomer(string name, string country)
        {
            Customer c = new Customer(name, country);
            c.Id = dal.GetHighestCustomerId() + 1;
            listOfCustomers.Add(c);
            dal.AddCustomer(c);
        }

        public List<Customer> GetCustomers()
        {
            return listOfCustomers;
        }
    }
}
