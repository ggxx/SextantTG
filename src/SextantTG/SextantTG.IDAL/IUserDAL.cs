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
         /// <summary>
         /// 获取所有的用户
         /// </summary>
         /// <returns>用户列表</returns>
        List<User> GetUsers();
        
        /// <summary>
        /// 获取指定Email的用户
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>用户</returns>
        User GetUserByEmail(string email);
        
        /// <summary>
        /// 获取指定登录名的用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns>用户</returns>
        User GetUserByLoginName(string loginName);
        
        /// <summary>
        /// 获取指定登录名与口令的用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">口令</param>
        /// <returns>用户</returns>
        User GetUserByLoginNameAndPassword(string loginName, string password);
        
        /// <summary>
        /// 获取指定用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户</returns>
        User GetUserByUserId(string userId);

        /// <summary>
        /// 向数据库中插入一条用户记录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">登录口令</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertUser(User user, string password, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一条用户记录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateUser(User user, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一个用户口令
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="newPassword">新口令</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateUserPassword(User user, string newPassword, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条用户记录
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteUser(User user, DbTransaction trans);
    }
}
