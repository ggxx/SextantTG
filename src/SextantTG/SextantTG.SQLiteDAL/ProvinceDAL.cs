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
    public class ProvinceDAL : IProvinceDAL
    {
        private DbHelper dbHelper = null;

        public ProvinceDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public ProvinceDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_province";
        private static readonly string SELECT___PROVINCE_ID = "select * from stg_province where province_id = :ProvinceId";
        private static readonly string SELECT___PROVINCE_NAME = "select * from stg_province where province_Name = :ProvinceName";
        private static readonly string SELECT___COUNTRY_ID = "select * from stg_province where country_id = :countryId";
        private static readonly string INSERT = "insert into stg_province(Province_id, Province_name,Country_id) values(:ProvinceId,:Provincename,CountryId)";
        private static readonly string UPDATE = "update stg_province set province_id = :ProvinceId, Province_name = :Province_name where province_id = :ProvinceId";
        private static readonly string DELETE = "delete from stg_province where province_id = :ProvinceId";

        private Province BuildProvinceByReader(DbDataReader r)
        {
            Province province = new province();
            province.ProvinceId = TypeConverter.ToString(r["province_id"]);
            province.ProvinceName = TypeConverter.ToString(r["province_name"]);          
            return province;
        }

        public List<Province> GetProvince()
        {
            List<Province> province = new List<Province>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    province.Add(BuildProvinceByReader(r));
                }
            }
            return province;
        }

        public List<province> GetProvinceByProvinceId(string provinceID)
        {
            List<Province> province = new List<Province>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("provinceID", provinceID);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID , pars))
            {
                while (r.Read())
                {
                    province.Add(BuildProvinceByReader(r));
                }
            }
            return province;
        }

        public List<Province> GetProvinceByProvinceName(string provinceName)
        {
            List<Province> province = new List<Province>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceName", provinceName);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_NAME , pars))
            {
                while (r.Read())
                {
                    province.Add(BuildProvinceByReader(r));
                }
            }
            return province;
        }

       
        public List<Province> GetProvinceByCountryId(string countryId)
        {
            List<Province> province = new List<Province>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CountryId", countryId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_ID , pars))
            {
                while (r.Read())
                {
                    province.Add(BuildProvinceByReader(r));
                }
            }
            return province;
        }


        

        public Province GetProvinceById(string provinceId)
        {
            Province province = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceID", provinceId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID, pars))
            {
                if (r.Read())
                {
                    province = BuildProvinceByReader(r);
                }
            }
            return province;
        }

        public int InsertProvince(Province province, DbTransaction trans)
        {
            province.ProvinceId = StringHelper.CreateGuid();
           
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceID", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateProvince(Province province, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceID", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteProvinceByProvinceID(Province province, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceID", provinceId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
