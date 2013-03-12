using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ICountryDAL : IBaseDAL
    {
        List<Country> GetCountries();

        int InsertCountry(Country country, DbTransaction trans);
        int UpdateCountry(Country country, DbTransaction trans);
        int DeleteCountryByCountryId(string countryId, DbTransaction trans);
    }
}
