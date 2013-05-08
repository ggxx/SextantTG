using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using System.Data.Common;
using SextantTG.IDAL;

namespace SextantTG.Services
{
    public class SightsService : ISightsService
    {
        private IDataContext dataContext = null;
        private ISightsDAL sightsDal = null;
        private IFavoriteDAL favoriteDal = null;
        private IPictureDAL pictureDal = null;

        public SightsService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            sightsDal = DALFactory.CreateDAL<ISightsDAL>();
            favoriteDal = DALFactory.CreateDAL<IFavoriteDAL>();
            pictureDal = DALFactory.CreateDAL<IPictureDAL>();
        }

        public List<Sights> GetSights()
        {
            return sightsDal.GetSights();
        }

        public List<Sights> GetSightsByCountryId(string countryId)
        {
            return sightsDal.GetSightsByCountryId(countryId);
        }

        public List<Sights> GetSightsByProvinceId(string provinceId)
        {
            return sightsDal.GetSightsByProvinceId(provinceId);
        }

        public List<Sights> GetSightsByCityId(string cityId)
        {
            return sightsDal.GetSightsByCityId(cityId);
        }

        public Sights GetSightsBySightsId(string sightsId)
        {
            return sightsDal.GetSightBySightsId(sightsId);
        }

        public List<Picture> GetPicturesBySightsId(string sightsId)
        {
            return pictureDal.GetPicturesBySightsId(sightsId);
        }

        public List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId)
        {
            if (string.IsNullOrEmpty(uploaderId))
            {
                return GetPicturesBySightsId(sightsId);
            }
            return pictureDal.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);
        }

        public float? GetAverageStarsBySightsId(string sightsId)
        {
            return favoriteDal.GetAverageStarsBySightsId(sightsId);
        }

        public List<Sights> GetVisitedSights(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            { return GetSights(); }

            List<Sights> l = new List<Sights>();
            List<Sights> sights =  GetSights();
            foreach (Favorite f in favoriteDal.GetFavoritesByUserId(userId))
            {
                foreach (Sights s in sights)
                {
                    if (s.SightsId == f.SightsId)
                    {
                        l.Add(s);
                        break;
                    }
                }
            }
            return l;
        }

        public List<Sights> GetVisitedSightsByCountryId(string countryId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            { return GetSightsByCountryId(countryId); }

            List<Sights> l = new List<Sights>();
            List<Sights> sights = GetSightsByCountryId(countryId);
            foreach (Favorite f in favoriteDal.GetFavoritesByUserId(userId))
            {
                foreach (Sights s in sights)
                {
                    if (s.SightsId == f.SightsId)
                    {
                        l.Add(s);
                        break;
                    }
                }
            }
            return l;
        }

        public List<Sights> GetVisitedSightsByProvinceId(string provinceId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            { return GetSightsByProvinceId(provinceId); }

            List<Sights> l = new List<Sights>();
            List<Sights> sights = GetSightsByProvinceId(provinceId);
            foreach (Favorite f in favoriteDal.GetFavoritesByUserId(userId))
            {
                foreach (Sights s in sights)
                {
                    if (s.SightsId == f.SightsId)
                    {
                        l.Add(s);
                        break;
                    }
                }
            }
            return l;
        }

        public List<Sights> GetVisitedSightsByCityId(string cityId, string userId)
        {
            if (string.IsNullOrEmpty(userId))
            { return GetSightsByCityId(cityId); }

            List<Sights> l = new List<Sights>();
            List<Sights> sights = GetSightsByCityId(cityId);
            foreach (Favorite f in favoriteDal.GetFavoritesByUserId(userId))
            {
                foreach (Sights s in sights)
                {
                    if (s.SightsId == f.SightsId)
                    {
                        l.Add(s);
                        break;
                    }
                }
            }
            return l;
        }

        public bool InsertSights(Sights sights, List<Picture> pictures, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.InsertSights(sights, trans);
                        foreach (Picture picture in pictures)
                        {
                            picture.PictureId = picture.PictureId.Substring(1);
                            pictureDal.InsertPicture(picture, trans);
                        }
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

        public bool UpdateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures, out string message)
        {
            Sights oldSights = sightsDal.GetSightBySightsId(sights.SightsId);
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.UpdateSightsFromOld(sights, oldSights, trans);
                        foreach (Picture picture in pictures)
                        {
                            if (picture.PictureId.StartsWith("_"))
                            {
                                picture.PictureId = picture.PictureId.Substring(1);
                                pictureDal.InsertPicture(picture, trans);
                            }
                            else
                            {
                                pictureDal.UpdatePicture(picture, trans);
                            }
                        }
                        foreach (Picture picture in removedPictures)
                        {
                            pictureDal.DeletePicture(picture, trans);
                        }
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

        public bool DeleteSights(Sights sights, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.DeleteSights(sights, trans);
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

        public void Dispose()
        {
            dataContext.Dispose();
            sightsDal.Dispose();
            favoriteDal.Dispose();
            pictureDal.Dispose();

            dataContext = null;
            sightsDal = null;
            favoriteDal = null;
            pictureDal = null;
        }
    }
}
