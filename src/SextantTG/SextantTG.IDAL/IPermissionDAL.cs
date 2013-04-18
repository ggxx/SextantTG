using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IPermissionDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定用户的权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>权限列表</returns>
        List<Permission> GetPermissionsByUserId(string userId);

        /// <summary>
        /// 向数据库中插入一条用户权限
        /// </summary>
        /// <param name="permission">用户权限</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertPermission(Permission permission, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条用户权限
        /// </summary>
        /// <param name="permission">用户权限</param>
        /// <param name="trans"></param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeletePermission(Permission permission, DbTransaction trans);
        
    }
}
