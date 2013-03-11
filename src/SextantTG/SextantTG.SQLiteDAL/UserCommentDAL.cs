using SextantTG.IDAL;
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
    public class UserCommentDAL : IUserCommentDAL
    {
        private DbHelper dbHelper = null;

        public UserCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public UserCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_usercomment";
        private static readonly string SELECT___USER_ID = "select * from stg_usercomment where user_id = :UserId";
        private static readonly string SELECT___COMM_USER_ID = "select * from stg_usercomment where comm_user_id = :CommUserId";
                        
        private static readonly string INSERT = "insert into stg_usercomment(user_id, comm_user_id, creating_time, comment) values(:UserId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_usercomment set user_id = :UserId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where user_id = :UserId" ;
        private static readonly string DELETE = "delete from stg_usercomment where user_id = :UserId";

        private UserComment BuildUserCommentByReader(DbDataReader r)
        {
            UserComment usercomment = new UserComment();
            usercomment.UserId = TypeConverter.ToString(r["user_id"]);
            usercomment.CommUserId = TypeConverter.ToString(r["comm_user_id"]);
            usercomment.CreatingtTime = TypeConverter.ToString(r["creating_time"]);
            usercomment.Comment = TypeConverter.ToDateTimeNull(r["comment"]);           
           
            return usercomment;
        }

        public List<UserComment> GetUserComments()
        {
            List<UserComment> usercomments = new List<UserComment>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    usercomments.Add(BuildUserCommentByReader(r));
                }
            }
            return usercomments;
        }

       
        public List<UserComment> GetUserCommentsByUserId(string UserId)
        {
            List<UserComment> usercomments = new List<UserComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    usercomments.Add(BuildUserCommentByReader(r));
                }
            }
            return usercomments;
        }


        public List<UserComment> GetUserCommentsByCommUserId(string CommUserId)
        {
            List<UserComment> usercomments = new List<UserComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                while (r.Read())
                {
                    usercomments.Add(BuildUserCommentByReader(r));
                }
            }
            return usercomments;
        }

      
       public UserComment GetUserCommentByUserId(string UserId)
        {
            UserComment usercomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                if (r.Read())
                {
                    usercomment = BuildUserCommentByReader(r);
                }
            }
            return usercomment;
        }

        public UserComment GetUserCommentByCommUserId(string CommUserId)
        {
            UserComment usercomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                if (r.Read())
                {
                    usercomment = BuildUserCommentByReader(r);
                }
            }
            return usercomment;
        }

      
        public int InsertUserComment(UserComment usercomment, DbTransaction trans)
        {
            usercomment.CreatingTime = DateTime.Now;         
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", usercomment.UserId);
            pars.Add("CommUserId", usercomment.CommUserId);
            pars.Add("CreatingTime", usercomment.CreatingTime);
            pars.Add("Comment", usercomment.Comment);
            
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateUserComment(UserComment usercomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", usercomment.UserId);
            pars.Add("CommUserId", usercomment.CommUserId);
            pars.Add("CreatingTime", usercomment.CreatingTime);
            pars.Add("Comment", usercomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavoriteByUserId(string UserId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
