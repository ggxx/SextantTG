using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantGT.Util;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class CountryDAL : ICountryDAL
    {
        private DbHelper dbHelper = null;

        public CountryDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public CountryDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_country";
        private static readonly string SELECT___COUNTRY_ID = "select * from stg_country where country_id = :CountryId";
        private static readonly string SELECT___COUNTRY_Name = "select * from stg_country where country_Name = :CountryName";
        private static readonly string INSERT = "insert into stg_country(Country_id, Country_name) values(:CountryId,:Countryname)";
        private static readonly string UPDATE = "update stg_country set country_id = :CountryId, Country_name = :Country_name";
        private static readonly string DELETE = "delete from stg_country where country_id = :CountryId";

        private Country BuildCountryByReader(DbDataReader r)
        {
            Country country = new Country();
            country.CountryId = TypeConverter.ToString(r["blog_id"]);
            counrty.CountryName = TypeConverter.ToString(r["counrty_name"]);          
            return country;
        }

        public List<Country> GetCourntry()
        {
            List<Country> country = new List<Country>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    country.Add(BuildCountryByReader(r));
                }
            }
            return country;
        }

        public List<Country> GetCourntryByCountryId(string countryID)
        {
            List<Country> country = new List<Country>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryID", countryID);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_ID , pars))
            {
                while (r.Read())
                {
                    country.Add(BuildCountryByReader(r));
                }
            }
            return country;
        }

        public List<Country> GetCourntryByCountryName(string countryName)
        {
            List<Country> country = new List<Country>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryName", countryName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_Name , pars))
            {
                while (r.Read())
                {
                    country.Add(BuildCountryByReader(r));
                }
            }
            return country;
        }

       

        

        public Country GetCountryById(string countryId)
        {
            Country country = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryID", countryId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_ID, pars))
            {
                if (r.Read())
                {
                    country = BuildCountryByReader(r);
                }
            }
            return country;
        }

        public int InsertCountry(Country country, DbTransaction trans)
        {
            country.CountryId = StringHelper.CreateGuid();
           
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryID", country.CountryId);
            pars.Add("CountryName", country.CountryName);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateCountry(Country country, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryID", country.CountryId);
            pars.Add("CountryName", country.CountryName);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteCountryByCountryID(Country country, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryID", countryId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
