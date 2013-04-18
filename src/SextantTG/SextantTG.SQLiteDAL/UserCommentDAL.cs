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
    public class UserCommentDAL : AbstractDAL<UserComment>, IUserCommentDAL
    {
        public UserCommentDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override UserComment BuildObjectByReader(DbDataReader r)
        {
            UserComment usercomment = new UserComment();
            usercomment.CommentId = CustomTypeConverter.ToString(r["comment_id"]);
            usercomment.UserId = CustomTypeConverter.ToString(r["user_id"]);
            usercomment.CommentUserId = CustomTypeConverter.ToString(r["comm_user_id"]);
            usercomment.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            usercomment.Comment = CustomTypeConverter.ToString(r["comment"]);
            return usercomment;
        }

        private static readonly string SELECT___USER_ID = "select * from stg_user_comment where user_id = :UserId  order by creating_time desc";
        private static readonly string INSERT = "insert into stg_user_comment(comment_id, user_id, comm_user_id, creating_time, comment) values(:CommentId, :UserId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_user_comment set user_id = :UserId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where comment_id = :CommentId";
        private static readonly string DELETE = "delete from stg_user_comment where comment_id = :CommentId";


        public List<UserComment> GetUserCommentsByUserId(string UserId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            return this.GetList(SELECT___USER_ID, pars);
        }

        public int InsertUserComment(UserComment usercomment, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(usercomment.CommentId))
                usercomment.CommentId = Util.StringHelper.CreateGuid();
            usercomment.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", usercomment.UserId);
            pars.Add("CommUserId", usercomment.CommentUserId);
            pars.Add("CreatingTime", usercomment.CreatingTime);
            pars.Add("Comment", usercomment.Comment);
            pars.Add("CommentId", usercomment.CommentId);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateUserComment(UserComment usercomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", usercomment.UserId);
            pars.Add("CommUserId", usercomment.CommentUserId);
            pars.Add("CreatingTime", usercomment.CreatingTime);
            pars.Add("Comment", usercomment.Comment);
            pars.Add("CommentId", usercomment.CommentId);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteUserComment(UserComment comment, DbTransaction trans)
        {
            return this.DeleteUserCommentByCommentId(comment.CommentId, trans);
        }

        private int DeleteUserCommentByCommentId(string commentId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommentId", commentId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
