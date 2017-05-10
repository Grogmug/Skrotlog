using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.BL
{
    public class BLFacade
    {
        #region Singleton Region
        private static volatile BLFacade instance;

        public static BLFacade Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new BLFacade();
                    
                }
                return instance;
            }
        }
        #endregion

        CustomerRepository customerRepository;

        private BLFacade()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customer c)
        {
            customerRepository.AddCustomer(c);
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.Customers;
        }

        public List<Material> GetMaterials()
        {
            //Test data
            List<Material> materials = new List<Material>();
            materials.Add(new Material("Aluminium", "A"));
            materials.Add(new Material("Jern", "E1"));
            materials.Add(new Material("Kobber", "K"));
            materials.Add(new Material("Messing", "M"));
            return materials.OrderBy(x => x.Type).ToList(); 
        }
    }
}
