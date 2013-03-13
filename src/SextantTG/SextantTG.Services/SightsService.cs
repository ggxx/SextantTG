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

        public bool InsertSights(Sights sights, DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSights(Sights sights, DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSightsBySightsId(string sightsId, DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
