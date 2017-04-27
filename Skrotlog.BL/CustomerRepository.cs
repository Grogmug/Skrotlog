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
        private List<Customer> listOfCustomers = new List<Customer>();
        public int Count { get { return listOfCustomers.Count; } }

        public void AddCustomer(Customer c)
        {
            listOfCustomers.Add(c);

        }
    }
}
