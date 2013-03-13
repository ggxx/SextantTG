using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISightsDAL : IBaseDAL
    {
        List<Sights> GetSights();
        List<Sights> GetSightsByCityId(string cityId);
        List<Sights> GetSightsByProvinceId(string provinceId);
        List<Sights> GetSightsByCountryId(string countryId);
        Sights GetSightBySightsId(string sightsId);

        int InsertSights(Sights sights, DbTransaction trans);
        int UpdateSights(Sights sights, DbTransaction trans);
        int DeleteSightsBySightsId(string sightsId, DbTransaction trans);
    }
}
