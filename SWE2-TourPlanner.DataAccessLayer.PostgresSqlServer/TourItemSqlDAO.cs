using SEW2_TourPlanner.DataAccessLayer.Common;
using SEW2_TourPlanner.DataAccessLayer.DAO;
using SWE2_TourPlanner.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace SWE2_TourPlanner.DataAccessLayer.PostgresSqlServer
{
    public class TourItemSqlDAO : ITourItemDAO
    {
        private const string SQL_FIND_BY_ID = "SELECT * FROM public.\"tour_item\" WHERE \"tour_item_id\"=@Id;";
        private const string SQL_GET_ALL_TOURS = "SELECT * FROM public.\"tour_item\";";
        private const string SQL_INSERT_NEW_TOUR = "INSERT INTO public.\"tour_item\" (\"name\", \"description\", \"from\",\"to\",\"image_path\",\"route\") VALUES (@Name, @Description, @From , @To , @ImagePath , @Route) RETURNING \"tour_item_id\";";

        private IDatabase database;

        public TourItemSqlDAO()
        {
            this.database = DALFactory.GetDatabase();
        }

        public TourItemSqlDAO(IDatabase database)
        {
            this.database = database;
        }
        // add new TourItem
        public TourItem AddNewTourItem(TourItem tourItem)
        {
            DbCommand insertCommand = database.CreateCommand(SQL_INSERT_NEW_TOUR);
            database.DefineParameter(insertCommand, "@Name", DbType.String, tourItem.Name);
            database.DefineParameter(insertCommand, "@Description", DbType.String, tourItem.Description);
            database.DefineParameter(insertCommand, "@From", DbType.String, tourItem.From);
            database.DefineParameter(insertCommand, "@To", DbType.String, tourItem.To);
            database.DefineParameter(insertCommand, "@ImagePath", DbType.String, tourItem.ImagePath);
            database.DefineParameter(insertCommand, "@Route", DbType.String, tourItem.Route);

            return FindTourItemById(database.ExecuteScalar(insertCommand));
        }

        // find tourItem by id
        public TourItem FindTourItemById(int tourItemId)
        {
            DbCommand findCommand = database.CreateCommand(SQL_FIND_BY_ID);
            database.DefineParameter(findCommand, "@Id", DbType.Int32, tourItemId);

            IEnumerable<TourItem> tours = QueryToursFromDb(findCommand);

            return tours.FirstOrDefault();
        }

        // get all tourItem
        public IEnumerable<TourItem> GetTourItems()
        {
            DbCommand getAllToursCommand = database.CreateCommand("SELECT * FROM public.\"tour_item\";");
            return QueryToursFromDb(getAllToursCommand);
        }

        //quering tours from postgres database
        private IEnumerable<TourItem> QueryToursFromDb(DbCommand command)
        {
            List<TourItem> tourList = new List<TourItem>();
            try
            {
                using (IDataReader reader = database.ExecuteReader(command))
                {
                    while (reader.Read())
                    {
                        tourList.Add(new TourItem(
                            Convert.ToInt32(reader["tour_item_id"]),
                            reader["name"].ToString(),
                            reader["description"].ToString(),
                            reader["from"].ToString(),
                            reader["to"].ToString(),
                            reader["image_path"].ToString(),
                            reader["route"].ToString()
                        ));
                    }
                }
            }
            catch (System.Exception)
            {
                throw;
            }
            
            return tourList;
        }
    }
}
