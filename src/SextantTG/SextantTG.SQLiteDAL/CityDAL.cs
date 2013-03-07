using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IDAL;
using SexTantTG.DbUtil;
using System.Configuration;
using SextantTG.ActiveRecord;
using System.Data.Common;
using SextantTG.DbUtil;
using SextantGT.Util;

namespace SextantTG.SQLiteDAL
{
    public class CityDAL : ICityDAL
    {
        private static readonly string SELECT = "select * from stg_city";

        private DbHelper dbHelper = null;

        public CityDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public CityDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbProviderType.SQLite);
        }

        private City BuildCityByReader(DbDataReader r)
        {
            City city = new City();
            city.CityId = TypeConverter.ToString(r["city_id"]);
            city.CityName = TypeConverter.ToString(r["city_name"]);
            city.ProvinceId = TypeConverter.ToString(r["province_id"]);
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
            throw new NotImplementedException();
        }

        public int UpdateCity(City city, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public int DeleteCityByCityId(string cityId, DbTransaction trans)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
