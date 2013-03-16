using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class CountryDAL : AbstractDAL<Country>, ICountryDAL
    {
        public CountryDAL() { }

        protected override Country BuildObjectByReader(DbDataReader r)
        {
            Country country = new Country();
            country.CountryId = CustomTypeConverter.ToString(r["country_id"]);
            country.CountryName = CustomTypeConverter.ToString(r["country_name"]);
            return country;
        }

        private static readonly string SELECT = "select * from stg_country order by country_id";
        private static readonly string INSERT = "insert into stg_country(country_id, country_name) values(:CountryId, :CountryName)";
        private static readonly string UPDATE = "update stg_country set country_name = :CountryName where country_id = :CountryId";
        private static readonly string DELETE = "delete from stg_country where country_id = :CountryId";


        public List<Country> GetCountries()
        {
            return this.GetList(SELECT, null);
        }

        public int InsertCountry(Country country, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(country.CountryId))
                country.CountryId = StringHelper.CreateGuid();

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", country.CountryId);
            pars.Add("CountryName", country.CountryName);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateCountry(Country country, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", country.CountryId);
            pars.Add("CountryName", country.CountryName);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteCountryByCountryId(string countryId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", countryId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
