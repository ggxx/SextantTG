using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using SextantTG.IDAL;
using System.Data.Common;

namespace SextantTG.Services
{
    public class UserService : IUserService
    {
        private IDataContext dataContext = null;
        private IUserDAL userDal = null;
        private IPermissionDAL permissionDal = null;

        public UserService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            userDal = DALFactory.CreateDAL<IUserDAL>();
            permissionDal = DALFactory.CreateDAL<IPermissionDAL>();
        }

        public void Dispose()
        {
            dataContext = null;
            userDal = null;
            permissionDal = null;
        }

        public User Login(string loginName, string password)
        {
            password = Util.StringHelper.GetMd5Hash(password);
            return userDal.GetUserByLoginNameAndPassword(loginName, password);
        }

        public List<Permission> GetPermissionsByUserId(string userId)
        {
            return permissionDal.GetPermissionsByUserId(userId);
        }

        public User GetUserByLoginName(string loginName)
        {
            return userDal.GetUserByLoginName(loginName);
        }

        public User GetUserByEmail(string email)
        {
            return userDal.GetUserByEmail(email);
        }

        public List<User> GetUsers()
        {
            return userDal.GetUsers();
        }

        public bool InsertUser(User user, string password, out string message)
        {
            password = Util.StringHelper.GetMd5Hash(password);
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        user.Status = 0;
                        userDal.InsertUser(user, password, trans);
                        trans.Commit();
                        message = "";
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateUser(User user, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        userDal.UpdateUser(user, trans);
                        trans.Commit();
                        message = "";
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdatePermissionsByUserId(string userId, List<Permission> permissions, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        permissionDal.DeletePermissionsByUserId(userId, trans);
                        foreach (Permission p in permissions)
                        {
                            permissionDal.InsertPermission(p, trans);
                        }
                        trans.Commit();
                        message = "";
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }
    }
}
