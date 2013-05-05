using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.IServices
{
    /// <summary>
    /// 日志业务操作的接口
    /// </summary>
    public interface IBlogService : IBaseService
    {
        /// <summary>
        /// 获取指定用户的所有日志
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByUserId(string userId);
        
        /// <summary>
        /// 获取指定景点的所有日志
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsBySightsId(string sightsId);
        
        /// <summary>
        /// 获取指定用户与指定景点的所有日志
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="sightsId">景点ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId);
        
        /// <summary>
        /// 获取指定旅行的所有相关日志
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
        /// 获取指定旅行的所有相关日志
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>日志列表</returns>
        List<Blog> GetBlogsByTourId(string tourId);
        
        /// <summary>
        /// 删除指定日志
        /// </summary>
        /// <param name="blog">日志</param>
        /// <param name="deletePictures">是否删除与该日志相关的图片</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteBlog(Blog blog, bool deletePictures, out string message);
        
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="blog">日志</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool SaveBlog(Blog blog, out string message);
    }
}