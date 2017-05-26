using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Skrotlog.Domain;
using Skrotlog.BL;
using System.Collections.ObjectModel;

namespace Skrotlog.UI.ViewModel
{
    class CreateContractViewModel : INotifyPropertyChanged
    {
        private BLFacade bl;
        private List<Customer> customers;
        private Customer selectedCustomer;

        public Customer SelectedCustomer
        {
            get
            {
                if (selectedCustomer == null)
                    selectedCustomer = customers.First();

                return selectedCustomer;
            }
            set
            {
                selectedCustomer = value;
            }
        }
        public List<Customer> Customers
        {
            get
            {
                if (customers == null)
                    customers = bl.GetCustomers();

                return customers;
            }
        }
        public Material SelectedMaterial { get; set; }
        public List<Material> Materials
        {
            get
            {
                List<Material> materials = bl.GetMaterials();
                SelectedMaterial = materials.First();
                return materials;
            }
        }
        public int ContractId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public string Comment { get; set; }
        public Currency SelectedCurrency { get; set; }
        public List<Currency> Currencies
        {
            get
            {
                List<Currency> currencies = new List<Currency>();
                currencies.Add(Currency.DKK);
                currencies.Add(Currency.EUR);
                return currencies;
            }
        }
        public string Information { get; set; }
        public DefaultCommand CreateContractCommand { get; set; }
        public DefaultCommand CreateContractLineCommand { get; set; }
        public DefaultCommand UpdateCustomersCommand { get; set; }

        public CreateContractViewModel()
        {
            bl = BLFacade.Instance;

            CreateContractCommand = new DefaultCommand(ExecuteCreateContract);
            CreateContractLineCommand = new DefaultCommand(ExecuteCreateContractLine, CanCreateContractLine);
            UpdateCustomersCommand = new DefaultCommand(ExecuteUpdateCustomers);
        }

        public void ExecuteCreateContract()
        {
            bl.AddContract(SelectedCustomer, DateTime.Now, SelectedCurrency, "MR");
            ContractId = bl.GetContracts().Last().Id;
            Information = string.Format("Kontrakten til {0} blev oprettet med kontraktnr. {1}", SelectedCustomer.Name, ContractId);
            RaisePropertyChanged("ContractId");
            RaisePropertyChanged("Information");
        }

        public void ExecuteCreateContractLine()
        {
            bl.AddContractLine(ContractId, SelectedMaterial, Price, Amount, Comment);
            Amount = 0;
            Price = 0;
            Information = string.Format("Kontraktlinjen med materialet {0}, til kontraktnr. {1} blev oprettet.", SelectedMaterial.Type, ContractId);
            RaisePropertyChanged("Information");
        }
        public bool CanCreateContractLine()
        {
            return true;
        }

        public void ExecuteUpdateCustomers()
        {
            customers = bl.GetCustomers();
            RaisePropertyChanged("Customers");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
