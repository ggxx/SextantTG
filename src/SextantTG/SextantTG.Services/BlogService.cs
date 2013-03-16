using SextantTG.IDAL;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;


namespace SextantTG.Services
{
    public class BlogService : IBlogService
    {
        private IDataContext dataContext = null;
        private IBlogDAL blogDal = null;
        private IPictureDAL picDal = null;

        public BlogService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            blogDal = DALFactory.CreateDAL<IBlogDAL>();
            picDal = DALFactory.CreateDAL<IPictureDAL>();
        }

        public List<Blog> GetBlogsByUserId(string userId)
        {
            return blogDal.GetBlogsByUserId(userId);
        }

        public List<Blog> GetBlogsBySightsId(string sightsId)
        {
            return blogDal.GetBlogsBySightsId(sightsId);
        }

        public List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId)
        {
            return blogDal.GetBlogsByUserIdAndSightsId(userId, sightsId);
        }

        public List<Blog> GetBlogsByTourId(string tourId)
        {
            return blogDal.GetBlogsByTourId(tourId);
        }

        public List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId)
        {
            return blogDal.GetBlogsByTourIdAndSubTourId(tourId, subTourId);
        }

        public Blog GetBlogByBlogId(string blogId)
        {
            return blogDal.GetBlogByBlogId(blogId);
        }

        //public bool CreateBlog(Blog blog, List<Picture> pics, string userId, out string message)
        //{
        //    using (DbConnection conn = dataContext.GetConnection())
        //    {
        //        conn.Open();
        //        using (DbTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                blogDal.InsertBlog(blog, trans);
        //                foreach (Picture pic in pics)
        //                {
        //                    picDal.InsertPicture(pic, trans);
        //                }
        //                trans.Commit();
        //                message = string.Empty;
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                message = ex.Message;
        //                return false;
        //            }
        //        }
        //    }

        //}

        //public bool UpdateBlog(Blog blog, List<Picture> pics, string userId, out string message)
        //{
        //    using (DbConnection conn = dataContext.GetConnection())
        //    {
        //        conn.Open();
        //        using (DbTransaction trans = conn.BeginTransaction())
        //        {
        //            try
        //            {
        //                blogDal.UpdateBlog(blog, trans);
        //                foreach (Picture pic in pics)
        //                {
        //                    picDal.InsertPicture(pic, trans);
        //                }

        //                trans.Commit();
        //                message = string.Empty;
        //                return true;
        //            }
        //            catch (Exception ex)
        //            {
        //                trans.Rollback();
        //                message = ex.Message;
        //                return false;
        //            }
        //        }
        //    }
        //}

        public bool DeleteBlog(string blogId, bool deletePictures, bool deleteComments, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        blogDal.DeleteBlogByBlogId(blogId, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        message = ex.Message;
                        return false;
                    }
                }
            }
        }

        public bool SaveBlob(Blog blog, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(blog.BlogId))
                        {
                            blogDal.InsertBlog(blog, trans);
                        }
                        else
                        {
                            blogDal.UpdateBlog(blog, trans);
                        }
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        message = ex.Message;
                        return false;
                    }
                }
            }
        }

        public void Dispose()
        {
            this.dataContext.Dispose();
            this.blogDal.Dispose();
            this.picDal.Dispose();

            this.dataContext = null;
            this.blogDal = null;
            this.picDal = null;
        }

    }
}
