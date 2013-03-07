using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    /// <summary>
    /// 基础字典业务操作的接口
    /// </summary>
    public interface IDictService : IBaseService
    {
        List<Country> GetCountries();
        List<Province> GetProvinces();
        List<City> GetCities();
        List<Province> GetProvincesByCountryId(string countryId);
        List<City> GetCitiesByProvinceId(string provinceId);
        Country GetCountryByProvinceId(string provinceId);
        Province GetProvinceByCityId(string cityId);
        Country GetCountryByCountryId(string countryId);
        Province GetProvinceByProvinceId(string provinceId);
        City GetCiryByCityId(string cityId);



        //bool UpdateCountries(List<Country> countries);
        //bool UpdateProvinces(List<Province> provinces);
        //bool UpdateCities(List<City> cities);

        bool InsertCountry(Country country, out string message);
        bool UpdateCountry(Country country, out string message);
        bool DeleteCountryByCountryId(string countryId, out string message);
        bool InsertProvince(Province province, out string message);
        bool UpdateProvince(Province province, out string message);
        bool DeleteProvinceByProvinceId(string provinceId, out string message);
        bool InsertCity(City city, out string message);
        bool UpdateCity(City city, out string message);
        bool DeleteCityByCityId(string cityId, out string message);
    }
}
