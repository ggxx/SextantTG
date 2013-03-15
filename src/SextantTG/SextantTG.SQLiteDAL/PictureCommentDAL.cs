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
    public class PictureCommentDAL : IPictureCommentDAL
    {
        private DbHelper dbHelper = null;

        public PictureCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public PictureCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        //private static readonly string SELECT = "select * from stg_picture_comment";
        private static readonly string SELECT___PICTURE_ID = "select * from stg_picture_comment where picture_id = :PictureId";
        //private static readonly string SELECT___COMM_USER_ID = "select * from stg_picture_comment where comm_user_id = :CommUserId";

        private static readonly string INSERT = "insert into stg_picture_comment(comment_id, picture_id, comm_user_id, creating_time, comment) values(:CommentId, :PictureId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_picture_comment set picture_id = :PictureId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where picture_id = :PictureId";
        private static readonly string DELETE = "delete from stg_picture_comment where comment_id = :CommentId";

        private PictureComment BuildPictureCommentByReader(DbDataReader r)
        {
            PictureComment picturecomment = new PictureComment();
            picturecomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            picturecomment.PictureId = CustomTypeConverter.ToString(r["picture_id"]);
            picturecomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            picturecomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            picturecomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return picturecomment;
        }

        //public List<PictureComment> GetPictureComments()
        //{
        //    List<PictureComment> picturecomments = new List<PictureComment>();
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
        //    {
        //        while (r.Read())
        //        {
        //            picturecomments.Add(BuildPictureCommentByReader(r));
        //        }
        //    }
        //    return picturecomments;
        //}


        public List<PictureComment> GetPictureCommentsByPictureId(string pictureId)
        {
            List<PictureComment> pictureComments = new List<PictureComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                while (r.Read())
                {
                    pictureComments.Add(BuildPictureCommentByReader(r));
                }
            }
            return pictureComments;
        }


        //public List<PictureComment> GetPictureCommentsByCommUserId(string CommUserId)
        //{
        //    List<PictureComment> picturecomments = new List<PictureComment>();
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CommUserId", CommUserId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
        //    {
        //        while (r.Read())
        //        {
        //            picturecomments.Add(BuildPictureCommentByReader(r));
        //        }
        //    }
        //    return picturecomments;
        //}


        //public PictureComment GetPictureCommentByPictureId(string PictureId)
        //{
        //    PictureComment picturecomment = null;
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("PictureId", PictureId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
        //    {
        //        if (r.Read())
        //        {
        //            picturecomment = BuildPictureCommentByReader(r);
        //        }
        //    }
        //    return picturecomment;
        //}

        //public PictureComment GetPictureCommentByCommUserId(string CommUserId)
        //{
        //    PictureComment picturecomment = null;
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CommUserId", CommUserId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
        //    {
        //        if (r.Read())
        //        {
        //            picturecomment = BuildPictureCommentByReader(r);
        //        }
        //    }
        //    return picturecomment;
        //}


        public int InsertPictureComment(PictureComment pictureComment, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(pictureComment.CommentId))
                pictureComment.CommentId = Util.StringHelper.CreateGuid();
            pictureComment.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureComment.PictureId);
            pars.Add("CommUserId", pictureComment.CommentUserId);
            pars.Add("CreatingTime", pictureComment.CreatingTime);
            pars.Add("Comment", pictureComment.Comment);

            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdatePictureComment(PictureComment pictureComment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureComment.PictureId);
            pars.Add("CommUserId", pictureComment.CommentUserId);
            pars.Add("CreatingTime", pictureComment.CreatingTime);
            pars.Add("Comment", pictureComment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeletePictureCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", commentId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper.Dispose();
        }
    }
}
