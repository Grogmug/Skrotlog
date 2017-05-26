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
        string searchText;
        bool showInactive;

        public ObservableCollection<ContractLineDisplayItem> DisplayItems
        {
            get
            {
                if (showInactive)
                    return displayItems;

                return new ObservableCollection<ContractLineDisplayItem>(displayItems.ToList().FindAll(x => x.Active == true));
            }
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

        public string SearchText
        {
            get
            {
                if (searchText == null)
                    searchText = "";

                return searchText;
            }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
                SearchCommand.RaiseCanExecuteChanged();
            }
        }

        public bool ShowInactive
        {
            get
            {
                return showInactive;
            }
            set
            {
                showInactive = value;
                
                RaisePropertyChanged("DisplayItems");
            }
        }

        public DefaultCommand AddAmountCommand { get; set; }
        public DefaultCommand SearchCommand { get; set; }
        public DefaultCommand UpdateCommand { get; set; }

        public ContractViewModel()
        {
            bl = BLFacade.Instance;
            UpdateContractList();
            AddAmountCommand = new DefaultCommand(ExecuteAddAmount, CanAddAmount);
            SearchCommand = new DefaultCommand(ExecuteSearch, CanSearch);
            UpdateCommand = new DefaultCommand(ExecuteUpdate);
        }

        private void PopulateDisplayItems()
        {
            PopulateDisplayItems(contracts);
        }    
        
        private void PopulateDisplayItems(List<Contract> contracts)
        {
            displayItems = new ObservableCollection<ContractLineDisplayItem>();

            for (int i = 0; i < contracts.Count; i++)
            {
                if (contracts[i].ContractLines.Count > 0)
                {
                    for (int y = 0; y < contracts[i].ContractLines.Count; y++)
                    {
                        ContractLineDisplayItem item = new ContractLineDisplayItem(contracts[i], contracts[i].ContractLines[y]);

                        displayItems.Add(item);
                    }
                }
            }
        }
        private void UpdateContractList()
        {
            contracts = bl.GetContracts();
            PopulateDisplayItems();
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

        public void ExecuteSearch()
        {
            if (searchText == "")
                UpdateContractList();
            else
            {
                PopulateDisplayItems(bl.GetCustomerContracts(searchText));
            }

            RaisePropertyChanged("DisplayItems");
        }

        public bool CanSearch()
        {
            return SearchText != "";
        }

        public void ExecuteUpdate()
        {
            UpdateContractList();
            RaisePropertyChanged("DisplayItems");
        }

        public void ExecuteDeactivate()
        {
            bl.DeactivateContractLine(SelectedDisplayItem.ContractId, SelectedDisplayItem.ContractLineId);
        }

        public bool CanDeactivate()
        {
            return SelectedDisplayItem != null;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
