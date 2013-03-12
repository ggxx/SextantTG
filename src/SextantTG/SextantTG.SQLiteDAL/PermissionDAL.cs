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
        
        private static readonly string SELECT = "select * from stg_permission";
        private static readonly string SELECT___USER_ID = "select * from stg_permission where user_id = :UserId";        
        private static readonly string INSERT = "insert into stg_permission(User_id, Permission_type) values(:UserId,:PermissionType)";
        private static readonly string UPDATE = "update stg_permission set user_id = :UserId, Permission_type = :PermissionType where user_id = :UserId";
        private static readonly string DELETE = "delete from stg_permission where user_id = :UserId";

        private Permission BuildPermissionByReader(DbDataReader r)
        {
            Permission permission = new Permission();
            Permission.UserId = TypeConverter.ToString(r["user_id"]);
            Permission.PermissionType = TypeConverter.ToString(r["permission_type"]);          
            return permission;
        }

        public List<Permission> GetPermission()
        {
            List<Permission> permission = new List<Permission>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    uermission.Add(BuildPermissionByReader(r));
                }
            }
            return uermission;
        }

        public List<Permission> GetPermissionByUserId(string userID)
        {
            List<Permission> permission = new List<Permission>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PermissionID", userID);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID , pars))
            {
                while (r.Read())
                {
                    permission.Add(BuildPermissionByReader(r));
                }
            }
            return permission;
        }

        
       

        

        public Permission GetPermissionById(string userId)
        {
            Permission permission = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PermissionID", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                if (r.Read())
                {
                    permission = BuildPermissionByReader(r);
                }
            }
            return permission;
        }

        public int InsertPermission(Permission permission, DbTransaction trans)
        {
            permission.userId = StringHelper.CreateGuid();
           
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", Permission.UserId);
            pars.Add("PermissionType", permission.PermissionType);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdatePermission(Permission permission, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", permission.UserId);
            pars.Add("PermissionType", permission.PermissionType);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeletePermissionByUserID(Permission permission, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", UserId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
