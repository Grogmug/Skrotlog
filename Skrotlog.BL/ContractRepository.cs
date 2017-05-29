using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;
using Skrotlog.DAL;

namespace Skrotlog.BL
{
    public class ContractRepository
    {
        private List<Contract> listOfContracts;
        private DALFacade dal;

        public int Count
        {
            get { return listOfContracts.Count; }
        }

        public ContractRepository()
        {
            dal = DALFacade.Instance;
            listOfContracts = dal.GetContracts();
        }
        public void AddContract(Customer customer, DateTime date, Currency currency, string initials)
        {
            int newContractId = dal.GetHighestId() + 1;
            Contract c = new Contract(newContractId ,customer, date, currency, initials);
            listOfContracts.Add(c);
            dal.AddContract(c);
        }

        public void AddContractLine(int contractId, Material material, decimal price, int amount, string comment)
        {
            ContractLine c = new ContractLine(material, price, amount, comment);
            listOfContracts.Find(x => x.Id == contractId).ContractLines.Add(c);
            dal.AddContractLine(contractId, c);
        }

        public void AddAmount(int contractId, int contractLineId, int amount)
        {
            Contract selectedContract = listOfContracts.Find(x => x.Id == contractId);
            ContractLine selectedContractLine = selectedContract.ContractLines.Find(x => x.Id == contractLineId);
            selectedContractLine.DeliveredAmount += amount;
            dal.AddAmount(contractId, contractLineId, amount);
        }

        public List<Contract> GetCustomerContracts(int customerId)
        {
            return listOfContracts.FindAll(x => x.Customer.Id == customerId);
        }

        public List<Contract> GetCustomerContracts(string name)
        {
            return listOfContracts.FindAll(x => x.Customer.Name.ToLower() == name.ToLower());
        }

        public List<Contract> GetContracts()
        {
            return listOfContracts;
        }

        public void DeactiveContractLine(int contractId, int contractLineId)
        {
            listOfContracts.Find(x => x.Id == contractId).ContractLines.Find(x => x.Id == contractLineId).Active = false;
            dal.DeactivateContractLine(contractLineId);
        }

        public void RemoveContractLine(int contractId, int contractLineId)
        {
            listOfContracts.Find(x => x.Id == contractId).ContractLines.RemoveAll(x => x.Id == contractLineId);
            dal.RemoveContractLine(contractLineId);
        }

    }
}
