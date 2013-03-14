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
    public class PermissionDAL : IPermissionDAL
    {
        private DbHelper dbHelper = null;

        public PermissionDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public PermissionDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        //private static readonly string SELECT = "select * from stg_permission";
        private static readonly string SELECT___USER_ID = "select * from stg_permission where user_id = :UserId";        
        private static readonly string INSERT = "insert into stg_permission(user_id, permission_type) values(:UserId, :PermissionType)";
        //private static readonly string UPDATE = "update stg_permission set Permission_type = :PermissionType where user_id = :UserId";
        private static readonly string DELETE___USER_ID = "delete from stg_permission where user_id = :UserId";

        private Permission BuildPermissionByReader(DbDataReader r)
        {
            Permission permission = new Permission();
            permission.UserId = TypeConverter.ToString(r["user_id"]);
            permission.PermissionType = TypeConverter.ToInt32Null(r["permission_type"]);          
            return permission;
        }

        public List<Permission> GetPermissionsByUserId(string userID)
        {
            List<Permission> permission = new List<Permission>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userID);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID , pars))
            {
                while (r.Read())
                {
                    permission.Add(BuildPermissionByReader(r));
                }
            }
            return permission;
        }


        public int InsertPermission(Permission permission, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", permission.UserId);
            pars.Add("PermissionType", permission.PermissionType);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int DeletePermissionsByUserId(string userId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", userId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___USER_ID, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
