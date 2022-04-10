using SWE2_TourPlanner.Models;
using System.Collections.Generic;

namespace SEW2_TourPlanner.DataAccessLayer.DAO
{
    public interface ITourItemDAO
    {
        TourItem FindTourItemById(int tourItemId);
        TourItem AddNewTourItem(TourItem tourItem);
        IEnumerable<TourItem> GetTourItems();
    }
}
