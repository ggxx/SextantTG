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
    public class SubTourDAL : ISubTourDAL
    {
        private DbHelper dbHelper = null;

        public SubTourDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public SubTourDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_sub_tour";
        private static readonly string SELECT___TOUR_ID = "select * from stg_sub_tour where tour_id = :TourId";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_sub_tour where tour_id = :TourId and sub_tour_id = :SubTourId";
       
        private static readonly string INSERT = "insert into stg_sub_tour(tour_id, sub_tour_id, sub_tour_name, sights_id, begin_date, end_date, creating_time, memos) values(:TourId, :SubTourId, :SubTourName :SightsId, :BeginDate, :EndDate, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_sub_tour set tour_id = :TourId, sub_tour_id = :SubTourId, sub_tour_name = :SubTourName, sights_id = :SightsId, begin_date = :BeginDate, end_date = :EndDate, creating_time = :CreatingTime, memos = :Memos where tour_id = :TourId and sub_tour_id =: SubTourId";
        private static readonly string DELETE = "delete from stg_sub_tour where tour_id = :TourId and sub_tour_id = :Sub_tour_id";

        private SubTour BuildSubTourByReader(DbDataReader r)
        {
            SubTour subtour = new SubTour();
            subtour.TourId = TypeConverter.ToString(r["tour_id"]);
            subtour.SubTourId = TypeConverter.ToString(r["sub_tour_id"]);
            subtour.SubTourName = TypeConverter.ToString(r["sub_tour_name"]);
            subtour.SightsId = TypeConverter.ToString(r["sights_id"]);
            subtour.BeginDate = TypeConverter.ToString(r["begin_date"]);
            subtour.EndDate = TypeConverter.ToString(r["end_date"]);            
            subtour.CreatingTime = TypeConverter.ToDateTimeNull(r["creating_time"]);
            subtour.Memos = TypeConverter.ToString(r["memos"]);
            return subtour;
        }

        public List<SubTour> GetSubTour()
        {
            List<SubTour> subtour= new List<SubTour>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    subtour.Add(BuildSubTourByReader(r));
                }
            }
            return subtour;
        }

        public List<SubTour> GetSubTourByTourIdAndSubTourId(string TourId, string SubTourId)
        {
            List<SubTour> subtour = new List<SubTour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            pars.Add("SubTourId",SubTourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                while (r.Read())
                {
                    subtour.Add(BuildSubTourByReader(r));
                }
            }
            return subtour;
        }

        public List<SubTour> GetSubTourByUserId(string UserId)
        {
            List<Tour> subtour = new List<Tour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID__SUB_TOUR_ID, pars))
            {
                while (r.Read())
                {
                    subtour.Add(BuildSubTourByReader(r));
                }
            }
            return subtour;
        }

        
        public SubTour GetSubTourById(string TourId)
        {
            SubTour subtour = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                if (r.Read())
                {
                    subtour = BuildSubTourByReader(r);
                }
            }
            return subtour;
        }

        public int InsertSubTour(SubTour subtour, DbTransaction trans)
        {
            subtour.TourId = StringHelper.CreateGuid();
            subtour.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", subtour.TourId);
            pars.Add("SubTourId", subtour.SubTourId);
            pars.Add("SubTourName", subtour.SubTourName);
            pars.Add("SightsId", subtour.Sightsid);
            pars.Add("BeginDate", subtour.BeginDate);
            pars.Add("EndDate", subtour.EndDate);
            pars.Add("CreatingTime", subtour.CreatingTime);
            pars.Add("Memos", subtour.Memos);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSubTour(SubTour subtour, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", subtour.TourId);
            pars.Add("SubTourId", subtour.SubTourId);
            pars.Add("SubTourName", subtour.SubTourName);
            pars.Add("SightsId", subtour.Sightsid);
            pars.Add("BeginDate", subtour.BeginDate);
            pars.Add("EndDate", subtour.EndDate);
            pars.Add("CreatingTime", subtour.CreatingTime);
            pars.Add("Memos", subtour.Memos);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSubTourById(string TourId,string SubTourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            pars.Add("SubTourId", SubTourId);

            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
