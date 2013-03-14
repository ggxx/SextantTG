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
    public class UserDAL : IUserDAL
    {
        private DbHelper dbHelper = null;

        public UserDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public UserDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_user";
        private static readonly string SELECT___USER_ID = "select * from stg_user where user_id = :UserId";
        private static readonly string SELECT___LOGIN_NAME = "select * from stg_user where login_name = :LoginName";
        private static readonly string SELECT___EMAIL = "select * from stg_user where email = :Email";
        //private static readonly string SELECT___STATUS = "select * from stg_user where status = :Status";
        private static readonly string SELECT___LOGIN_NAME__PASSWORD = "select * from stg_user where login_name = :LoginName and password = :Password";
        
        private static readonly string INSERT = "insert into stg_user(user_id, login_name, password, email, status) values(:UserId, :LoginName, :Password, :Email, :Status)";
        private static readonly string UPDATE = "update stg_user set login_name = :LoginName, email = :Email, status = :Status where user_id = :UserId" ;
        private static readonly string DELETE = "delete from stg_user where user_id = :UserId";

        private User BuildUserByReader(DbDataReader r)
        {
            User user = new User();
            user.UserId = CustomTypeConverter.ToString(r["user_id"]);
            user.LoginName = CustomTypeConverter.ToString(r["login_name"]);
            //user.Password = TypeConverter.ToDateTimeNull(r["password"]);
            user.Email = CustomTypeConverter.ToString(r["email"]);
            user.Status = CustomTypeConverter.ToInt32Null(r["status"]);
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    users.Add(BuildUserByReader(r));
                }
            }
            return users;
        }

        public User GetUserByUserId(string userId)
        {
            User user = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                if (r.Read())
                {
                    user = BuildUserByReader(r);
                }
            }
            return user;
        }

        public User GetUserByEmail(string email)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("email", email);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___EMAIL, pars))
            {
                if (r.Read())
                {
                    return BuildUserByReader(r);
                }
            }
            return null;
        }

        public User GetUserByLoginName(string loginName)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", loginName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___LOGIN_NAME, pars))
            {
                if (r.Read())
                {
                    return BuildUserByReader(r);
                }
            }
            return null;
        }

        public User GetUserByLoginNameAndPassword(string loginName, string password)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", loginName);
            pars.Add("Password", password);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___LOGIN_NAME__PASSWORD, pars))
            {
                if (r.Read())
                {
                    return BuildUserByReader(r);
                }
            }
            return null;
        }

        public int InsertUser(User user, string password, DbTransaction trans)
        {
            user.UserId = StringHelper.CreateGuid();
            
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", user.UserId);
            pars.Add("LoginName", user.LoginName);
            pars.Add("Password", password);
            pars.Add("Email", user.Email);
            pars.Add("Status", user.Status);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateUser(User user, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", user.UserId);
            pars.Add("LoginName", user.LoginName);
            //pars.Add("Password", user.Password);
            pars.Add("Email", user.Email);
            pars.Add("Status", user.Status);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteUserByUserId(string userId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
