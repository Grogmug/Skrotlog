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
    class ContractViewModel : INotifyPropertyChanged
    {
        private BLFacade bl;
        List<Contract> contracts;
        ObservableCollection<ContractLineDisplayItem> displayItems;
        ContractLineDisplayItem selectedDisplayItem;
        int deliveredAmount;

        public ObservableCollection<ContractLineDisplayItem> DisplayItems
        {
            get { return displayItems; }
        }

        public ContractLineDisplayItem SelectedDisplayItem
        {
            get { return selectedDisplayItem; }
            set
            {
                selectedDisplayItem = value;
                RaisePropertyChanged("SelectedDisplayItem");
                AddAmountCommand.RaiseCanExecuteChanged();
            }
        }
        public int DeliveredAmount
        {
            get { return deliveredAmount; }
            set
            {
                deliveredAmount = value;
                RaisePropertyChanged("DeliveredAmount");
                AddAmountCommand.RaiseCanExecuteChanged();
            }
        }

        public DefaultCommand AddAmountCommand { get; set; }

        public ContractViewModel()
        {
            bl = BLFacade.Instance;
            UpdateContractList();
            AddAmountCommand = new DefaultCommand(ExecuteAddAmount, CanAddAmount);
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

        public void ExecuteAddAmount()
        {
            bl.AddAmount(SelectedDisplayItem.ContractId, SelectedDisplayItem.ContractLineId, DeliveredAmount);
            UpdateContractList();
            RaisePropertyChanged("DisplayItems");
        }

        public bool CanAddAmount()
        {
            return DeliveredAmount > 0 && SelectedDisplayItem != null;
        }

        private void UpdateContractList()
        {
            contracts = bl.GetContracts();
            PopulateDisplayItems();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
