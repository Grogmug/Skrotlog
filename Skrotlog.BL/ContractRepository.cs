﻿using System;
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
        public void AddContract(Customer cust, DateTime date, Currency currency, string initials)
        {
            Contract c = new Contract(cust, date, currency, initials);
            listOfContracts.Add(c);
            //DALFacade.Instance.AddContract(c);
            
        }

        public void AddAmount(int contractId, int contractLineId, int amount)
        {
            
            Contract selectedContract = listOfContracts.Find(x => x.Id == contractId);
            ContractLine selectedContractLine = selectedContract.ContractLines.Find(x => x.Id == contractLineId);
            selectedContractLine.DeliveredAmount += amount;
            DALFacade.Instance.AddAmount( contractId, contractLineId, amount);
        }
    }
}
