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
        public Customer SelectedCustomer { get; set; }
        public List<Customer> Customers
        {
            get
            {
                List<Customer> customers = BLFacade.Instance.GetCustomers();
                SelectedCustomer = customers.First();
                return customers;
            }
        }
        public Material SelectedMaterial { get; set; }
        public List<Material> Materials
        {
            get
            {
                List<Material> materials = BLFacade.Instance.GetMaterials();
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
        public DefaultCommand CreateContractCommand { get; set; }
        public DefaultCommand CreateContractLineCommand { get; set; }

        public CreateContractViewModel()
        {
            CreateContractCommand = new DefaultCommand(ExecuteCreateContract);
            CreateContractLineCommand = new DefaultCommand(ExecuteCreateContractLine, CanCreateContractLine);
        }

        public void ExecuteCreateContract()
        {
            BLFacade.Instance.AddContract(SelectedCustomer, DateTime.Now, SelectedCurrency, "MR");
            ContractId = BLFacade.Instance.GetContracts().Last().Id;
            RaisePropertyChanged("ContractId");
        }

        public void ExecuteCreateContractLine()
        {
            BLFacade.Instance.AddContractLine(ContractId, SelectedMaterial, Price, Amount, Comment);
        }
        public bool CanCreateContractLine()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }
}
