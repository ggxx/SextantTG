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
        List<User> GetUsers();
        User GetUserByEmail(string email);
        User GetUserByLoginName(string loginName);
        User GetUserByLoginNameAndPassword(string loginName, string password);
        User GetUserByUserId(string userId);

        int InsertUser(User user, string password, DbTransaction trans);
        int UpdateUser(User user, DbTransaction trans);
        int DeleteUser(User user, DbTransaction trans);
    }
}
