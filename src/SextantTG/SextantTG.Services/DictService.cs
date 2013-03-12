using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.IServices;
using SextantTG.ActiveRecord;
using SextantTG.IDAL;

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
                countries = countryDal.GetCounties();
            return countries;
        }

        public List<Province> GetProvinces()
        {
            if (provinces == null)
                provinces = provinceDal.GetProvinces();
            return provinces;
        }

        public List<City> GetCities()
        {
            if (cities == null)
                cities = cityDal.GetCities();
            return cities;
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

        public Country GetCountryByProvinceId(string provinceId)
        {
            return GetCountryByCountryId(GetProvinceByProvinceId(provinceId).CountryId);
        }

        public Province GetProvinceByCityId(string cityId)
        {
            return GetProvinceByProvinceId(GetCiryByCityId(cityId).ProvinceId);
        }

        public Country GetCountryByCountryId(string countryId) 
        {
            if (countries == null)
                countries = countryDal.GetCounties();
            return countries.Find(delegate(Country tmp) { return tmp.CountryId == countryId; });
        }

        public Province GetProvinceByProvinceId(string provinceId)
        {
            if (provinces == null)
                provinces = provinceDal.GetProvinces();
            return provinces.Find(delegate(Province tmp) { return tmp.ProvinceId == provinceId; });
        }

        public City GetCiryByCityId(string cityId) 
        {
            if (cities == null)
                cities = cityDal.GetCities();
            return cities.Find(delegate(City tmp) { return tmp.CityId == cityId; });
        }


        public bool InsertCountry(Country country, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCountry(Country country, out string message)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCountryByCountryId(string countryId, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InsertProvince(Province province, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProvince(Province province, out string message)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProvinceByProvinceId(string provinceId, out string message)
        {
            throw new NotImplementedException();
        }

        public bool InsertCity(City city, out string message)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCity(City city, out string message)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCityByCityId(string cityId, out string message)
        {
            throw new NotImplementedException();
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


        public Dictionary<int, string> GetPermissions()
        {
            Dictionary<int, string> p = new Dictionary<int, string>();
            p.Add(9, "管理员");
            return p;
        }
    }
}
