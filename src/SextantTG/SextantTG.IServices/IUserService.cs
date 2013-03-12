using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface IUserService : IBaseService
    {
        List<User> GetUsers();
        User Login(string loginName, string password);
        User GetUserByLoginName(string loginName);
        User GetUserByEmail(string email);
        List<Permission> GetPermissionsByUserId(string userId);
        bool InsertUser(User user, string password, out string message);
        bool UpdateUser(User user, out string message);

        bool UpdatePermissionsByUserId(string userId, List<Permission> permissions, out string message);
    }
}
