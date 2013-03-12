using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.ActiveRecord;

namespace SextantTG.Services
{
    public class UserService : IUserService
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public User Login(string loginName, string password)
        {
            throw new NotImplementedException();
        }

        public List<Permission> GetPermissionsByUserId(string userId)
        {
            throw new NotImplementedException();
        }


        public User GetUserByLoginName(string loginName)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool InsertUser(User user, string password, out string message)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user, out string message)
        {
            throw new NotImplementedException();
        }
    }
}
