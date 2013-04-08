using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using System.Data.Common;
using SextantTG.IDAL;
using SextantTG.ActiveRecord;

namespace SextantTG.Services
{
    public class TourService : ITourService
    {
        private IDataContext dataContext = null;
        private ITourDAL tourDal = null;
        private ITourCommentDAL tourCommentDal = null;
        private IPictureCommentDAL pictureCommentDal = null;
        private ISubTourDAL subtourDal = null;
        private IPictureDAL pictureDal = null;
        private IBlogDAL blogDal = null;

        public TourService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            tourDal = DALFactory.CreateDAL<ITourDAL>();
            tourCommentDal = DALFactory.CreateDAL<ITourCommentDAL>();
            pictureCommentDal = DALFactory.CreateDAL<IPictureCommentDAL>();
            subtourDal = DALFactory.CreateDAL<ISubTourDAL>();
            pictureDal = DALFactory.CreateDAL<IPictureDAL>();
            blogDal = DALFactory.CreateDAL<IBlogDAL>();
        }

        public List<Tour> GetToursByUserId(string userId)
        {
            return tourDal.GetToursByUserId(userId);
        }

        public Tour GetTourByTourId(string tourId)
        {
            return tourDal.GetTourByTourId(tourId);
        }

        public List<Tour> GetToursBySightsId(string sightsId)
        {
            return tourDal.GetToursBySightsId(sightsId);
        }

        public List<Tour> GetToursByDate(DateTime date)
        {
            return tourDal.GetToursByDate(date);
        }

        public List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date)
        {
            return tourDal.GetToursBySightsIdAndDate(sightsId, date);
        }

        public bool DeleteTour(Tour tour, bool deletePictures, out string message)
        {
            List<TourComment> oldComments = tourCommentDal.GetTourCommentsByTourId(tour.TourId);
            List<SubTour> oldSubTours = subtourDal.GetSubToursByTourId(tour.TourId);
            List<Blog> oldBlogs = new List<Blog>();
            List<Picture> oldPictures = new List<Picture>();
            List<PictureComment> oldPicComments = new List<PictureComment>();

            if (deletePictures)
            {
                oldBlogs.AddRange(blogDal.GetBlogsByTourId(tour.TourId));
                oldPictures.AddRange(pictureDal.GetPicturesByTourId(tour.TourId));
                foreach(Picture pic in oldPictures)
                {
                    oldPicComments.AddRange(pictureCommentDal.GetPictureCommentsByPictureId(pic.PictureId));
                }
            }

            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourDal.DeleteTour(tour, trans);
                        foreach (TourComment comm in oldComments)
                        {
                            tourCommentDal.DeleteTourComment(comm, trans);
                        }
                        foreach (SubTour st in oldSubTours)
                        {
                            subtourDal.DeleteSubTour(st, trans);
                        }
                        if (deletePictures)
                        {
                            foreach (Blog blog in oldBlogs)
                            {
                                blogDal.DeleteBlog(blog, trans);
                            }
                            foreach (Picture pic in oldPictures)
                            {
                                pictureDal.DeletePicture(pic, trans);
                            }
                            foreach (PictureComment comm in oldPicComments)
                            {
                                pictureCommentDal.DeletePictureComment(comm, trans);
                            }
                        }
                        
                        trans.Commit();
                        message = "";
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

        public bool SaveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours, out string message)
        {
            Tour oldTour = tourDal.GetTourByTourId(tour.TourId);
            List<SubTour> oldSubTours = subtourDal.GetSubToursByTourId(tour.TourId);

            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        if (string.IsNullOrEmpty(tour.TourId))
                        {
                            string tourId = Util.StringHelper.CreateGuid();
                            tour.TourId = tourId;

                            tourDal.InsertTour(tour, trans);
                            foreach (SubTour subTour in subTours)
                            {
                                subTour.TourId = tourId;
                                subtourDal.InsertSubTour(subTour, trans);
                            }
                            trans.Commit();
                            message = "";
                            return true;
                        }
                        else
                        {
                            tourDal.UpdateTourFromOld(tour, oldTour, trans);
                            foreach (SubTour subTour in subTours)
                            {
                                SubTour oldSubTour = oldSubTours.Find(delegate(SubTour st) { return st.TourId == tour.TourId && st.SubTourId == subTour.SubTourId; });
                                subTour.TourId = tour.TourId;
                                if (subtourDal.UpdateSubTourFromOld(subTour, oldSubTour, trans) < 1)
                                {
                                    subtourDal.InsertSubTour(subTour, trans);
                                }
                            }
                            foreach (SubTour subTour in removedSubTours)
                            {
                                if (!string.IsNullOrEmpty(subTour.SubTourId))
                                {
                                    subtourDal.DeleteSubTour(subTour, trans);
                                }
                            }
                            trans.Commit();
                            message = "";
                            return true;
                        }
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



        public List<SubTour> GetSubToursByTourId(string tourId)
        {
            return subtourDal.GetSubToursByTourId(tourId);
        }

        public SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId)
        {
            return subtourDal.GetSubTourByTourIdAndSubTourId(tourId, subTourId);
        }

        public List<SubTour> GetSubToursByUserId(string userId)
        {
            return subtourDal.GetSubToursByUserId(userId);
        }

        public List<SubTour> GetSubToursBySightsId(string sightsId)
        {
            return subtourDal.GetSubToursBySightsId(sightsId);
        }


        public List<Picture> GetPicturesByTourId(string tourId)
        {
            return pictureDal.GetPicturesByTourId(tourId);
        }

        public List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId)
        {
            return pictureDal.GetPicturesByTourIdAndSubTourId(tourId, subTourId);
        }

        public void Dispose()
        {
            dataContext.Dispose();
            tourDal.Dispose();
            tourCommentDal.Dispose();
            subtourDal.Dispose();
            pictureDal.Dispose();

            dataContext = null;
            tourDal = null;
            tourCommentDal = null;
            subtourDal = null;
            pictureDal = null;
        }




    }
}
