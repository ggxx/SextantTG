using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IBlogDAL : IBaseDAL
    {
        /// <summary>
        /// 获取全部日志
        /// </summary>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogs();

        /// <summary>
        /// 获取指定用户的日志
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByUserId(string userId);

        /// <summary>
        /// 获取指定景点的日志
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsBySightsId(string sightsId);

        /// <summary>
        /// 获取指定用户与景点的日志
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="sightsId">景点ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId);

        /// <summary>
        /// 获取指定旅行的日志
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByTourId(string tourId);

        /// <summary>
        /// 获取指定旅行中一次子旅行的日志
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <param name="subTourId">子旅行ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId);

        /// <summary>
        /// 获取指定日志
        /// </summary>
        /// <param name="blogId">日志ID</param>
        /// <returns>日志</returns>
        Blog GetBlogByBlogId(string blogId);

        /// <summary>
        /// 向数据库插入一篇日志
        /// </summary>
        /// <param name="blog">日志</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertBlog(Blog blog, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一篇日志
        /// </summary>
        /// <param name="newBlog">新的日志</param>
        /// <param name="oldBlog">旧的日志</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateBlogFromOld(Blog newBlog, Blog oldBlog, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条日志
        /// </summary>
        /// <param name="blog">日志</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteBlog(Blog blog, DbTransaction trans);
    }
}
