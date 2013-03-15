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
        List<Blog> GetBlogsByUserId(string userId);
        List<Blog> GetBlogsBySightsId(string sightsId);
        List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId);
        List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId);
        Blog GetBlogByBlogId(string blogId);
        List<Blog> GetBlogsByTourId(string tourId);

        //bool CreateBlog(Blog blog, List<Picture> pics, string userId, out string message);
        //bool UpdateBlog(Blog blog, List<Picture> pics, string userId, out string message);
        bool DeleteBlog(string blogId, bool deletePictures, bool deleteComments, out string message);
        bool SaveBlob(Blog blog, out string message);
    }
}