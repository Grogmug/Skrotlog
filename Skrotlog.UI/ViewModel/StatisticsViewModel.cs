using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Skrotlog.BL;
using Skrotlog.Domain;

namespace Skrotlog.UI.ViewModel
{
    class StatisticsViewModel : ViewModelBase
    {
        private BLFacade bl;
        private ObservableCollection<StatContainer> displayItems;
        private DateTime startDate, endDate;

        public DateTime StartDate
        {
            get
            {
                if (startDate == null)
                {
                    startDate = DateTime.MinValue;
                }
                return startDate;
            }
            set
            {
                startDate = value;
            }
        }

        public DateTime EndDate
        {
            get
            {
                if (endDate == null)
                {
                    endDate = DateTime.MaxValue;
                }
                return endDate;
            }
            set
            {
                endDate = value;
            }
        }

        public ObservableCollection<StatContainer> DisplayItems
        {
            get { return displayItems; }
        }

        public DefaultCommand UpdateCommand { get; set; }
        public StatisticsViewModel()
        {
            startDate = DateTime.MinValue;
            endDate = DateTime.MaxValue;
            bl = BLFacade.Instance;
            PopulateDisplayItems();
            UpdateCommand = new DefaultCommand(ExcecuteUpdate);
        }

        private void PopulateDisplayItems()
        {
            displayItems = new ObservableCollection<StatContainer>(bl.ReturnMaterialAndCountryOverview(startDate, endDate));
        }

        public void ExcecuteUpdate()
        {
            PopulateDisplayItems();
            RaisePropertyChanged("DisplayItems");
        }
    }
}
