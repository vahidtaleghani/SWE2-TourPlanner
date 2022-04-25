using SWE2_TourPlanner.Models;
using System;
using System.Collections.Generic;


namespace SWE2_TourPlanner.BusinessLayer
{
    public interface ITourFactory
    {
        IEnumerable<TourItem> GetItems();
        IEnumerable<TourItem> Search(String itemName, bool caseSensitive = false);
        TourItem CreateTourItem(TourItem tourItem);
        TourLog CreateTourLog(TourLog tourLog, TourItem tourItem);
        IEnumerable<TourLog> GetTourLog(TourItem tourItem);
    }
}
