using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skrotlog.BL;

namespace Skrotlog.UI.ViewModel
{
    public class SettingsViewModel : ViewModelBase
    {
        BLFacade bl;
        string initials;
        decimal exchangeRate;

        public string Initials
        {
            get
            {
                if (initials == null)
                    initials = bl.GetInitials();

                return initials;
            }
            set { initials = value; }
        }
        public decimal ExchangeRate
        {
            get
            {
                if (exchangeRate == 0)
                    exchangeRate = bl.GetExchangeRate();

                return exchangeRate;
            }
            set { exchangeRate = value; }
        }
        public string Information { get; set; }
        public DefaultCommand SaveCommand { get; set; }

        public SettingsViewModel()
        {
            bl = BLFacade.Instance;            
            SaveCommand = new DefaultCommand(ExecuteSave, CanSave);
        }

        public void ExecuteSave()
        {
            bl.SetInitials(Initials.ToUpper());
            bl.SetExchangeRate(ExchangeRate);
            Information = "Instillingerne er blevet gemt!";
            RaisePropertyChanged("Information");
        }

        public bool CanSave()
        {
            return initials != null && exchangeRate != 0m;
        }
    }
}
