using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.BL
{
    class Statistics
    {
        private List<Contract> targetContracts;
        public Statistics(List<Contract> listOfContracts)
        {
            targetContracts = listOfContracts;
        }

        public void ReturnSummedValue(DateTime startDate, DateTime endDate, decimal exchangeRate, out decimal outputInDK, out decimal outputInEur)
        {
            List<Contract> calculationList = targetContracts.FindAll(x => x.Date >= startDate && x.Date <= endDate);
            decimal outputContainer = 0m;
            foreach (var targetContract in targetContracts)
            {  
                foreach (var targetContractLine in targetContract.ContractLines)
                {
                    outputContainer += targetContractLine.Price;
                }

                if (targetContract.Currency == Currency.EUR)
                {

                }
            }


            
        }
    }
}
