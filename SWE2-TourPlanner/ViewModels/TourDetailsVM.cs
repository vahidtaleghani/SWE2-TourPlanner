using SWE2_TourPlanner.Models;
using System;

namespace SWE2_TourPlanner.ViewModels
{
    public class TourDetailsVM : BaseViewModel
    {
        
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                if ((description != value) && (value != null))
                {
                    description = value;
                    RaisePropertyChangedEvent(nameof(Description));
                } 
            }
        }
        public TourDetailsVM()
        {
            
        }
        public TourDetailsVM(TourItem tourItem)
        {
            description = tourItem.Description;
        }

    }
}
