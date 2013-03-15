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
        List<Blog> GetBlogs();

        List<Blog> GetBlogsByUserId(string userId);

        List<Blog> GetBlogsBySightsId(string sightsId);

        List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId);

        List<Blog> GetBlogsByTourId(string tourId);

        List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId);

        Blog GetBlogById(string blogId);

        int InsertBlog(Blog blog, DbTransaction trans);

        int UpdateBlog(Blog blog, DbTransaction trans);

        int DeleteBlogById(string blogId, DbTransaction trans);

        
    }
}
