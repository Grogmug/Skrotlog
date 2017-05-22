using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Skrotlog.BL;
using Skrotlog.Domain;

namespace Skrotlog.UI.ViewModel
{
    public class CreateCustomerViewModel : INotifyPropertyChanged
    {
        string name = "";
        string country = "";

        public string Name {
            get
            {
                return name;
            }
            set
            {
                name = value;
                CreateCommand.RaiseCanExecuteChanged();
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                CreateCommand.RaiseCanExecuteChanged();
            }
        }

        public DefaultCommand CreateCommand { get; set; }

        public CreateCustomerViewModel()
        {
            CreateCommand = new DefaultCommand(ExecuteCreate, CanCreate);
        }

        public void ExecuteCreate()
        {
            BLFacade.Instance.AddCustomer(Name, Country);

            Name = "";
            Country = "";
            RaisePropertyChanged("Name");
            RaisePropertyChanged("Country");
        }

        public bool CanCreate()
        {
            return Name != "" && Country != "";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
