using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using SextantTG.ActiveRecord;
using SextantTG.IDAL;
using SextantTG.Util;
using SextantTG.DbUtil;

namespace SextantTG.SQLiteDAL
{
    public class SightsDAL : AbstractDAL<Sights>, ISightsDAL
    {

        public SightsDAL() { }

        protected override Sights BuildObjectByReader(DbDataReader r)
        {
            Sights sights = new Sights();
            sights.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            sights.SightsName = CustomTypeConverter.ToString(r["sights_name"]);
            sights.CityId = CustomTypeConverter.ToString(r["city_id"]);
            sights.SightsLevel = CustomTypeConverter.ToString(r["sights_level"]);
            sights.Description = CustomTypeConverter.ToString(r["description"]);
            sights.Price = CustomTypeConverter.ToInt32Null(r["price"]);
            sights.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            sights.Memos = CustomTypeConverter.ToString(r["memos"]);
            return sights;
        }

        private static readonly string SELECT = "select * from stg_sights order by sights_level, sights_name";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sights where sights_id = :SightsId";
        private static readonly string SELECT___SIGHTS_NAME = "select * from stg_sights where sights_name = :SightsName";
        private static readonly string SELECT___SIGHTS_LEVEL = "select * from stg_sights where sights_level = :SightsLevel  order by sights_name";
        private static readonly string SELECT___CITY_ID = "select * from stg_sights where city_id = :CityId order by sights_level, sights_name";
        private static readonly string SELECT___PROVINCE_ID = "select stg_sights.* from stg_sights, stg_city where stg_sights.city_id = stg_city.city_id and stg_city.province_id = :ProvinceId order by sights_level, sights_name";
        private static readonly string SELECT___COUNTRY_ID = "select stg_sights.* from stg_sights, stg_city, stg_province where stg_sights.CITY_ID = stg_city.city_id and stg_city.province_id = stg_province.province_id and stg_province.country_id = :CountryId order by sights_level, sights_name";

        private static readonly string INSERT = "insert into stg_sights(sights_id, sights_name, city_id, sights_level, description, price, creating_time, memos) values(:SightsId, :SightsName, :CityId, :SightsLevel, :Description, :Price, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_sights set sights_name = :SightsName, city_id = :CityId, sights_level = :SightsLevel, description = :Description, price = :Price, creating_time = :CreatingTime, memos = :Memos where sights_id = :SightsId";
        private static readonly string DELETE = "delete from stg_sights where sights_id = :Sights_Id";

        public List<Sights> GetSights()
        {
            return this.GetList(SELECT, null);
        }

        public Sights GetSightBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetObject(SELECT___SIGHTS_ID, pars);
        }

        public List<Sights> GetSightsByCityId(string cityId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityId", cityId);
            return this.GetList(SELECT___CITY_ID, pars);
        }

        public List<Sights> GetSightsByProvinceId(string provinceId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", provinceId);
            return this.GetList(SELECT___PROVINCE_ID, pars);
        }

        public List<Sights> GetSightsByCountryId(string countryId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", countryId);
            return this.GetList(SELECT___COUNTRY_ID, pars);
        }

        public List<Sights> GetSightsBySightsName(string sightsName)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsName", sightsName);
            return this.GetList(SELECT___SIGHTS_NAME, pars);
        }

        public List<Sights> GetSightsBySightsLevel(string sightsLevel)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsLevel", sightsLevel);
            return this.GetList(SELECT___SIGHTS_LEVEL, pars);
        }

        public int InsertSights(Sights sights, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(sights.SightsId))
                sights.SightsId = StringHelper.CreateGuid();
            sights.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sights.SightsId);
            pars.Add("SightsName", sights.SightsName);
            pars.Add("CityId", sights.CityId);
            pars.Add("SightsLevel", sights.SightsLevel);
            pars.Add("Description", sights.Description);
            pars.Add("Price", sights.Price);
            pars.Add("CreatingTime", sights.CreatingTime);
            pars.Add("Memos", sights.Memos);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSights(Sights sights, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public int DeleteSights(Sights sights, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sights.SightsId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        public int UpdateSightsFromOld(Sights newItem, Sights oldItem, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", oldItem.SightsId);
            pars.Add("SightsName", newItem.SightsName);
            pars.Add("CityId", newItem.CityId);
            pars.Add("SightsLevel", newItem.SightsLevel);
            pars.Add("Description", newItem.Description);
            pars.Add("Price", newItem.Price);
            pars.Add("CreatingTime", newItem.CreatingTime);
            pars.Add("Memos", newItem.Memos);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }



    }
}
