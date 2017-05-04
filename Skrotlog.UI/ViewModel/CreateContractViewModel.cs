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
        ObservableCollection<Material> materialCollection;

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

        public int Amount { get; set; }

        public decimal Price { get; set; }

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

        public string MaterialListDescription
        {
            get
            {
                string description = "";

                for(int i = 0; i < materialCollection.Count; i++)
                {
                    description += materialCollection[i].Type + "\n";
                }

                return description;
            }
        }

        public DefaultCommand CreateCommand { get; set; }
        public DefaultCommand AddCommand { get; set; }
        public DefaultCommand ClearCommand { get; set; }

        public CreateContractViewModel()
        {
            CreateCommand = new DefaultCommand(ExecuteCreate, CanCreate);
            AddCommand = new DefaultCommand(ExecuteAdd);
            ClearCommand = new DefaultCommand(ExecuteClear);
            materialCollection = new ObservableCollection<Material>();
        }

        public void ExecuteCreate()
        {
            Amount = 0;
            Price = 0;
            materialCollection.Clear();

            RaisePropertyChanged("Amount");
            RaisePropertyChanged("Price");
            RaisePropertyChanged("MaterialListDescription");
        }

        public bool CanCreate()
        {
            return true;
        }

        public void ExecuteAdd()
        {
            materialCollection.Add(SelectedMaterial);
            RaisePropertyChanged("MaterialListDescription");
        }

        public void ExecuteClear()
        {
            materialCollection.Clear();
            RaisePropertyChanged("MaterialListDescription");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
