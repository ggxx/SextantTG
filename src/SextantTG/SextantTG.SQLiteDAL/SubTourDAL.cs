using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class SubTourDAL : AbstractDAL<SubTour>, ISubTourDAL
    {

        public SubTourDAL() { }

        protected override SubTour BuildObjectByReader(DbDataReader r)
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

        private static readonly string SELECT = "select * from stg_sub_tour order by begin_date";
        private static readonly string SELECT___USER_ID = "select stg_sub_tour.*  from stg_tour, stg_sub_tour where stg_tour.tour_id = stg_sub_tour.tour_id and stg_tour.user_id = :UserId order by stg_sub_tour.begin_date";
        private static readonly string SELECT___TOUR_ID = "select * from stg_sub_tour where tour_id = :TourId order by begin_date";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sub_tour where sights_id = :SightsId order by begin_date";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_sub_tour where tour_id = :TourId and sub_tour_id = :SubTourId";

        private static readonly string INSERT = "insert into stg_sub_tour(tour_id, sub_tour_id, sub_tour_name, sights_id, begin_date, end_date, creating_time, memos) values(:TourId, :SubTourId, :SubTourName, :SightsId, :BeginDate, :EndDate, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_sub_tour set sub_tour_name = :SubTourName, sights_id = :SightsId, begin_date = :BeginDate, end_date = :EndDate, creating_time = :CreatingTime, memos = :Memos where tour_id = :TourId and sub_tour_id = :SubTourId";
        private static readonly string DELETE___TOUR_ID__SUB_TOUR_ID = "delete from stg_sub_tour where tour_id = :TourId and sub_tour_id = :SubTourId";
        private static readonly string DELETE___TOUR_ID = "delete from stg_sub_tour where tour_id = :TourId";


        public List<SubTour> GetSubTours()
        {
            return this.GetList(SELECT, null);
        }
        
        public SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            return this.GetObject(SELECT___TOUR_ID__SUB_TOUR_ID, pars);
        }

        public List<SubTour> GetSubToursByTourId(string tourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.GetList(SELECT___TOUR_ID, pars);
        }

        public List<SubTour> GetSubToursByUserId(string userId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.GetList(SELECT___USER_ID, pars);
        }

        public List<SubTour> GetSubToursBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public int InsertSubTour(SubTour subTour, DbTransaction trans)
        {
            if(string.IsNullOrEmpty(subTour.SubTourId))
                subTour.SubTourId = StringHelper.CreateGuid();
            subTour.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", subTour.TourId);
            pars.Add("SubTourId", subTour.SubTourId);
            pars.Add("SubTourName", subTour.SubTourName);
            pars.Add("SightsId", subTour.SightsId);
            pars.Add("BeginDate", subTour.BeginDate);
            pars.Add("EndDate", subTour.EndDate);
            pars.Add("CreatingTime", subTour.CreatingTime);
            pars.Add("Memos", subTour.Memos);
            return this.ExecuteNonQuery(trans, INSERT, pars);
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
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            return this.ExecuteNonQuery(trans, DELETE___TOUR_ID__SUB_TOUR_ID, pars);
        }


        public int DeleteSubTourByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.ExecuteNonQuery(trans, DELETE___TOUR_ID, pars);
        }




    }
}
