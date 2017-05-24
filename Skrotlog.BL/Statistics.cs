using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.Domain;

namespace Skrotlog.BL
{
    /// <summary>
    /// Represents a Class for performing analysis on collections of Contracts 
    /// </summary>
    class Statistics
    {
        private List<Contract> targetContracts;
       
        public Statistics()
        {

        }
        public Statistics(List<Contract> listOfContracts)
        {
            targetContracts = listOfContracts;
        }


        /// <summary>
        /// Returns the summed up values of all contracts within a given period of time. Currencies are summed up individually
        /// </summary>
        /// <param name="startDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="endDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="outputInEur">The sum of all contracts, where the currency is marked as european</param>
        /// <param name="outputInDKK">The sum of all contracts, where the currency is marked as danish</param>
        public void ReturnSummedValues(DateTime startDate, DateTime endDate, out decimal outputInDKK, out decimal outputInEur)
        {
            List<Contract> calculationList = targetContracts.FindAll(x => x.Date == startDate && x.Date <= endDate);
            decimal sumDKK = 0m;
            decimal sumEur = 0m;
            decimal tempContainer = 0m;

            foreach (var targetContract in calculationList)
            {
                foreach (var targetContractLine in targetContract.ContractLines)
                {
                    tempContainer += targetContractLine.Price * targetContractLine.DeliveredAmount;
                }

                switch (targetContract.Currency)
                {
                    case Currency.DKK:
                        sumDKK += tempContainer;
                        break;
                    case Currency.EUR:
                        sumEur += tempContainer;
                        break;
                    default:
                        break;
                }
            }
            outputInDKK = sumDKK;
            outputInEur = sumEur;
                        
        }
    }
}
