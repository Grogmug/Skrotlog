using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;
using Skrotlog.DAL;

namespace Skrotlog.BL
{
    public class BLFacade
    {
        private CustomerRepository customerRepository;

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

        private BLFacade()
        {
            customerRepository = new CustomerRepository();
        }

        public void AddCustomer(Customer c)
        {
            customerRepository.AddCustomer(c);
        }

        public void AddCustomer(string name, string country)
        {
            customerRepository.AddCustomer(name, country);
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.Customers;
        }

        public List<Material> GetMaterials()
        {
            List<Material> materials = DALFacade.Instance.GetMaterials();

            return materials.OrderBy(x => x.Type).ToList(); 
        }
    }
}
