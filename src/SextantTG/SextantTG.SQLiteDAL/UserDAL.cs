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
        private static readonly string SELECT___STATUS = "select * from stg_user where status = :Status";
        
        private static readonly string INSERT = "insert into stg_user(user_id, login_name, password, email, status) values(:UserId, :LoginName, :Password, :Email, :Status)";
        private static readonly string UPDATE = "update stg_user set user_id = :UserId, login_name = :Login_Name, password = :Password, status = :Status where user_id = :UserId" ;
        private static readonly string DELETE = "delete from stg_user where user_id = :UserId";

        private User BuildUserByReader(DbDataReader r)
        {
            User user = new User();
            user.UserId = TypeConverter.ToString(r["user_id"]);
            user.LoginName = TypeConverter.ToString(r["login_name"]);
            user.Password = TypeConverter.ToDateTimeNull(r["password"]);
            user.Email = TypeConverter.ToString(r["email"]);
            user.Status = TypeConverter.ToString(r["status"]);
           
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

        public List<User> GetUsersByUserId(string userId)
        {
            List<User> users = new List<User>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    users.Add(BuildUserByReader(r));
                }
            }
            return users;
        }

        public List<User> GetUsersByEmail(string Email)
        {
            List<User> users = new List<User>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Email", Email);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___EMAIL, pars))
            {
                while (r.Read())
                {
                    users.Add(BuildUserByReader(r));
                }
            }
            return users;
        }


        public List<User> GetUsersByLoginName(string LoginName)
        {
            List<User> users = new List<User>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", LoginName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___LOGIN_NAME, pars))
            {
                while (r.Read())
                {
                    users.Add(BuildUserByReader(r));
                }
            }
            return users;
        }

      
        public List<User> GetUsersByStatus(string Status)
        {
            List<User> users = new List<User>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Status", Status);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___STATUS, pars))
            {
                while (r.Read())
                {
                    users.Add(BuildUserByReader(r));
                }
            }
            return users;
        }

        public User GetUserById(string userId)
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
            User user = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("email", Email);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___EMAIL, pars))
            {
                if (r.Read())
                {
                    user = BuildUserByReader(r);
                }
            }
            return user;
        }

        public User GetUserByLoginName(string LoginName)
        {
            User user = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", loginname);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___LOGIN_NAME, pars))
            {
                if (r.Read())
                {
                    user = BuildUserByReader(r);
                }
            }
            return user;
        }

        public int InsertUser(User user, DbTransaction trans)
        {
            user.UserId = StringHelper.CreateGuid();
            
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("User", user.UserId);
            pars.Add("LoginName", user.LoginName);
            pars.Add("Password", user.Password);
            pars.Add("Email", user.Email);
            pars.Add("Status", user.Status);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateUser(User user, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("User", user.UserId);
            pars.Add("LoginName", user.LoginName);
            pars.Add("Password", user.Password);
            pars.Add("Email", user.Email);
            pars.Add("Status", user.Status);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteUserById(string userId, DbTransaction trans)
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
