using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
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
        private static readonly string UPDATE = "update stg_sub_tour set sub_tour_name = :SubTourName, sights_id = :SightsId, begin_date = :BeginDate, end_date = :EndDate, creating_time = :CreatingTime, memos = :Memos where tour_id = :TourId and sub_tour_id =: SubTourId";
        private static readonly string DELETE = "delete from stg_sub_tour where tour_id = :TourId and sub_tour_id = :SubTourId";

        private SubTour BuildSubTourByReader(DbDataReader r)
        {
            SubTour subtour = new SubTour();
            subtour.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            subtour.SubTourId = CustomTypeConverter.ToString(r["sub_tour_id"]);
            subtour.SubTourName = CustomTypeConverter.ToString(r["sub_tour_name"]);
            subtour.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            subtour.BeginDate = CustomTypeConverter.ToDateTimeNull(r["begin_date"]);
            subtour.EndDate = CustomTypeConverter.ToDateTimeNull(r["end_date"]);
            subtour.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            subtour.Memos = CustomTypeConverter.ToString(r["memos"]);
            return subtour;
        }


        public List<SubTour> GetSubTours()
        {
            List<SubTour> subtour = new List<SubTour>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    subtour.Add(BuildSubTourByReader(r));
                }
            }
            return subtour;
        }
        
        public SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID__SUB_TOUR_ID, pars))
            {
                if (r.Read())
                {
                    return BuildSubTourByReader(r);
                }
            }
            return null;
        }

        public List<SubTour> GetSubToursByTourId(string tourId)
        {
            List<SubTour> subtours = new List<SubTour>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                while (r.Read())
                {
                    subtours.Add(BuildSubTourByReader(r));
                }
            }
            return subtours;
        }

        public int InsertSubTour(SubTour subtour, DbTransaction trans)
        {
            subtour.SubTourId = StringHelper.CreateGuid();
            subtour.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", subtour.TourId);
            pars.Add("SubTourId", subtour.SubTourId);
            pars.Add("SubTourName", subtour.SubTourName);
            pars.Add("SightsId", subtour.SightsId);
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
            pars.Add("SightsId", subtour.SightsId);
            pars.Add("BeginDate", subtour.BeginDate);
            pars.Add("EndDate", subtour.EndDate);
            pars.Add("CreatingTime", subtour.CreatingTime);
            pars.Add("Memos", subtour.Memos);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
