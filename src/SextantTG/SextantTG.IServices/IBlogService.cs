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
        List<Blog> GetBlogsForUser(string userId);
        List<Blog> GetBlogsForSights(string sightsId);
        List<Blog> GetBlogsForSubTour(string tourId, string subTourId);

        bool CreateBlog(Blog blog, List<Picture> pics, string userId, out string message);
        bool UpdateBlog(Blog blog, List<Picture> pics, string userId, out string message);
        bool DeleteBlog(string blogId, bool deletePictures, bool deleteComments, out string message);
    }
}