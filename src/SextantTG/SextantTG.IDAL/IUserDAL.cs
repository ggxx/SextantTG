using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IUserDAL : IBaseDAL
    {
        User GetUserByLoginNameAndPassword(string loginName, string password);
        User GetUserByUserId(string userId);

        int InsertUser(User user, DbTransaction trans);
        int UpdateUser(User user, DbTransaction trans);
        int DeleteUserByUserId(string userId, DbTransaction trans);
    }
}
