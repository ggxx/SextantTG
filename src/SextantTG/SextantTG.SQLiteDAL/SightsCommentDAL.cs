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
    public class SightsCommentDAL : ISightsCommentDAL
    {
        private DbHelper dbHelper = null;

        public SightsCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public SightsCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        //private static readonly string SELECT = "select * from stg_sightscomment";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sights_comment where sights_id = :SightsId";
        //private static readonly string SELECT___COMM_USER_ID = "select * from stg_sightscomment where comm_user_id = :CommUserId";

        private static readonly string INSERT = "insert into stg_sights_comment(comment_id, sights_id, comm_user_id, creating_time, comment) values(:CommentId, :SightsId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_sights_comment set sights_id = :SightsId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where comment_id = :CommentId";
        private static readonly string DELETE = "delete from stg_sights_comment where comment_id = :CommendId";

        private SightsComment BuildSightsCommentByReader(DbDataReader r)
        {
            SightsComment sightscomment = new SightsComment();
            sightscomment.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            sightscomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            sightscomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            sightscomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return sightscomment;
        }

        public List<SightsComment> GetSightsCommentsBySightsId(string SightsId)
        {
            List<SightsComment> sightscomments = new List<SightsComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    sightscomments.Add(BuildSightsCommentByReader(r));
                }
            }
            return sightscomments;
        }

        //public List<SightsComment> GetSightsCommentsByCommUserId(string CommUserId)
        //{
        //    List<SightsComment> sightscomments = new List<SightsComment>();
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CommUserId", CommUserId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
        //    {
        //        while (r.Read())
        //        {
        //            sightscomments.Add(BuildSightsCommentByReader(r));
        //        }
        //    }
        //    return sightscomments;
        //}

        //public SightsComment GetSightsCommentBySightsId(string SightsId)
        //{
        //    SightsComment sightscomment = null;
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("SightsId", SightsId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
        //    {
        //        if (r.Read())
        //        {
        //            sightscomment = BuildSightsCommentByReader(r);
        //        }
        //    }
        //    return sightscomment;
        //}

        //public SightsComment GetSightsCommentByCommUserId(string CommUserId)
        //{
        //    SightsComment sightscomment = null;
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CommUserId", CommUserId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
        //    {
        //        if (r.Read())
        //        {
        //            sightscomment = BuildSightsCommentByReader(r);
        //        }
        //    }
        //    return sightscomment;
        //}

        public int InsertSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            sightscomment.CommentId = Util.StringHelper.CreateGuid();
            sightscomment.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", sightscomment.CommentId);
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommentUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", sightscomment.CommentId);
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommentUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSightsCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommendId", commentId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
