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
    public class PermissionDAL : AbstractDAL<Permission>, IPermissionDAL
    {
        public PermissionDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override Permission BuildObjectByReader(DbDataReader r)
        {
            Permission permission = new Permission();
            permission.UserId = CustomTypeConverter.ToString(r["user_id"]);
            permission.PermissionType = CustomTypeConverter.ToInt32Null(r["permission_type"]);
            return permission;
        }

        private static readonly string SELECT___USER_ID = "select * from stg_permission where user_id = :UserId order by permission_type";        
        private static readonly string INSERT = "insert into stg_permission(user_id, permission_type) values(:UserId, :PermissionType)";
        private static readonly string DELETE = "delete from stg_permission where user_id = :UserId and permission_type = :PermissionType";
        //private static readonly string DELETE___USER_ID = "delete from stg_permission where user_id = :UserId";

        public List<Permission> GetPermissionsByUserId(string userID)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userID);
            return this.GetList(SELECT___USER_ID, pars);
        }


        public int InsertPermission(Permission permission, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", permission.UserId);
            pars.Add("PermissionType", permission.PermissionType);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int DeletePermission(Permission permission, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserID", permission.UserId);
            pars.Add("PermissionType", permission.PermissionType);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        //private int DeletePermissionsByUserId(string userId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("UserID", userId);
        //    return this.ExecuteNonQuery(trans, DELETE___USER_ID, pars);
        //}
    }
}
