using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.BL
{
    public class CustomerRepository
    {
        private List<Customer> listOfCustomers;

        public int Count { get { return listOfCustomers.Count; } }

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
        }

        public void AddCustomer(Customer c)
        {
            listOfCustomers.Add(c);
        }
    }
}
