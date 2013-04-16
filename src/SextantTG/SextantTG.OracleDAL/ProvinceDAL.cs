using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;
using SextantTG.PSAop;

namespace SextantTG.OracleDAL
{
    [MethodAspect]
    public class ProvinceDAL : AbstractDAL<Province>, IProvinceDAL
    {
        public ProvinceDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override Province BuildObjectByReader(DbDataReader r)
        {
            Province province = new Province();
            province.ProvinceId = CustomTypeConverter.ToString(r["province_id"]);
            province.ProvinceName = CustomTypeConverter.ToString(r["province_name"]);
            province.CountryId = CustomTypeConverter.ToString(r["country_id"]);
            return province;
        }

        private static readonly string SELECT = "select * from stg_province order by country_id, province_id";
        private static readonly string INSERT = "insert into stg_province(province_id, province_name, country_id) values(:ProvinceId, :ProvinceName, :CountryId)";
        private static readonly string UPDATE = "update stg_province set province_id = :ProvinceId, province_name = :ProvinceName where province_id = :ProvinceId";
        private static readonly string DELETE = "delete from stg_province where province_id = :ProvinceId";


        public List<Province> GetProvinces()
        {
            return this.GetList(SELECT, null);
        }

        public int InsertProvince(Province province, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(province.ProvinceId))
                province.ProvinceId = StringHelper.CreateGuid();

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            pars.Add("CountryId", province.CountryId);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateProvince(Province province, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", province.ProvinceId);
            pars.Add("ProvinceName", province.ProvinceName);
            pars.Add("CountryId", province.CountryId);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteProvince(Province province, DbTransaction trans)
        {
            return this.DeleteProvinceByProvinceId(province.ProvinceId, trans);
        }

        private int DeleteProvinceByProvinceId(string provinceId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("ProvinceId", provinceId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

    }
}
