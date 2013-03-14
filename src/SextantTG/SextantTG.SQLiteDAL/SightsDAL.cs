using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class SightsDAL : ISightsDAL
    {
        private DbHelper dbHelper = null;

        public SightsDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public SightsDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_sights";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sights where sights_id = :SightsId";
        private static readonly string SELECT___SIGHTS_NAME = "select * from stg_sights where sights_name = :SightsName";
        private static readonly string SELECT___SIGHTS_LEVEL = "select * from stg_sights where sights_level = :SightsLevel";
        private static readonly string SELECT___CITY_ID = "select * from stg_sights where city_id = :CityId";
        private static readonly string SELECT___PROVINCE_ID = "select stg_sights.* from stg_sights, stg_city where stg_sights.city_id = stg_city.city_id and stg_city.province_id = :ProvinceId";
        private static readonly string SELECT___COUNTRY_ID = "select stg_sights.* from stg_sights, stg_city, stg_province where stg_sights.CITY_ID = stg_city.city_id and stg_city.province_id = stg_province.province_id and stg_province.country_id = :CountryId";

        private static readonly string INSERT = "insert into stg_sights(sights_id, sights_name, city_id, sights_level, description, price, creating_time, memos) values(:SightsId, :SightsName, :CityId, :SightsLevel, :Description, :Price, :CreatingTime, :Memos)";
        private static readonly string UPDATE = "update stg_sights set sights_name = :SightsName, city_id = :CityId, sights_level = :SightsLevel, description = :Description, price = :Price, creating_time = :CreatingTime, memos = :Memos where sights_id = :SightsId";
        private static readonly string DELETE = "delete from stg_sights where sights_id = :Sights_Id";

        private Sights BuildSightsByReader(DbDataReader r)
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

        public List<Sights> GetSights()
        {
            List<Sights> sights= new List<Sights>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public Sights GetSightBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                if (r.Read())
                {
                    return BuildSightsByReader(r);
                }
            }
            return null;
        }

        public List<Sights> GetSightsByCityId(string cityId)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CityId", cityId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___CITY_ID, pars))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public List<Sights> GetSightsByProvinceId(string provinceId)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", provinceId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID, pars))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public List<Sights> GetSightsByCountryId(string countryId)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", countryId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_ID, pars))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public List<Sights> GetSightsBySightsName(string sightsName)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsName", sightsName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_NAME, pars))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public List<Sights> GetSightsBySightsLevel(string sightsLevel)
        {
            List<Sights> sights = new List<Sights>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsLevel", sightsLevel);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_LEVEL, pars))
            {
                while (r.Read())
                {
                    sights.Add(BuildSightsByReader(r));
                }
            }
            return sights;
        }

        public int InsertSights(Sights sights, DbTransaction trans)
        {
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
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSights(Sights sights, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sights.SightsId);
            pars.Add("SightsName", sights.SightsName);
            pars.Add("CityId", sights.CityId);
            pars.Add("SightsLevel", sights.SightsLevel);
            pars.Add("Description", sights.Description);
            pars.Add("Price", sights.Price);
            pars.Add("CreatingTime", sights.CreatingTime);
            pars.Add("Memos", sights.Memos);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteSightsBySightsId(string sightsId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
