using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantGT.Util;

namespace SextantTG.SQLiteDAL
{
    public class BlogDAL : IBlogDAL
    {
        private DbHelper dbHelper = null;

        public BlogDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_blog";
        private static readonly string SELECT___USER_ID = "select * from stg_blog where user_id = :UserId";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_blog where sights_id = :SightsId";
        private static readonly string SELECT___USER_ID__SIGHTS_ID = "select * from stg_blog where user_id = :UserId and sights_id = :SightsId";
        
        
        private static readonly string SELECT___BLOG_ID = "select * from stg_blog where blog_id = :BlogId";

        private static readonly string INSERT = "insert into stg_blog(blog_id) values(:blog_id, )";
        private static readonly string UPDATE = "update stg_blog set  where ";
        private static readonly string DELETE = "delete from stg_blog where blog_id = :BlogId";

        private Blog BuildBlogByReader(DbDataReader r)
        {
            Blog blog = new Blog();
            blog.BlogId = TypeConverter.ToString(r["blog_id"]);
            blog.Content = TypeConverter.ToString(r["content"]);
            blog.CreatingTime = TypeConverter.ToDateTimeNull(r["creating_time"]);
            blog.SightsId = TypeConverter.ToString(r["sights_id"]);
            blog.SubTourId = TypeConverter.ToString(r["sub_tour_id"]);
            blog.TourId = TypeConverter.ToString(r["tour_id"]);
            blog.UserId = TypeConverter.ToString(r["user_id"]);
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

        public bool CreateBlog(Blog blog, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public bool UpdateBlog(Blog blog, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBlogById(string blogId, DbTransaction trans)
        {
            throw new NotImplementedException();
        }
    }
}
