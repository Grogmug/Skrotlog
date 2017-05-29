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
        //private List<Contract> calcList; 
        private decimal exchangeRateEur;

        public decimal ExchangeRateEur
        {
            get { return exchangeRateEur; }
            set { exchangeRateEur = value; }
        }

       
        public Statistics()
        {
            //calcList = new List<Contract>();
            exchangeRateEur = 7.5m;
        }
    
        /// <summary>
        /// Returns the summed up value of all contracts negotiated in a given currency. 
        /// </summary>
        /// <param name="startDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="endDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="targetContracts">The collection of  Contracts </param>
        /// <param name="currency">The currency of the Contracts to be summed up</param>
        public decimal ReturnSummedUpContracts(DateTime startDate, DateTime endDate, List<Contract> targetContracts, Currency currency)
        {
            decimal sumOfContracts = 0m;

            foreach (var targetContract in targetContracts)
            {
                if (targetContract.Currency == currency && targetContract.Date >= startDate && targetContract.Date <= endDate)
                {
                    foreach (var targetContractLine in targetContract.ContractLines)
                    {
                        sumOfContracts += targetContractLine.DeliveredAmount * targetContractLine.Price;
                    }
                }    
            }
            return sumOfContracts;
        }

        /// <summary>
        /// Returns the summed up amount of a given Material delivered to a given Country. 
        /// </summary>
        /// <param name="startDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="endDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="targetContracts">The collection of  Contracts </param>
        /// <param name="material">The type of material, whoose delivered amount is to be calculated</param>
        /// <param name="Country">The name of the Country</param>
        public int ReturnSummedUpMaterials(DateTime startDate, DateTime endDate, List<Contract> targetContracts, Material material, string country)
        {
            int sumOfMaterials = 0;
            ContractLine localCont;

            foreach (var targetContract in targetContracts)
            {
                if (targetContract.Customer.Country == country && startDate <= targetContract.Date && targetContract.Date <= endDate)
                {
                    if ((localCont = targetContract.ContractLines.Find(x => x.Material == material)) != null)
                    {
                        sumOfMaterials += localCont.DeliveredAmount;
                    }
                }
            }
            return sumOfMaterials;
        }

    }
}
