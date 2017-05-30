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
        private Statistics stats;

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
            contractRepository = new ContractRepository();
            stats = new Statistics();
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

        public List<Contract> GetCustomerContracts(string name)
        {
            return contractRepository.GetCustomerContracts(name);
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

        public void DeactivateContractLine(int contractId, int contractLineId)
        {
            contractRepository.DeactiveContractLine(contractId, contractLineId);
        }

        public void RemoveContractLine(int contractId, int contractLineId)
        {
            contractRepository.RemoveContractLine(contractId, contractLineId);
        }

        //Statistics Methods

        public decimal ReturnTotalSumOfContracts(DateTime startDate, DateTime endDate, List<Contract> targetContracts)
        {
            return stats.ReturnTotalSumOfContracts(startDate, endDate, targetContracts);
        }

        public decimal ReturnSummedUpContracts(DateTime startDate, DateTime endDate, List<Contract> targetContracts, Currency currency)
        {
            return stats.ReturnSummedUpContracts(startDate, endDate, targetContracts, currency);
        }

        public string GetInitials()
        {
            return DALFacade.Instance.GetInitials();
        }

        public void SetInitials(string initials)
        {
            DALFacade.Instance.SetInitials(initials);
        }

        public decimal GetExchangeRate()
        {
            return DALFacade.Instance.GetExchangeRate();
        }

        public void SetExchangeRate(decimal exchangeRate)
        {
            DALFacade.Instance.SetExchangeRate(exchangeRate);
        }

    }
}
