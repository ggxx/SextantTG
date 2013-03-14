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
        //private static readonly string SELECT___PROVINCE_ID = "select * from stg_province where province_id = :ProvinceId";
        //private static readonly string SELECT___PROVINCE_NAME = "select * from stg_province where province_Name = :ProvinceName";
        //private static readonly string SELECT___COUNTRY_ID = "select * from stg_province where country_id = :countryId";
        private static readonly string INSERT = "insert into stg_province(province_id, province_name, country_id) values(:ProvinceId, :ProvinceName, :CountryId)";
        private static readonly string UPDATE = "update stg_province set province_id = :ProvinceId, province_name = :ProvinceName where province_id = :ProvinceId";
        private static readonly string DELETE = "delete from stg_province where province_id = :ProvinceId";

        private Province BuildProvinceByReader(DbDataReader r)
        {
            Province province = new Province();
            province.ProvinceId = CustomTypeConverter.ToString(r["province_id"]);
            province.ProvinceName = CustomTypeConverter.ToString(r["province_name"]);
            province.CountryId = CustomTypeConverter.ToString(r["country_id"]);
            return province;
        }

        public List<Province> GetProvinces()
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

        //public Province GetProvinceByProvinceId(string provinceID)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("provinceID", provinceID);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID , pars))
        //    {
        //        if (r.Read())
        //        {
        //            return BuildProvinceByReader(r);
        //        }
        //    }
        //    return null;
        //}

        //public Province GetProvinceByProvinceName(string provinceName)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("ProvinceName", provinceName);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_NAME , pars))
        //    {
        //        if (r.Read())
        //        {
        //            province.Add(BuildProvinceByReader(r));
        //        }
        //    }
        //    return province;
        //}

       
        //public List<Province> GetProvinceByCountryId(string countryId)
        //{
        //    List<Province> province = new List<Province>();
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("CountryId", countryId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COUNTRY_ID , pars))
        //    {
        //        while (r.Read())
        //        {
        //            province.Add(BuildProvinceByReader(r));
        //        }
        //    }
        //    return province;
        //}


        

        //public Province GetProvinceById(string provinceId)
        //{
        //    Province province = null;
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("ProvinceID", provinceId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PROVINCE_ID, pars))
        //    {
        //        if (r.Read())
        //        {
        //            province = BuildProvinceByReader(r);
        //        }
        //    }
        //    return province;
        //}

        public int InsertProvince(Province province, DbTransaction trans)
        {
            province.ProvinceId = StringHelper.CreateGuid();
           
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            pars.Add("CountryId", province.CountryId);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateProvince(Province province, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            pars.Add("CountryId", province.CountryId);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteProvinceByProvinceId(string provinceId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", provinceId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
