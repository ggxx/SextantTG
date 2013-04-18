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
using SextantTG.PSAop;

namespace SextantTG.SQLiteDAL
{
    [MethodAspect]
    public class TourCommentDAL : AbstractDAL<TourComment>, ITourCommentDAL
    {

        public TourCommentDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override TourComment BuildObjectByReader(DbDataReader r)
        {
            TourComment tourcomment = new TourComment();
            tourcomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            tourcomment.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            tourcomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            tourcomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            tourcomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return tourcomment;
        }

        private static readonly string SELECT___TOUR_ID = "select * from stg_tour_comment where tour_id = :TourId  order by creating_time desc";
        private static readonly string INSERT = "insert into stg_tour_comment(comment_id, tour_id, comm_user_id, creating_time, comment) values(:CommentId, :TourId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_tour_comment set tour_id = :TourId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where comment_id = :CommentId";
        private static readonly string DELETE = "delete from stg_tour_comment where comment_id = :CommentId";
        //private static readonly string DELETE___TOUR_ID = "delete from stg_tour_comment where tour_id = :TourId";

        public List<TourComment> GetTourCommentsByTourId(string TourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", TourId);
            return this.GetList(SELECT___TOUR_ID, pars);
        }

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
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateTourComment(TourComment tourcomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourcomment.TourId);
            pars.Add("CommUserId", tourcomment.CommentUserId);
            pars.Add("CreatingTime", tourcomment.CreatingTime);
            pars.Add("Comment", tourcomment.Comment);
            pars.Add("CommentId", tourcomment.CommentId);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteTourCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", commentId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        public int DeleteTourComment(TourComment comment, DbTransaction trans)
        {
            return this.DeleteTourCommentByTourId(comment.CommentId, trans);
        }

        private int DeleteTourCommentByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
