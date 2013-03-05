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
        List<Permission> GetPermissionsByUserId(string userId);

        int InsertPermission(Permission permission, DbTransaction trans);
        //int UpdatePermission(Permission permission, DbTransaction trans);
        int DeletePermissionByUserId(Permission permission, DbTransaction trans);
    }
}
