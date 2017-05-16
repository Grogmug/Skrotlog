using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.DAL
{
    public class DALFacade
    {
        DatabaseController dbController;

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

        public void AddAmount(int contractId, int contractLineId, int amount)
        {
           // dbController.AddAmount(int contractId, int contractLineId, int amount);
        }

        public List<Material> GetMaterials()
        {
            return dbController.GetMaterials();
        }
    }
}
