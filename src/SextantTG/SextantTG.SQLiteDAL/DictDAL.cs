using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.Model.Dict;
using System.Data.Common;
using SexTantTG.DBUtil;
using SextantGT.Util;

namespace SextantTG.SQLiteDAL
{
    public class DictDAL : IDictDAL
    {
        private DBHelper dbHelper;

        private static readonly string SELECT___COUNTIES = "select * from stg_country";

        public List<Country> GetCountries()
        {
            List<Country> counties = new List<Country>();
            using (DbDataReader ddr = dbHelper.ExecuteReader(SELECT___COUNTIES))
            {
                while (ddr.Read())
                {
                    Country country = new Country();
                    country.CountryId = TypeConverter.ToString(ddr["country_id"]);
                    country.CountryName = TypeConverter.ToString(ddr["country_name"]);
                    counties.Add(country);
                }
            }
            return counties;
        }

        public List<Province> GetProvinces()
        {
            throw new NotImplementedException();
        }

        public List<Province> GetProvincesByCountryId(string countryId)
        {
            throw new NotImplementedException();
        }

        public List<City> GetCities()
        {
            throw new NotImplementedException();
        }

        public List<City> GetCitiesByCountryId(string provinceId)
        {
            throw new NotImplementedException();
        }

        public Country GetCountryById(string countryId)
        {
            throw new NotImplementedException();
        }

        public Province GetProvinceById(string provinceId)
        {
            throw new NotImplementedException();
        }

        public City GetCityById(string cityId)
        {
            throw new NotImplementedException();
        }
    }
}
