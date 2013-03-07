using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;

namespace SextantTG.Services
{
    public class SightsService : ISightsService
    {
        public List<ActiveRecord.Sights> GetSights()
        {
            throw new NotImplementedException();
        }

        public List<ActiveRecord.Sights> GetSightsByCountryId(string countryId)
        {
            throw new NotImplementedException();
        }

        public List<ActiveRecord.Sights> GetSightsByProvinceId(string provinceId)
        {
            throw new NotImplementedException();
        }

        public List<ActiveRecord.Sights> GetSightsByCityId(string cityId)
        {
            throw new NotImplementedException();
        }

        public ActiveRecord.Sights GetSightsBySightsId(string sightsId)
        {
            throw new NotImplementedException();
        }

        public bool InsertSights(ActiveRecord.Sights sights, System.Data.Common.DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSights(ActiveRecord.Sights sights, System.Data.Common.DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSightsBySightsId(string sightsId, System.Data.Common.DbTransaction trans, out string message)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
