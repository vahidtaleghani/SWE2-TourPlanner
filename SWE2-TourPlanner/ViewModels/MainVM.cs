using SWE2_TourPlanner.BusinessLayer;
using SWE2_TourPlanner.Models;
using System.Collections.Generic;

namespace SWE2_TourPlanner.ViewModels
{
    public class MainVM : BaseViewModel
    {
        private ITourFactory tourItemFactory;
        private readonly TourVM tourListVM;
        IEnumerable<TourItem> result;

        public MainVM()
        {

        }
        public MainVM(TourVM tourListVM, SearchBarVM searchBarVM )
        {
            this.tourItemFactory = TourFactory.GetInstance();
            this.result = this.tourItemFactory.GetItems();

            searchBarVM.SearchTextChanged += (_, searchName) =>
            {
                SearchTours(searchName);
            };
         
            this.tourListVM = tourListVM;
            tourListVM.FillListBox(result);
        }

        private void SearchTours(string searchText)
        {
            this.result = this.tourItemFactory.Search(searchText);
            tourListVM.FillListBox(result);
        }
    }
}
