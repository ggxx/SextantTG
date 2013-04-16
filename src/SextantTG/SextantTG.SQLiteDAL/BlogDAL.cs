using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;
using SextantTG.PSAop;

namespace SextantTG.SQLiteDAL
{
    [MethodAspect]
    public class BlogDAL : AbstractDAL<Blog>, IBlogDAL
    {
        public BlogDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override Blog BuildObjectByReader(DbDataReader r)
        {
            Blog blog = new Blog();
            blog.BlogId = CustomTypeConverter.ToString(r["blog_id"]);
            blog.Title = CustomTypeConverter.ToString(r["title"]);
            blog.Content = CustomTypeConverter.ToString(r["content"]);
            blog.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            blog.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            blog.SubTourId = CustomTypeConverter.ToString(r["sub_tour_id"]);
            blog.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            blog.UserId = CustomTypeConverter.ToString(r["user_id"]);
            return blog;
        }

        private static readonly string SELECT = "select * from stg_blog order by creating_time desc";
        private static readonly string SELECT___USER_ID = "select * from stg_blog where user_id = :UserId order by creating_time desc";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_blog where sights_id = :SightsId order by creating_time desc";
        private static readonly string SELECT___USER_ID__SIGHTS_ID = "select * from stg_blog where user_id = :UserId and sights_id = :SightsId order by creating_time desc";
        private static readonly string SELECT___TOUR_ID = "select * from stg_blog where tour_id = :TourId order by creating_time desc";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_blog where tour_id = :TourId and sub_tour_id = :SubTourId order by creating_time desc";
        private static readonly string SELECT___BLOG_ID = "select * from stg_blog where blog_id = :BlogId order by creating_time desc";

        private static readonly string INSERT = "insert into stg_blog(blog_id, user_id, tour_id, sub_tour_id, sights_id, title, content, creating_time) values(:BlogId, :UserId, :TourId, :SubTourId, :SightsId, :Title, :Content, :CreatingTime)";
        private static readonly string UPDATE = "update stg_blog set user_id = :UserId, tour_id = :TourId, sub_tour_id = :SubTourId, sights_id = :SightsId, title = :Title, content = :Content, creating_time = :CreatingTime where blog_id = :BlogId";
        private static readonly string DELETE = "delete from stg_blog where blog_id = :BlogId";
        //private static readonly string DELETE___TOUR_ID = "delete from stg_blog where tour_id = :TourId";
        //private static readonly string DELETE___SUB_TOUR_ID = "delete from stg_blog where sub_tour_id = :SubTourId";

        public List<Blog> GetBlogs()
        {
            return this.GetList(SELECT, null);
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.GetList(SELECT___USER_ID, pars);
        }

        public List<Blog> GetBlogsBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___USER_ID__SIGHTS_ID, pars);
        }

        public List<Blog> GetBlogsByTourId(string tourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.GetList(SELECT___TOUR_ID, pars);
        }

        public List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            return this.GetList(SELECT___TOUR_ID__SUB_TOUR_ID, pars);
        }

        public Blog GetBlogByBlogId(string blogId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blogId);
            return this.GetObject(SELECT___BLOG_ID, pars);
        }

        public int InsertBlog(Blog blog, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(blog.BlogId))
                blog.BlogId = StringHelper.CreateGuid();
            blog.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blog.BlogId);
            pars.Add("UserId", blog.UserId);
            pars.Add("TourId", blog.TourId);
            pars.Add("SubTourId", blog.SubTourId);
            pars.Add("SightsId", blog.SightsId);
            pars.Add("Title", blog.Title);
            pars.Add("Content", blog.Content);
            pars.Add("CreatingTime", blog.CreatingTime);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateBlogFromOld(Blog newBlog, Blog oldBlog, DbTransaction trans)
        {
            Blog blog = (Blog)newBlog.Clone();
            blog.BlogId = oldBlog.BlogId;
            return this.UpdateBlog(blog, trans);
        }

        public int UpdateBlog(Blog blog, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blog.BlogId);
            pars.Add("UserId", blog.UserId);
            pars.Add("TourId", blog.TourId);
            pars.Add("SubTourId", blog.SubTourId);
            pars.Add("SightsId", blog.SightsId);
            pars.Add("Title", blog.Title);
            pars.Add("Content", blog.Content);
            pars.Add("CreatingTime", blog.CreatingTime);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteBlog(Blog blog, DbTransaction trans)
        {
            return DeleteBlogByBlogId(blog.BlogId, trans);
        }

        private int DeleteBlogByBlogId(string blogId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blogId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        //public int DeleteBlogsByTourId(string tourId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("TourId", tourId);
        //    return this.ExecuteNonQuery(trans, DELETE___TOUR_ID, pars);
        //}

        //public int DeleteBlogsBySubTourId(string subTourId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("SubTourId", subTourId);
        //    return this.ExecuteNonQuery(trans, DELETE___SUB_TOUR_ID, pars);
        //}
    }
}
