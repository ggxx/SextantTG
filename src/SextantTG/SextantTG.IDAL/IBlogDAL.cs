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

        Blog GetBlogByBlogId(string blogId);

        int InsertBlog(Blog blog, DbTransaction trans);

        //int UpdateBlog(Blog blog, DbTransaction trans);

        int UpdateBlogFromOld(Blog newBlog, Blog oldBlog, DbTransaction trans);

        int DeleteBlog(Blog blog, DbTransaction trans);

        //int DeleteBlogsByTourId(string tourId, DbTransaction trans);

        //int DeleteBlogsBySubTourId(string subTourId, DbTransaction trans);
    }
}
