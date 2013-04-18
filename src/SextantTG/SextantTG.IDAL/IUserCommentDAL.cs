using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IUserCommentDAL : IBaseDAL
    {
        /// <summary>
        /// 获取针对指定用户的评论
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户评论列表</returns>
        List<UserComment> GetUserCommentsByUserId(string userId);

        /// <summary>
        /// 向数据库中插入一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertUserComment(UserComment comment, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateUserComment(UserComment comment, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条用户评论
        /// </summary>
        /// <param name="comment">用户评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteUserComment(UserComment comment, DbTransaction trans);
    }
}
