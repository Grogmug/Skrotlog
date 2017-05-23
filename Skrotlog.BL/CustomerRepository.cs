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

        public int Count
        {
            get { return listOfCustomers.Count; }
        }

        public List<Customer> Customers
        {
            get
            {
                return listOfCustomers.OrderBy(x => x.Name).ToList();
            }
        }

        public CustomerRepository()
        {
            listOfCustomers = new List<Customer>();
            listOfCustomers = DALFacade.Instance.GetCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            listOfCustomers.Add(customer);
            DALFacade.Instance.AddCustomer(customer);
        }

        public  void AddCustomer(string name, string country)
        {
            Customer c = new Customer(name, country);
            AddCustomer(c);
        }
    }
}
