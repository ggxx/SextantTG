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

        //private static readonly string SELECT = "select * from stg_tour_comment"; 
        private static readonly string SELECT___TOUR_ID = "select * from stg_tour_comment where tour_id = :TourId  order by creating_time desc";
        //private static readonly string SELECT___COMM_USER_ID = "select * from stg_tour_comment where comm_user_id = :CommUserId";

        private static readonly string INSERT = "insert into stg_tour_comment(comment_id, tour_id, comm_user_id, creating_time, comment) values(:CommentId, :TourId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_tour_comment set tour_id = :TourId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where comment_id = :CommentId";
        private static readonly string DELETE___COMMENT_ID = "delete from stg_tour_comment where comment_id = :CommentId";
        private static readonly string DELETE___TOUR_ID = "delete from stg_tour_comment where tour_id = :TourId";

        private TourComment BuildTourCommentByReader(DbDataReader r)
        {
            TourComment tourcomment = new TourComment();
            tourcomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            tourcomment.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            tourcomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            tourcomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            tourcomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return tourcomment;
        }

        //public List<TourComment> GetTourComments()
        //{
        //    List<TourComment> tourcomments = new List<TourComment>();
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
        //    {
        //        while (r.Read())
        //        {
        //            tourcomments.Add(BuildTourCommentByReader(r));
        //        }
        //    }
        //    return tourcomments;
        //}

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

        //public List<TourComment> GetTourCommentsByCommUserId(string CommUserId)
        //{
        //    List<TourComment> tourcomments = new List<TourComment>();
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CommUserId", CommUserId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
        //    {
        //        while (r.Read())
        //        {
        //            tourcomments.Add(BuildTourCommentByReader(r));
        //        }
        //    }
        //    return tourcomments;
        //}

        public int InsertTourComment(TourComment tourcomment, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(tourcomment.CommentId))
                tourcomment.CommentId = Util.StringHelper.CreateGuid();
            tourcomment.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourcomment.TourId);
            pars.Add("CommUserId", tourcomment.CommentUserId);
            pars.Add("CreatingTime", tourcomment.CreatingTime);
            pars.Add("Comment", tourcomment.Comment);
            pars.Add("CommentId", tourcomment.CommentId);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateTourComment(TourComment tourcomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourcomment.TourId);
            pars.Add("CommUserId", tourcomment.CommentUserId);
            pars.Add("CreatingTime", tourcomment.CreatingTime);
            pars.Add("Comment", tourcomment.Comment);
            pars.Add("CommentId", tourcomment.CommentId);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteTourCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", commentId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___COMMENT_ID, pars);
        }

        public int DeleteTourCommentByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___TOUR_ID, pars);
        }

        public void Dispose()
        {
            this.dbHelper.Dispose();
        }



    }
}
