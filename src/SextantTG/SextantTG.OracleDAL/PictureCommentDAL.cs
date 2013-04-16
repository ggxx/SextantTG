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

namespace SextantTG.OracleDAL
{
    [MethodAspect]
    public class PictureCommentDAL : AbstractDAL<PictureComment>, IPictureCommentDAL
    {
        public PictureCommentDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override PictureComment BuildObjectByReader(DbDataReader r)
        {
            PictureComment picturecomment = new PictureComment();
            picturecomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            picturecomment.PictureId = CustomTypeConverter.ToString(r["picture_id"]);
            picturecomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            picturecomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            picturecomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return picturecomment;
        }

        private static readonly string SELECT___PICTURE_ID = "select * from stg_picture_comment where picture_id = :PictureId order by creating_time desc";
        private static readonly string INSERT = "insert into stg_picture_comment(comment_id, picture_id, comm_user_id, creating_time, comment) values(:CommentId, :PictureId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_picture_comment set picture_id = :PictureId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where picture_id = :PictureId";
        private static readonly string DELETE = "delete from stg_picture_comment where comment_id = :CommentId";

        public List<PictureComment> GetPictureCommentsByPictureId(string pictureId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            return this.GetList(SELECT___PICTURE_ID, pars);
        }

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
            pars.Add("CommentId", pictureComment.CommentId);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdatePictureComment(PictureComment pictureComment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureComment.PictureId);
            pars.Add("CommUserId", pictureComment.CommentUserId);
            pars.Add("CreatingTime", pictureComment.CreatingTime);
            pars.Add("Comment", pictureComment.Comment);
            pars.Add("CommentId", pictureComment.CommentId);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeletePictureComment(PictureComment comment, DbTransaction trans)
        {
            return DeletePictureCommentByCommentId(comment.CommentId, trans);
        }

        private int DeletePictureCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", commentId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
