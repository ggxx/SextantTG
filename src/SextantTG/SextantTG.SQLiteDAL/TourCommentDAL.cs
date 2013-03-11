﻿using SextantTG.IDAL;
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
    public class TourCommentDAL : ITourCommentDAL
    {
        private DbHelper dbHelper = null;

        public TourCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public TourCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_tourcomment";
        private static readonly string SELECT___TOUR_ID = "select * from stg_tourcomment where tour_id = :TourId";
        private static readonly string SELECT___COMM_USER_ID = "select * from stg_tourcomment where comm_user_id = :CommUserId";
                        
        private static readonly string INSERT = "insert into stg_tourcomment(tour_id, comm_user_id, creating_time, comment) values(:TourId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_tourcomment set tour_id = :TourId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where tour_id = :TourId" ;
        private static readonly string DELETE = "delete from stg_tourcomment where tour_id = :TourId";

        private TourComment BuildTourCommentByReader(DbDataReader r)
        {
            TourComment tourcomment = new Favorite();
            tourcomment.TourId = TypeConverter.ToString(r["tour_id"]);
            tourcomment.CommUserId = TypeConverter.ToString(r["comm_user_id"]);
            tourcomment.CreatingtTime = TypeConverter.ToString(r["creating_time"]);
            tourcomment.Comment = TypeConverter.ToDateTimeNull(r["comment"]);           
           
            return tourcomment;
        }

        public List<TourComment> GetTourComments()
        {
            List<TourComment> tourcomments = new List<TourComment>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    tourcomments.Add(BuildTourCommentByReader(r));
                }
            }
            return tourcomments;
        }

       
        public List<TourComment> GetTourCommentsByTourId(string TourId)
        {
            List<TourComment> tourcomments = new List<TourComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                while (r.Read())
                {
                    tourcomments.Add(BuildTourCommentByReader(r));
                }
            }
            return tourcomments;
        }


        public List<TourComment> GetTourCommentsByCommUserId(string CommUserId)
        {
            List<TourComment> tourcomments = new List<TourComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                while (r.Read())
                {
                    tourcomments.Add(BuildTourCommentByReader(r));
                }
            }
            return tourcomments;
        }

      
       public TourComment GetTourCommentByTourId(string TourId)
        {
            TourComment tourcomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                if (r.Read())
                {
                    tourcomment = BuildTourCommentByReader(r);
                }
            }
            return tourcomment;
        }

        public TourComment GetTourCommentByCommUserId(string CommUserId)
        {
            TourComment tourcomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                if (r.Read())
                {
                    tourcomment = BuildTourCommentByReader(r);
                }
            }
            return tourcomment;
        }

      
        public int InsertTourComment(TourComment tourcomment, DbTransaction trans)
        {
                     
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourcomment.TourId);
            pars.Add("CommUserId", tourcomment.CommUserId);
            pars.Add("CreatingTime", tourcomment.CreatingTime);
            pars.Add("Comment", tourcomment.Comment);
            
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateTourComment(TourComment tourcomment, DbTransaction trans)
        {
            tourcomment.CreatingTime = DateTime.Now;  
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourcomment.TourId);
            pars.Add("CommUserId", tourcomment.CommUserId);
            pars.Add("CreatingTime", tourcomment.CreatingTime);
            pars.Add("Comment", tourcomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavoriteByTourId(string TourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}