using SWE2_TourPlanner.BusinessLayer;
using SWE2_TourPlanner.Models;
using System.Windows;
using System.Windows.Input;

namespace SWE2_TourPlanner.ViewModels
{
    public class AddTourVM : BaseViewModel
    {
        private string tourName;
        private string tourDescription;
        private string tourFrom;
        private string tourTo;

        private ITourFactory tourFactory;

        private ICommand addNewTourCommand;

        public ICommand AddTour => addNewTourCommand ??= new RelayCommand(AddNewTour);

        public AddTourVM()
        {
            this.tourFactory = TourFactory.GetInstance();
        }

        private void AddNewTour(object commandParameter)
        {
            int id = this.tourFactory.GetLastTourId();
            TourItem newTour = new TourItem(id, tourName, tourDescription, tourFrom, tourTo,tourName,0);
            
            //save to DB
            this.tourFactory.CreateTourItem(newTour);
            //save image to Folder
            this.tourFactory.SaveRouteImageFromApi(TourFrom, TourTo, TourName);

            MessageBox.Show("New Tour Successfully added.");
            TourName = string.Empty;
            TourFrom = string.Empty;
            TourTo = string.Empty;
            TourDescription = string.Empty;

        }


        private double tourDistance()
        {
            // --------------------- 
            return 0;
        } 

        public string TourName
        {
            get { return tourName; }
            set
            {
                if ((tourName != value) && (value != null))
                {
                    tourName = value;
                    RaisePropertyChangedEvent(nameof(TourName));
                }
            }
        }


        public string TourDescription
        {
            get { return tourDescription; }
            set
            {
                if ((tourDescription != value) && (value != null))
                {
                    tourDescription = value;
                    RaisePropertyChangedEvent(nameof(TourDescription));
                }
            }
        }

        public string TourFrom
        {
            get { return tourFrom; }
            set
            {
                if ((tourFrom != value) && (value != null))
                {
                    tourFrom = value;
                    RaisePropertyChangedEvent(nameof(TourFrom));
                }
            }
        }

        public string TourTo
        {
            get { return tourTo; }
            set
            {
                if ((tourTo != value) && (value != null))
                {
                    tourTo = value;
                    RaisePropertyChangedEvent(nameof(TourTo));
                }
            }
        }

    }
}
