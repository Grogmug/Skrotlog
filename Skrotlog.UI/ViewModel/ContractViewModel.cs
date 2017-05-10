using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Skrotlog.Domain;

namespace Skrotlog.UI.ViewModel
{
    class ContractViewModel
    {
        public ObservableCollection<Contract> Contracts { get; set; }
        public ObservableCollection<ContractLine> ContractLines
        {
            get
            {
                ObservableCollection<ContractLine> cl = new ObservableCollection<ContractLine>();

                for(int i = 0; i < Contracts.Count; i++)
                {
                    for(int y = 0; y < Contracts[i].ContractLines.Count; y++)
                    {
                        cl.Add(Contracts[i].ContractLines[y]);
                    }                        
                }

                return cl;
            }
        }
    }
}
