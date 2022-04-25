using SWE2_TourPlanner.BusinessLayer;
using SWE2_TourPlanner.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SWE2_TourPlanner.ViewModels
{
    public class TourVM : BaseViewModel
    {
        //Tour items

        // TourLog items
        private string dateTime;
        private string report;
        private string distance;
        private string totalTime;
        private string rating;

       
        private TourItem currentItem;
        private TourLog currentLog;

        public ObservableCollection<TourItem> TourItems { get; set; }
        public ObservableCollection<TourLog> TourLogs { get; set; }

        private ITourFactory tourItemFactory;
        private IEnumerable<TourLog> tourLogs;

        public TourVM()
        {
            TourItems = new ObservableCollection<TourItem>();
            TourLogs = new ObservableCollection<TourLog>();
        }

        public void FillListBox(IEnumerable<TourItem> tourItems)
        {
            TourItems.Clear();
            foreach (TourItem item in tourItems)
            {
                TourItems.Add(item);
            }
        }

        public void FillLogBox(IEnumerable<TourLog> tourLogs)
        {
            TourLogs.Clear();
            foreach (TourLog item in tourLogs)
            {
                TourLogs.Add(item);
            }
        }

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
                    this.tourItemFactory = TourFactory.GetInstance();
                    FillLogBox(this.tourItemFactory.GetTourLog(currentItem));
                }
            }
        }

        public IEnumerable<TourLog> Logs
        {
            get
            {
                return tourLogs;
            }
            set
            {
                if ((tourLogs != value) && (value != null))
                {
                    tourLogs = value;
                    RaisePropertyChangedEvent(nameof(Logs));
                }
            }
        }

        public TourLog CurrentLog
        {
            get
            {
                return currentLog;
            }
            set
            {
                if ((currentLog != value) && (value != null))
                {
                    currentLog = value;
                    RaisePropertyChangedEvent(nameof(currentLog));
                }
            }
        }

        public string DateTime
        {
            get { return dateTime.ToString(); }
            set
            {
                if ((dateTime != value) && (value != null))
                {
                    dateTime = value;
                    RaisePropertyChangedEvent(nameof(DateTime));
                }
            }
        }

        public string Report
        {
            get { return report; }
            set
            {
                if ((report != value) && (value != null))
                {
                    report = value;
                    RaisePropertyChangedEvent(nameof(Report));
                }
            }
        }

        public string Distance
        {
            get { return distance.ToString(); }
            set
            {
                if ((distance != value) && (value != null))
                {
                    distance = value;
                    RaisePropertyChangedEvent(nameof(Distance));
                }
            }
        }

        public string TotalTime
        {
            get { return totalTime.ToString(); }
            set
            {
                if ((totalTime != value) && (value != null))
                {
                    totalTime = value;
                    RaisePropertyChangedEvent(nameof(TotalTime));
                }
            }
        }

        public string Rating
        {
            get { return rating.ToString(); }
            set
            {
                if ((rating != value) && (value != null))
                {
                    rating = value;
                    RaisePropertyChangedEvent(nameof(Rating));
                }
            }
        }

    }
}
