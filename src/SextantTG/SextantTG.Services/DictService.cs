using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using SextantTG.IDAL;
using System.Data.Common;

namespace SextantTG.Services
{
    public class DictService : IDictService
    {
        private List<Country> countries = null;
        private List<Province> provinces = null;
        private List<City> cities = null;

        private IDataContext dataContext = null;
        private ICountryDAL countryDal = null;
        private IProvinceDAL provinceDal = null;
        private ICityDAL cityDal = null;

        public DictService()
        {
            dataContext = DALFactory.CreateDAL<IDataContext>();
            countryDal = DALFactory.CreateDAL<ICountryDAL>();
            provinceDal = DALFactory.CreateDAL<IProvinceDAL>();
            cityDal = DALFactory.CreateDAL<ICityDAL>();
        }

        public List<Country> GetCountries()
        {
            if (countries == null)
                countries = countryDal.GetCountries();
            Country[] c = new Country[countries.Count];
            countries.CopyTo(c);
            return c.ToList();
        }

        public List<Province> GetProvinces()
        {
            if (provinces == null)
                provinces = provinceDal.GetProvinces();
            Province[] p = new Province[provinces.Count];
            provinces.CopyTo(p);
            return p.ToList();
        }

        public List<City> GetCities()
        {
            if (cities == null)
                cities = cityDal.GetCities();
            City[] c = new City[cities.Count];
            cities.CopyTo(c);
            return c.ToList();
        }

        public List<Province> GetProvincesByCountryId(string countryId)
        {
            if (provinces == null)
                provinces = provinceDal.GetProvinces();
            return provinces.FindAll(delegate(Province tmp) { return tmp.CountryId == countryId; });
        }

        public List<City> GetCitiesByProvinceId(string provinceId)
        {
            if (cities == null)
                cities = cityDal.GetCities();
            return cities.FindAll(delegate(City tmp) { return tmp.ProvinceId == provinceId; });
        }

        public List<City> GetCitiesByCountryId(string countryId)
        {
            List<City> cites = new List<City>();
            List<Province> provinces = GetProvincesByCountryId(countryId);
            foreach (Province province in provinces)
            {
                cites.AddRange(GetCitiesByProvinceId(province.ProvinceId));
            }
            return cites;
        }

        public Country GetCountryByProvinceId(string provinceId)
        {
            return GetCountryByCountryId(GetProvinceByProvinceId(provinceId).CountryId);
        }

        public Province GetProvinceByCityId(string cityId)
        {
            return GetProvinceByProvinceId(GetCityByCityId(cityId).ProvinceId);
        }

        public Country GetCountryByCountryId(string countryId)
        {
            if (countries == null)
                countries = countryDal.GetCountries();
            return countries.Find(delegate(Country tmp) { return tmp.CountryId == countryId; });
        }

        public Province GetProvinceByProvinceId(string provinceId)
        {
            if (provinces == null)
                provinces = provinceDal.GetProvinces();
            return provinces.Find(delegate(Province tmp) { return tmp.ProvinceId == provinceId; });
        }

        public City GetCityByCityId(string cityId)
        {
            if (cities == null)
                cities = cityDal.GetCities();
            return cities.Find(delegate(City tmp) { return tmp.CityId == cityId; });
        }


        public bool InsertCountry(Country country, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        countryDal.InsertCountry(country, trans);
                        trans.Commit();
                        message = string.Empty;
                        countries = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateCountry(Country country, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        countryDal.UpdateCountry(country, trans);
                        trans.Commit();
                        message = string.Empty;
                        countries = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteCountryByCountryId(string countryId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        countryDal.DeleteCountryByCountryId(countryId, trans);
                        trans.Commit();
                        message = string.Empty;
                        countries = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool InsertProvince(Province province, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        provinceDal.InsertProvince(province, trans);
                        trans.Commit();
                        message = string.Empty;
                        provinces = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateProvince(Province province, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        provinceDal.UpdateProvince(province, trans);
                        trans.Commit();
                        message = string.Empty;
                        provinces = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteProvinceByProvinceId(string provinceId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        provinceDal.DeleteProvinceByProvinceId(provinceId, trans);
                        trans.Commit();
                        message = string.Empty;
                        provinces = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool InsertCity(City city, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        cityDal.InsertCity(city, trans);
                        trans.Commit();
                        message = string.Empty;
                        cities = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool UpdateCity(City city, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        cityDal.UpdateCity(city, trans);
                        trans.Commit();
                        message = string.Empty;
                        cities = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public bool DeleteCityByCityId(string cityId, out string message)
        {
            using (DbConnection conn = dataContext.GetConnection())
            {
                conn.Open();
                using (DbTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        cityDal.DeleteCityByCityId(cityId, trans);
                        trans.Commit();
                        message = string.Empty;
                        cities = null;
                        return true;
                    }
                    catch (DbException ex)
                    {
                        message = ex.Message;
                        trans.Rollback();
                        return false;
                    }
                }
            }
        }

        public void Dispose()
        {
            countries = null;
            provinces = null;
            cities = null;

            dataContext.Dispose();
            countryDal.Dispose();
            provinceDal.Dispose();
            cityDal.Dispose();

            dataContext = null;
            countryDal = null;
            provinceDal = null;
            cityDal = null;
        }


        public Dictionary<int, string> GetPermissionsDict()
        {
            Dictionary<int, string> p = new Dictionary<int, string>();
            p.Add(9, "管理员");
            return p;
        }

        public Dictionary<int, string> GetTourStatusDict()
        {
            Dictionary<int, string> p = new Dictionary<int, string>();
            p.Add(0, "未进行");
            p.Add(1, "进行中");
            p.Add(2, "已结束");
            return p;
        }
    }
}
