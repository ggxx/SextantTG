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
    public class SightsCommentDAL : AbstractDAL<SightsComment>, ISightsCommentDAL
    {
        public SightsCommentDAL() { }

        protected override SightsComment BuildObjectByReader(DbDataReader r)
        {
            SightsComment sightscomment = new SightsComment();
            sightscomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            sightscomment.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            sightscomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            sightscomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            sightscomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return sightscomment;
        }

        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sights_comment where sights_id = :SightsId  order by creating_time desc";
        private static readonly string INSERT = "insert into stg_sights_comment(comment_id, sights_id, comm_user_id, creating_time, comment) values(:CommentId, :SightsId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_sights_comment set sights_id = :SightsId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where comment_id = :CommentId";
        private static readonly string DELETE = "delete from stg_sights_comment where comment_id = :CommendId";


        public List<SightsComment> GetSightsCommentsBySightsId(string SightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public int InsertSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(sightscomment.CommentId))
                sightscomment.CommentId = Util.StringHelper.CreateGuid();
            sightscomment.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", sightscomment.CommentId);
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommentUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", sightscomment.CommentId);
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommentUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSightsCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommendId", commentId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }


    }
}
