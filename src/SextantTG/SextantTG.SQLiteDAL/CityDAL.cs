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
    public class CityDAL : AbstractDAL<City>, ICityDAL
    {
        public CityDAL() { }

        protected override City BuildObjectByReader(DbDataReader r)
        {
            City city = new City();
            city.CityId = CustomTypeConverter.ToString(r["city_id"]);
            city.CityName = CustomTypeConverter.ToString(r["city_name"]);
            city.ProvinceId = CustomTypeConverter.ToString(r["province_id"]);
            return city;
        }

        private static readonly string SELECT = "select * from stg_City order by province_id, city_id";
        private static readonly string INSERT = "insert into stg_city(city_id, city_name, province_id) values(:CityId, :CityName, :ProvinceId)";
        private static readonly string UPDATE = "update stg_city set city_name = :CityName, province_id = :ProvinceId where city_id = :CityId";
        private static readonly string DELETE = "delete from stg_city where city_id = :CityId";

        public List<City> GetCities()
        {
            return this.GetList(SELECT, null);
        }

        public int InsertCity(City city, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(city.CityId))
                city.CityId = StringHelper.CreateGuid();

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", city.CityId);
            pars.Add("CityName", city.CityName);
            pars.Add("ProvinceId", city.ProvinceId);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateCity(City city, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", city.CityId);
            pars.Add("CityName", city.CityName);
            pars.Add("ProvinceId", city.ProvinceId);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteCityByCityId(string cityId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityID", cityId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }
    }
}
