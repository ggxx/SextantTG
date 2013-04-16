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
    public class UserDAL : AbstractDAL<User>, IUserDAL
    {
        public UserDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override User BuildObjectByReader(DbDataReader r)
        {
            User user = new User();
            user.UserId = CustomTypeConverter.ToString(r["user_id"]);
            user.LoginName = CustomTypeConverter.ToString(r["login_name"]);
            user.Email = CustomTypeConverter.ToString(r["email"]);
            user.Status = CustomTypeConverter.ToInt32Null(r["status"]);
            return user;
        }

        private static readonly string SELECT = "select * from stg_user order by login_name";
        private static readonly string SELECT___USER_ID = "select * from stg_user where user_id = :UserId";
        private static readonly string SELECT___LOGIN_NAME = "select * from stg_user where login_name = :LoginName";
        private static readonly string SELECT___EMAIL = "select * from stg_user where email = :Email";
        private static readonly string SELECT___LOGIN_NAME__PASSWORD = "select * from stg_user where login_name = :LoginName and password = :Password";

        private static readonly string INSERT = "insert into stg_user(user_id, login_name, password, email, status) values(:UserId, :LoginName, :Password, :Email, :Status)";
        private static readonly string UPDATE = "update stg_user set login_name = :LoginName, email = :Email, status = :Status where user_id = :UserId";
        private static readonly string DELETE = "delete from stg_user where user_id = :UserId";
        private static readonly string UPDATE___PASSWORD = "update stg_user set password = :Password where user_id = :UserId";

        public List<User> GetUsers()
        {
            return this.GetList(SELECT, null);
        }

        public User GetUserByUserId(string userId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.GetObject(SELECT___USER_ID, pars);
        }

        public User GetUserByEmail(string email)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Email", email);
            return this.GetObject(SELECT___EMAIL, pars);
        }

        public User GetUserByLoginName(string loginName)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", loginName);
            return this.GetObject(SELECT___LOGIN_NAME, pars);
        }

        public User GetUserByLoginNameAndPassword(string loginName, string password)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("LoginName", loginName);
            pars.Add("Password", password);
            return this.GetObject(SELECT___LOGIN_NAME__PASSWORD, pars);
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
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateUser(User user, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", user.UserId);
            pars.Add("LoginName", user.LoginName);
            pars.Add("Email", user.Email);
            pars.Add("Status", user.Status);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteUser(User user, DbTransaction trans)
        {
            return this.DeleteUserByUserId(user.UserId, trans);
        }

        private int DeleteUserByUserId(string userId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        public int UpdateUserPassword(User user, string newPassword, DbTransaction trans)
        {
            return this.UpdatePasswordByUserId(user.UserId, newPassword, trans);
        }

        private int UpdatePasswordByUserId(string userId, string newPassword, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("Password", newPassword);
            pars.Add("UserId", userId);
            return this.ExecuteNonQuery(trans, UPDATE___PASSWORD, pars);
        }
    }
}
