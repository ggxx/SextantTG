using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantGT.Util;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class TourDAL : ITourDAL
    {
        private DbHelper dbHelper = null;

        public TourDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public TourDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_tour";
        private static readonly string SELECT___TOUR_ID = "select * from stg_tour where tour_id = :TourId";
        private static readonly string SELECT___TOUR_NAME = "select * from stg_tour where tour_name = :TourName";
        private static readonly string SELECT___USER_ID = "select * from stg_tour where user_id = :UserId";
        private static readonly string SELECT___USER_ID__TOUR_ID = "select * from stg_tour where user_id = :UserId and tour_id = :Tour_id";
        private static readonly string SELECT___STATUS = "select * from stg_tour where status = :Status";

        private static readonly string INSERT = "insert into stg_tour(tour_id, tour_name, begin_date, end_date, cost, status, creating_time, memos) values(:TourId, :TourName, :UserId, :BeginDate, :EndDate, :Cost, :Status, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_tour set tour_id = :TourId, tour_name = :TourName, user_id = :UserId, begin_date = :BeginDate, end_date = :EndDate, cost = :Cost, status = :Status, creating_time = :CreatingTime, memos = :Memos where tour_id = :TourId";
        private static readonly string DELETE = "delete from stg_tour where tour_id = :Tour_Id";

        private Tour BuildTourByReader(DbDataReader r)
        {
            Tour tour = new Tour();
            tour.TourId = TypeConverter.ToString(r["tour_id"]);
            tour.TourName = TypeConverter.ToString(r["tour_name"]);
            tour.UserId = TypeConverter.ToString(r["user_id"]);
            tour.BeginDate = TypeConverter.ToDateTimeNull(r["begin_date"]);
            tour.EndDate = TypeConverter.ToDateTimeNull(r["end_date"]);
            tour.Cost = TypeConverter.ToInt32Null(r["cost"]);
            tour.Status = TypeConverter.ToInt32Null(r["status"]);
            tour.CreatingTime = TypeConverter.ToDateTimeNull(r["creating_time"]);
            tour.Memos = TypeConverter.ToString(r["memos"]);
            return tour;
        }

        public List<Tour> GetTours()
        {
            List<Tour> tour= new List<Tour>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    tour.Add(BuildTourByReader(r));
                }
            }
            return tour;
        }

        public Tour GetTourByTourId(string tourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                if (r.Read())
                {
                    return BuildTourByReader(r);
                }
            }
            return null;
        }

        public List<Tour> GetToursByUserId(string userId)
        {
            List<Tour> tour = new List<Tour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    tour.Add(BuildTourByReader(r));
                }
            }
            return tour;
        }

        public List<Tour> GetTourByTourName(string tourName)
        {
            List<Tour> tours = new List<Tour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourName", tourName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_NAME, pars))
            {
                while (r.Read())
                {
                    tours.Add(BuildTourByReader(r));
                }
            }
            return tours;
        }

        public List<Tour> GetTourByUserIdAndTourId(string userId, string tourId)
        {
            List<Tour> tour = new List<Tour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("TourId", tourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID__TOUR_ID, pars))
            {
                while (r.Read())
                {
                    tour.Add(BuildTourByReader(r));
                }
            }
            return tour;
        }

        public List<Tour> GetTourByStatus(string status)
        {
            List<Tour> tour = new List<Tour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Status", status);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___STATUS, pars))
            {
                while (r.Read())
                {
                    tour.Add(BuildTourByReader(r));
                }
            }
            return tour;
        }
        

        public Tour GetTourById(string TourId)
        {
            Tour tour = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                if (r.Read())
                {
                    tour = BuildTourByReader(r);
                }
            }
            return tour;
        }

        public int InsertTour(Tour tour, DbTransaction trans)
        {
            tour.TourId = StringHelper.CreateGuid();
            tour.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tour.TourId);
            pars.Add("TourName", tour.TourName);
            pars.Add("UserId", tour.UserId);
            pars.Add("BeginDate", tour.BeginDate);
            pars.Add("EndDate", tour.EndDate);
            pars.Add("Cost", tour.Cost);
            pars.Add("Status", tour.Status);
            pars.Add("CreatingTime", tour.CreatingTime);
            pars.Add("Memos", tour.Memos);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateTour(Tour tour, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
           pars.Add("TourId", tour.TourId);
            pars.Add("TourName", tour.TourName);
            pars.Add("UserId", tour.UserId);
            pars.Add("BeginDate", tour.BeginDate);
            pars.Add("EndDate", tour.EndDate);
            pars.Add("Cost", tour.Cost);
            pars.Add("Status", tour.Status);
            pars.Add("CreatingTime", tour.CreatingTime);
            pars.Add("Memos", tour.Memos);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteTourByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
