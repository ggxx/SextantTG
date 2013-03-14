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

        public SightsService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            sightsDal = DALFactory.CreateDAL<ISightsDAL>();
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

        public bool InsertSights(Sights sights, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.InsertSights(sights, trans);
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

        public bool UpdateSights(Sights sights, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.UpdateSights(sights, trans);
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

        public bool DeleteSightsBySightsId(string sightsId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        sightsDal.DeleteSightsBySightsId(sightsId, trans);
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
            sightsDal.Dispose();

            dataContext = null;
            sightsDal = null;
        }
    }
}
