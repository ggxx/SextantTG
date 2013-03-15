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
        private ISubTourDAL subtourDal = null;

        public TourService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            tourDal = DALFactory.CreateDAL<ITourDAL>();
            subtourDal = DALFactory.CreateDAL<ISubTourDAL>();
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

        public bool InsertTour(Tour tour, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourDal.InsertTour(tour, trans);
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

        public bool UpdateTour(Tour tour, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourDal.UpdateTour(tour, trans);
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

        public bool DeleteTourByTourId(string tourId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        tourDal.DeleteTourByTourId(tourId, trans);
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
                            tourDal.UpdateTour(tour, trans);
                            foreach (SubTour subTour in subTours)
                            {
                                if (string.IsNullOrEmpty(subTour.SubTourId))
                                {
                                    subtourDal.InsertSubTour(subTour, trans);
                                }
                                else
                                {
                                    subtourDal.UpdateSubTour(subTour, trans);
                                }
                            }
                            foreach (SubTour subTour in removedSubTours)
                            {
                                if (!string.IsNullOrEmpty(subTour.SubTourId))
                                {
                                    subtourDal.DeleteSubTourByTourIdAndSubTourId(subTour.TourId, subTour.SubTourId, trans);
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

        public bool InsertSubTour(SubTour subTour, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        subtourDal.InsertSubTour(subTour, trans);
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

        public bool UpdateSubTour(SubTour subTour, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        subtourDal.UpdateSubTour(subTour, trans);
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

        public bool DeleteSubTourByTourIdAndSubTourId(string tourId, string subTourId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        subtourDal.DeleteSubTourByTourIdAndSubTourId(tourId, subTourId, trans);
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



        public void Dispose()
        {
            dataContext.Dispose();
            tourDal.Dispose();
            subtourDal.Dispose();

            dataContext = null;
            tourDal = null;
            subtourDal = null;
        }



    }
}
