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
        //fields
        private List<Customer> listOfCustomers;        
        //Properties
        public int Count { get { return listOfCustomers.Count; } }

        public CustomerRepository()
        {
            listOfCustomers = new List<Customer>(); 
        }

        //Methods
        public void AddCustomer(Customer c)
        {
            listOfCustomers.Add(c);

        }
    }
}
