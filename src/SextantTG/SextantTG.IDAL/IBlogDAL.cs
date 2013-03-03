using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IBlogDAL
    {
        List<Blog> GetBlogs();
        List<Blog> GetBlogsByUserId(string userId);
        List<Blog> GetBlogsBySightsId(string sightsId);
        List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId);
        Blog GetBlogById(string blogId);

        bool CreateBlog(Blog blog, DbTransaction trans);
        bool UpdateBlog(Blog blog, DbTransaction trans);
        bool DeleteBlogById(string blogId, DbTransaction trans);
    }
}
