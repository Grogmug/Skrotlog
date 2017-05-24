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
        private ContractRepository contractRepository;

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

        public decimal ExchangeRate;

        private BLFacade()
        {
            customerRepository = new CustomerRepository();
            contractRepository = new ContractRepository();
            ExchangeRate = 0m;
        }

        public void AddCustomer(string name, string country)
        {
            customerRepository.AddCustomer(name, country);
        }

        public List<Customer> GetCustomers()
        {
            return customerRepository.GetCustomers();
        }

        public List<Material> GetMaterials()
        {
            return DALFacade.Instance.GetMaterials().OrderBy(x => x.Type).ToList();
        }

        public List<Contract> GetCustomerContracts(int customerId)
        {
            return contractRepository.GetCustomerContracts(customerId);
        }

        public List<Contract> GetContracts()
        {
            return contractRepository.GetContracts();
        }

        public void AddAmount(int contractId, int contractLineId, int amount)
        {
            contractRepository.AddAmount(contractId,contractLineId, amount);
        }

        public void AddContract(Customer customer, DateTime date, Currency currency, string initials)
        {
            contractRepository.AddContract(customer, date, currency, initials);
        }
        public void AddContractLine(int contractId, Material material, decimal price, int amount, string comment)
        {
            contractRepository.AddContractLine(contractId, material, price, amount, comment);
        }
        public void ReturnSummedValue(DateTime startDate, DateTime endDate, out decimal outputInDK, out decimal outputInEur)
        {
            Statistics stats = new Statistics(contractRepository.GetContracts());
            stats.ReturnSummedValues(startDate, endDate, out outputInDK, out outputInEur);
            
        }

    }
}
