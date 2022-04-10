using SWE2_TourPlanner.Models;
using System.Collections.Generic;

namespace SEW2_TourPlanner.DataAccessLayer.DAO
{
    public interface ITourLogDAO
    {
        TourLog FindTourLogById(int itemLogId);
        TourLog AddNewTourLog(TourLog tourLog, TourItem tourItem);
        IEnumerable<TourLog> GetLogItems(TourItem tourItem);
    }
}
