using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.IDAL;
using SextantTG.ActiveRecord;
using System.Data.Common;

namespace SextantTG.Services
{
    public class CommentService : ICommentService
    {
        private IDataContext dataContext = null;
        private IPictureCommentDAL picCommentDal = null;
        private ISightsCommentDAL sigCommentDal = null;
        private ITourCommentDAL tourCommentDal = null;
        private IUserCommentDAL userCommentDal = null;

        public CommentService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            picCommentDal = DALFactory.CreateDAL<IPictureCommentDAL>();
            sigCommentDal = DALFactory.CreateDAL<ISightsCommentDAL>();
            tourCommentDal = DALFactory.CreateDAL<ITourCommentDAL>();
            userCommentDal = DALFactory.CreateDAL<IUserCommentDAL>();
        }

        public void Dispose()
        {
            dataContext.Dispose();
            picCommentDal.Dispose();
            sigCommentDal.Dispose();
            tourCommentDal.Dispose();
            userCommentDal.Dispose();

            dataContext = null;
            userCommentDal = null;
            tourCommentDal = null;
            sigCommentDal = null;
            picCommentDal = null;
        }

        public List<PictureComment> GetPictureCommentsByPictureId(string pictureId)
        {
            return picCommentDal.GetPictureCommentsByPictureId(pictureId);
        }

        public List<SightsComment> GetSightsCommentsBySightsId(string sightsId)
        {
            return sigCommentDal.GetSightsCommentsBySightsId(sightsId);
        }

        public List<TourComment> GetTourCommentsByTourId(string tourId)
        {
            return tourCommentDal.GetTourCommentsByTourId(tourId);
        }

        public List<UserComment> GetUserCommentsByUserId(string userId)
        {
            return userCommentDal.GetUserCommentsByUserId(userId);
        }

        public bool InsertPictureComment(PictureComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        picCommentDal.InsertPictureComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdatePictureComment(PictureComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        picCommentDal.UpdatePictureComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeletePictureCommentByCommentId(string commentId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        picCommentDal.DeletePictureCommentByCommentId(commentId, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool InsertSightsComment(SightsComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sigCommentDal.InsertSightsComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateSightsComment(SightsComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sigCommentDal.UpdateSightsComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteSightsCommentByCommentId(string commentId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sigCommentDal.DeleteSightsCommentByCommentId(commentId, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool InsertTourComment(TourComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourCommentDal.InsertTourComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateTourComment(TourComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourCommentDal.UpdateTourComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteTourCommentByCommentId(string commentId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourCommentDal.DeleteTourCommentByCommentId(commentId, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool InsertUserComment(UserComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        userCommentDal.InsertUserComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateUserComment(UserComment comment, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        userCommentDal.UpdateUserComment(comment, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteUserCommentByCommentId(string commentId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        userCommentDal.DeleteUserCommentByCommentId(commentId, trans);
                        trans.Commit();
                        message = string.Empty;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

    }
}
