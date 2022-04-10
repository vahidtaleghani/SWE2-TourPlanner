using SWE2_TourPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SWE2_TourPlanner.ViewModels
{
    public class TourListVM : BaseViewModel
    {
        private TourItem currentItem;
        public ObservableCollection<TourItem> TourItems { get; set; }

        public TourItem CurrentItem
        {
            get
            {
                return currentItem;
            }
            set
            {
                if ((currentItem != value) && (value != null))
                {
                    currentItem = value;
                    RaisePropertyChangedEvent(nameof(CurrentItem));
                }
            }
        }
        public TourListVM()
        {
            TourItems = new ObservableCollection<TourItem>();
        }

        public void FillListBox(IEnumerable<TourItem> tourItems)
        {
            TourItems.Clear();
            foreach (TourItem item in tourItems)
            {
                TourItems.Add(item);
            }
        }
    }
}
