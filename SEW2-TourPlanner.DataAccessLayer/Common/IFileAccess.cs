using SWE2_TourPlanner.Models;
using System.Collections.Generic;
using System.IO;

namespace SEW2_TourPlanner.DataAccessLayer.Common
{
    public interface IFileAccess
    {
        int CreateNewTourItemFile(TourItem tourItem);
        int CreateNewTourLogFile(TourLog tourLog);
        IEnumerable<FileInfo> SearchFiles(string searchTerm, TourTypes tourTypes);
        IEnumerable<FileInfo> GetAllFiles(TourTypes tourTypes);
    }
}
