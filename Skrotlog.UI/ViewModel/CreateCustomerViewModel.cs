using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skrotlog.UI.ViewModel
{
    public class CreateCustomerViewModel
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
            Name = "";
            Country = "test";
        }

        public bool CanCreate()
        {
            if (Name != "")
            {
                return true;
            }
            return false;
        }
    }
}
