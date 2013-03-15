using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class BlogDAL : IBlogDAL
    {
        private DbHelper dbHelper = null;

        public BlogDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public BlogDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        private static readonly string SELECT = "select * from stg_blog";
        private static readonly string SELECT___USER_ID = "select * from stg_blog where user_id = :UserId";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_blog where sights_id = :SightsId";
        private static readonly string SELECT___USER_ID__SIGHTS_ID = "select * from stg_blog where user_id = :UserId and sights_id = :SightsId";
        private static readonly string SELECT___TOUR_ID = "select * from stg_blog where tour_id = :TourId";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_blog where tour_id = :TourId and sub_tour_id = :SubTourId";
        private static readonly string SELECT___BLOG_ID = "select * from stg_blog where blog_id = :BlogId";

        private static readonly string INSERT = "insert into stg_blog(blog_id, user_id, tour_id, sub_tour_id, sights_id, title, content, creating_time) values(:BlogId, :UserId, :TourId, :SubTourId, :SightsId, :Title, :Content, :CreatingTime)";
        private static readonly string UPDATE = "update stg_blog set user_id = :UserId, tour_id = :TourId, sub_tour_id = :SubTourId, sights_id = :SightsId, title = :Title, content = :Content, creating_time = :CreatingTime where blog_id = :BlogId";
        private static readonly string DELETE = "delete from stg_blog where blog_id = :BlogId";

        private Blog BuildBlogByReader(DbDataReader r)
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

        public List<Blog> GetBlogs()
        {
            List<Blog> blogs = new List<Blog>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            List<Blog> blogs = new List<Blog>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public List<Blog> GetBlogsBySightsId(string sightsId)
        {
            List<Blog> blogs = new List<Blog>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId)
        {
            List<Blog> blogs = new List<Blog>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID__SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public List<Blog> GetBlogsByTourId(string tourId)
        {
            List<Blog> blogs = new List<Blog>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId)
        {
            List<Blog> blogs = new List<Blog>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID__SUB_TOUR_ID, pars))
            {
                while (r.Read())
                {
                    blogs.Add(BuildBlogByReader(r));
                }
            }
            return blogs;
        }

        public Blog GetBlogById(string blogId)
        {
            Blog blog = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blogId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___BLOG_ID, pars))
            {
                if (r.Read())
                {
                    blog = BuildBlogByReader(r);
                }
            }
            return blog;
        }

        public int InsertBlog(Blog blog, DbTransaction trans)
        {
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
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
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
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteBlogById(string blogId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blogId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper.Dispose();
        }
    }
}
