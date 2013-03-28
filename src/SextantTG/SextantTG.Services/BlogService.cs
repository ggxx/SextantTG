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
        private IPictureCommentDAL picCommentDal = null;

        public BlogService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            blogDal = DALFactory.CreateDAL<IBlogDAL>();
            picDal = DALFactory.CreateDAL<IPictureDAL>();
            picCommentDal = DALFactory.CreateDAL<IPictureCommentDAL>();
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

        public bool DeleteBlog(Blog blog, bool deletePictures, out string message)
        {
            List<Picture> oldPictures = new List<Picture>();
            List<PictureComment> oldComments = new List<PictureComment>();
            if (deletePictures)
            {
                oldPictures = picDal.GetPicturesByTourIdAndSubTourId(blog.TourId, blog.SubTourId);
                foreach (Picture pic in oldPictures)
                {
                    oldComments.AddRange(picCommentDal.GetPictureCommentsByPictureId(pic.PictureId));
                }
            }

            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        blogDal.DeleteBlog(blog, trans);
                        foreach (Picture pic in oldPictures)
                        {
                            picDal.DeletePicture(pic, trans);
                        }
                        foreach (PictureComment comm in oldComments)
                        {
                            picCommentDal.DeletePictureComment(comm, trans);
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

        public bool SaveBlob(Blog blog, out string message)
        {
            Blog oldBlog = blogDal.GetBlogByBlogId(blog.BlogId);

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
                            blogDal.UpdateBlogFromOld(blog, oldBlog, trans);
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
            this.picCommentDal.Dispose();

            this.dataContext = null;
            this.blogDal = null;
            this.picDal = null;
            this.picCommentDal = null;
        }

    }
}
