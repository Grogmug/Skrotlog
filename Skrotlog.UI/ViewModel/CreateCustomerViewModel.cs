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
    public class CreateCustomerViewModel : ViewModelBase
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
        public string Information { get; set; }
        public DefaultCommand CreateCommand { get; set; }

        public CreateCustomerViewModel()
        {
            CreateCommand = new DefaultCommand(ExecuteCreate, CanCreate);
        }

        public void ExecuteCreate()
        {
            BLFacade.Instance.AddCustomer(Name, Country);

            Information = string.Format("{0} er oprettet i systemet.", Name);
            Name = "";
            Country = "";
            RaisePropertyChanged("Name");
            RaisePropertyChanged("Country");
            RaisePropertyChanged("Information");
        }

        public bool CanCreate()
        {
            return Name != "" && Country != "";
        }
    }
}
