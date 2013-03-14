using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using SextantTG.Util;
using SextantTG.ActiveRecord;
using SextantTG.DbUtil;
using SextantTG.IDAL;
using SexTantTG.DbUtil;
﻿
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
            this.dbHelper = new DbHelper(connectionString, DbProviderType.SQLite);
        }

        private static readonly string SELECT = "select * from stg_City";
        //private static readonly string SELECT___CITY_ID = "select * from stg_city where city_id = :CityId";
        //private static readonly string SELECT___CITY_NAME = "select * from stg_city where city_Name = :CityName";
        //private static readonly string SELECT___PROVINCE_ID = "select * from stg_city where province_id = :provinceId";
        private static readonly string INSERT = "insert into stg_city(city_id, city_name, province_id) values(:CityId, :CityName, :ProvinceId)";
        private static readonly string UPDATE = "update stg_city set city_name = :CityName, province_id = :ProvinceId where city_id = :CityId";
        private static readonly string DELETE = "delete from stg_city where city_id = :CityId";

        private City BuildCityByReader(DbDataReader r)
        {
            City city = new City();
            city.CityId = CustomTypeConverter.ToString(r["city_id"]);
            city.CityName = CustomTypeConverter.ToString(r["city_name"]);
            city.ProvinceId = CustomTypeConverter.ToString(r["province_id"]);
            return city;
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            using (DbDataReader r = this.dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    cities.Add(BuildCityByReader(r));
                }
            }
            return cities;
        }

        public int InsertCity(City city, DbTransaction trans)
        {
            city.CityId = StringHelper.CreateGuid();

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", city.CityId);
            pars.Add("CityName", city.CityName);
            pars.Add("ProvinceId", city.ProvinceId);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateCity(City city, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", city.CityId);
            pars.Add("CityName", city.CityName);
            pars.Add("ProvinceId", city.ProvinceId);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteCityByCityId(string cityId, DbTransaction trans)
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
