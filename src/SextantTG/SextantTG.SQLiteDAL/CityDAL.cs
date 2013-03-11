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
    public class CityDAL : ICityDAL
    {
        private DbHelper dbHelper = null;

        public CityDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public CityDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_City";
        private static readonly string SELECT___CITY_ID = "select * from stg_city where city_id = :CityId";
        private static readonly string SELECT___CITY_NAME = "select * from stg_city where city_Name = :CityName";
        private static readonly string SELECT___PROVINCE_ID = "select * from stg_city where province_id = :provinceId";
        private static readonly string INSERT = "insert into stg_city(City_id, City_name,Province_id) values(:CityId,:Cityname,ProvinceId)";
        private static readonly string UPDATE = "update stg_city set city_id = :CityId, City_name = :City_name where city_id = :CityId";
        private static readonly string DELETE = "delete from stg_city where City_id = :CityId";

        private City BuildCityByReader(DbDataReader r)
        {
            City city = new City();
            City.CityId = TypeConverter.ToString(r["city_id"]);
            City.CityName = TypeConverter.ToString(r["city_name"]);          
            return province;
        }

        public List<City> GetCity()
        {
            List<City> city = new List<City>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    city.Add(BuildCityByReader(r));
                }
            }
            return city;
        }

        public List<City> GetCityByCityId(string cityID)
        {
            List<City> city = new List<City>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("cityID", cityID);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___CITY_ID , pars))
            {
                while (r.Read())
                {
                    city.Add(BuildCityByReader(r));
                }
            }
            return city;
        }

        public List<City> GetCityByCityName(string cityName)
        {
            List<City> city = new List<City>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityName", cityName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___CITY_NAME , pars))
            {
                while (r.Read())
                {
                    city.Add(BuildCityByReader(r));
                }
            }
            return city;
        }

       
        public List<City> GetCityByCountryId(string provinceId)
        {
            List<City> city = new List<City>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", provinceId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID , pars))
            {
                while (r.Read())
                {
                    city.Add(BuildCityByReader(r));
                }
            }
            return city;
        }


        

        public City GetCityById(string cityId)
        {
            City city = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", cityId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___CITY_ID, pars))
            {
                if (r.Read())
                {
                    city = BuildCityByReader(r);
                }
            }
            return city;
        }

        public int InsertCity(City city, DbTransaction trans)
        {
            city.CityId = StringHelper.CreateGuid();
           
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("cityID", city.CityId);
            pars.Add("CityName", city.CityName);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateCity(City city, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", city.CityId);
            pars.Add("CityName", city.CityName);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteCityByCityID(City city, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", cityId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
