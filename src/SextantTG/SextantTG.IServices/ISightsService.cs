using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using System.Data.Common;

namespace SextantTG.IServices
{
    public interface ISightsService : IBaseService
    {
		List<Sights> GetSights();
		List<Sights> GetSightsByCountryId(string countryId);
		List<Sights> GetSightsByProvinceId(string provinceId);
		List<Sights> GetSightsByCityId(string cityId);
        Sights GetSightsBySightsId(string sightsId);
		
		bool InsertSights(Sights sights, DbTransaction trans, out string message);
		bool UpdateSights(Sights sights, DbTransaction trans, out string message);
		bool DeleteSightsBySightsId(string sightsId, DbTransaction trans, out string message);
    }
}
