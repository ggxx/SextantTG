using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IDAL;
using SexTantTG.DbUtil;
using System.Configuration;
using SextantTG.ActiveRecord;
using System.Data.Common;
using SextantGT.Util;

namespace SextantTG.SQLiteDAL
{
    public class CountryDAL : ICountryDAL
    {
        private static readonly string SELECT = "select * from stg_country";

        private DbHelper dbHelper = null;

        public CountryDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public CountryDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        private Country BuildCountryByReader(DbDataReader r)
        {
            Country country = new Country();
            country.CountryId = TypeConverter.ToString(r["country_id"]);
            country.CountryName = TypeConverter.ToString(r["country_name"]);
            return country;
        }

        public List<Country> GetCounties()
        {
            List<Country> countries = new List<Country>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    countries.Add(BuildCountryByReader(r));
                }
            }
            return countries;
        }

        public int InsertCountry(Country country, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public int UpdateCountry(Country country, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public int DeleteCountryByCountryId(string countryId, System.Data.Common.DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
