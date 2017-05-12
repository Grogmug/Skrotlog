using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.BL
{
    public class ContractRepository
    {
        private List<Contract> listOfContracts;

        public int Count
        {
            get { return listOfContracts.Count; }
        }
        public List<Contract> Contracts
        {
            get { return listOfContracts; }
        }

        public ContractRepository()
        {
            listOfContracts = new List<Contract>();
        }
        public void AddContract(Contract c)
        {
            listOfContracts.Add(c);
        }

        public void AddAmount(int contractId, Material material, int amount)
        {
            listOfContracts.Find(x => x.Id == contractId).ContractLines.Find(x => x.Material.Type == material.Type).DeliveredAmount += amount;
        }
    }
}
