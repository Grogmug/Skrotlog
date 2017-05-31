using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.DAL
{
    // forced commit
    public class DALFacade
    {
        DatabaseController dbController;
        SettingsReader settingsReader;

        #region Singleton Region
        private static volatile DALFacade instance;

        public static DALFacade Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DALFacade();

                }
                return instance;
            }
        }
        #endregion

        private DALFacade()
        {
            dbController = new DatabaseController();
            settingsReader = new SettingsReader();
        }

        public List<Customer> GetCustomers()
        {
            return dbController.GetCustomers();
        }

        public List<Contract> GetContracts()
        {
            return dbController.GetContracts();
        }

        public List<Contract> GetContracts(string customerName)
        {
            return dbController.GetContracts(customerName);
        }

        public void AddAmount(int contractLineId, int amount)
        {
            dbController.AddAmount(contractLineId, amount);
        }

        public List<Material> GetMaterials()
        {
            return dbController.GetMaterials();
        }

        public void AddCustomer(Customer customer)
        {
            dbController.AddCustomer(customer);
        }

        public void AddContract(Contract contract)
        {
            dbController.AddContract(contract);
        }

        public void AddContractLine(int contractId, ContractLine contractLine)
        {
            dbController.AddContractLine(contractId, contractLine);
        }

        public int GetHighestContractId()
        {
            return dbController.GetHighestContractId();
        }

        public int GetHighestCustomerId()
        {
            return dbController.GetHighestCustomerId();
        }

        public void DeactivateContractLine(int contractLineId)
        {
            dbController.DeactivateContractLine(contractLineId);
        }

        public void RemoveContractLine(int contractLineId)
        {
            dbController.RemoveContractLine(contractLineId);
        }

        public string GetInitials()
        {
            return settingsReader.Initials;
        }

        public void SetInitials(string initials)
        {
            settingsReader.Initials = initials;
        }

        public decimal GetExchangeRate()
        {
            return settingsReader.ExchangeRate;
        }

        public void SetExchangeRate(decimal exchangeRate)
        {
            settingsReader.ExchangeRate = exchangeRate;
        }
    }
}
