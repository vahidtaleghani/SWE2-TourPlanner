using SWE2_TourPlanner.BusinessLayer;
using SWE2_TourPlanner.Models;
using SWE2_TourPlanner.ViewModels;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SWE2_TourPlanner.ViewModels
{
    public class SearchBarVM : BaseViewModel
    {
        public event EventHandler<string> SearchTextChanged;

        public ICommand SearchCommand { get; }
        public ICommand ClearCommand { get; }

        private string searchName;

        public string SearchName
        {
            get { return searchName; }
            set
            {
                if (searchName != value)
                {
                    searchName = value;
                    RaisePropertyChangedEvent(nameof(SearchName));
                }
            }
        }

        public SearchBarVM()
        {
            this.SearchCommand = new RelayCommand((_) =>
            {
                this.SearchTextChanged?.Invoke(this, SearchName);
            });

            this.ClearCommand = new RelayCommand((_) =>
            {
                this.SearchTextChanged?.Invoke(this, SearchName = "");
            });
        }
    }
}
