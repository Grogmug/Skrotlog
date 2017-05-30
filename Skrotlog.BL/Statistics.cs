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
                    sumOfContracts += SumUpContractLines(targetContract.ContractLines);
                }    
            }
            return sumOfContracts;
        }

        /// <summary>
        /// Returns the summed up price of all Contracts in the given Collection. Exchangerate for contracts 
        /// negotiated in Euroes is determinded by the Property "ExchangeRateEur" 
        /// </summary>
        /// <param name="startDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="endDate">The inclusive DateTime, which marks the start of the period.</param>
        /// <param name="targetContracts">The collection of  Contracts </param>
        public decimal ReturnTotalSumOfContracts(DateTime startDate, DateTime endDate, List<Contract> targetContracts)
        {
            decimal sumOfContractsLines = 0m;

            foreach (var targetContract in targetContracts)
            {
                if (targetContract.Date >= startDate && targetContract.Date <= endDate)
                {
                    switch (targetContract.Currency)
                    {
                        case Currency.DKK:
                            sumOfContractsLines += SumUpContractLines(targetContract.ContractLines);
                            break;
                        case Currency.EUR:
                            sumOfContractsLines += SumUpContractLines(targetContract.ContractLines) * exchangeRateEur;
                            break;
                        default:
                            break;
                    }
                }
                
            }
            return sumOfContractsLines;
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

        public List<StatContainer> ReturnMaterialAndCountryOverview(DateTime startDate, DateTime endDate, List<Contract> targetContracts)
        {
            //this may not even work.....
            return CreateStatContainers(targetContracts.Where(x => x.Date >= startDate && x.Date <= endDate));
                       
        }

        private decimal SumUpContractLines(List<ContractLine> targetLines)
        {
            decimal output = 0m;
            foreach (var targetLine in targetLines)
            {
                output += targetLine.Price * targetLine.DeliveredAmount;
            }
            return output;
        }

        private List<StatContainer> CreateStatContainers(IEnumerable<Contract> targetContracts)
        {

            IEnumerable<string> countries = targetContracts.Select(x => x.Customer.Country).Distinct();
            List<StatContainer> statcont = new List<StatContainer>();
            StatContainer sc;

            foreach (string countryString in countries)
            {
                foreach (Contract contract in targetContracts)
                {
                    if (contract.Customer.Country.ToLower().Equals(countryString.ToLower()))
                    {
                        foreach (var contractLine in contract.ContractLines)
                        {
                            if ((sc = statcont.Find(x => x.Country.Equals(countryString) && x.Material.Type.Equals(contractLine.Material.Type))) != null)
                            {
                                sc.Amount += contractLine.DeliveredAmount;
                            }
                            else
                            {
                                statcont.Add(new StatContainer(contract.Customer.Country, contractLine.Material, contractLine.DeliveredAmount));
                            }
                            
                            
                        }
                    }
                }
            }
            return statcont;
        }

    }
}
