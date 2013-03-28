using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class TourDAL : AbstractDAL<Tour>, ITourDAL
    {
        public TourDAL() { }

        protected override Tour BuildObjectByReader(DbDataReader r)
        {
            Tour tour = new Tour();
            tour.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            tour.TourName = CustomTypeConverter.ToString(r["tour_name"]);
            tour.UserId = CustomTypeConverter.ToString(r["user_id"]);
            tour.BeginDate = CustomTypeConverter.ToDateTimeNull(r["begin_date"]);
            tour.EndDate = CustomTypeConverter.ToDateTimeNull(r["end_date"]);
            tour.Cost = CustomTypeConverter.ToInt32Null(r["cost"]);
            tour.Status = CustomTypeConverter.ToInt32Null(r["status"]);
            tour.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            tour.Memos = CustomTypeConverter.ToString(r["memos"]);
            return tour;
        }

        private static readonly string SELECT = "select * from stg_tour order by begin_date";
        private static readonly string SELECT___TOUR_ID = "select * from stg_tour where tour_id = :TourId order by begin_date";
        private static readonly string SELECT___USER_ID = "select * from stg_tour where user_id = :UserId order by begin_date";
        private static readonly string SELECT___SIGHTS_ID = "select distinct stg_tour.* from stg_tour, stg_sub_tour where stg_tour.tour_id = stg_sub_tour.tour_id and stg_sub_tour.sights_id = :SightsId order by stg_tour.begin_date";
        private static readonly string SELECT___SIGHTS_ID___DATE = "select distinct stg_tour.* from stg_tour, stg_sub_tour where stg_tour.tour_id = stg_sub_tour.tour_id and stg_sub_tour.sights_id = :SightsId and :Date between stg_tour.begin_date and stg_tour.end_date order by stg_tour.begin_date";
        private static readonly string SELECT___DATE = "select * from stg_tour where :Date between begin_date and end_date order by begin_date";

        private static readonly string INSERT = "insert into stg_tour(tour_id, tour_name, user_id, begin_date, end_date, cost, status, creating_time, memos) values(:TourId, :TourName, :UserId, :BeginDate, :EndDate, :Cost, :Status, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_tour set tour_name = :TourName, user_id = :UserId, begin_date = :BeginDate, end_date = :EndDate, cost = :Cost, status = :Status, creating_time = :CreatingTime, memos = :Memos where tour_id = :TourId";
        private static readonly string DELETE = "delete from stg_tour where tour_id = :TourId";


        public List<Tour> GetTours()
        {
            return this.GetList(SELECT, null);
        }

        public List<Tour> GetToursByUserId(string userId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.GetList(SELECT___USER_ID, pars);
        }

        public Tour GetTourByTourId(string tourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.GetObject(SELECT___TOUR_ID, pars);
        }

        public List<Tour> GetToursBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public List<Tour> GetToursByDate(DateTime date)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Date", date);
            return this.GetList(SELECT___DATE, pars);
        }

        public List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            pars.Add("Date", date);
            return this.GetList(SELECT___SIGHTS_ID___DATE, pars);
        }

        public int InsertTour(Tour tour, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(tour.TourId))
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
            return this.ExecuteNonQuery(trans, INSERT, pars);
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
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int UpdateTourFromOld(Tour newItem, Tour oldItem, DbTransaction trans)
        {
            Tour tour = (Tour)newItem.Clone();
            tour.TourId = oldItem.TourId;
            return this.UpdateTour(tour, trans);
        }

        public int DeleteTour(Tour tour, DbTransaction trans)
        {
            return this.DeleteTourByTourId(tour.TourId, trans);
        }

        private int DeleteTourByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
