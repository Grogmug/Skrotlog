using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Skrotlog.Domain;
using Skrotlog.BL;

namespace Skrotlog.UI.ViewModel
{
    class ContractViewModel
    {
        List<Contract> contracts;
        ObservableCollection<ContractLineDisplayItem> displayItems;

        public ObservableCollection<ContractLineDisplayItem> DisplayItems
        {
            get { return displayItems; }
        }

        public ContractLineDisplayItem SelectedDisplayItem { get; set; }

        public ContractViewModel()
        {
            contracts = BLFacade.Instance.GetContracts();
            PopulateDisplayItems();
        }

        private void PopulateDisplayItems()
        {
            displayItems = new ObservableCollection<ContractLineDisplayItem>();

            for(int i = 0; i < contracts.Count; i++)
            {
                if(contracts[i].ContractLines.Count > 0)
                {
                    for(int y = 0; y < contracts[i].ContractLines.Count; y++)
                    {
                        ContractLineDisplayItem item = new ContractLineDisplayItem(contracts[i], contracts[i].ContractLines[y]);

                        displayItems.Add(item);
                    }
                }
            }
        }
    }
}
