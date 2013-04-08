using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface IUserService : IBaseService
    {
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns>用户列表</returns>
        List<User> GetUsers();
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <param name="password">口令</param>
        /// <returns>若登录成功则返回用户信息，否则返回null</returns>
        User Login(string loginName, string password);
        
        /// <summary>
        /// 获取指定用户
        /// </summary>
        /// <param name="loginName">登录名</param>
        /// <returns>用户</returns>
        User GetUserByLoginName(string loginName);
        
        /// <summary>
        /// 获取指定用户
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>用户</returns>
        User GetUserByEmail(string email);
        
        /// <summary>
        /// 获取指定用户
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户</returns>
        User GetUserByUserId(string userId);
        
        /// <summary>
        /// 获取用户权限列表
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>权限列表</returns>
        List<Permission> GetPermissionsByUserId(string userId);
        
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="password">口令</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertUser(User user, string password, out string message);
        
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="user">用户</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateUser(User user, out string message);
        
        /// <summary>
        /// 获取用户收藏景点
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>收藏景点列表</returns>
        List<Favorite> GetFavoritesByUserId(string userId);
        
        /// <summary>
        /// 获取指定的收藏景点
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="sightsId">景点ID</param>
        /// <returns>收藏景点</returns>
        Favorite GetFavoriteByUserIdAndSightsId(string userId, string sightsId);

        /// <summary>
        /// 更新用户权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="permissions">权限列表</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdatePermissionsByUserId(string userId, List<Permission> permissions, out string message);
        
        /// <summary>
        /// 保存用户收藏景点
        /// </summary>
        /// <param name="favorite">收藏</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool SaveFavorite(Favorite favorite, out string message);
    }
}
