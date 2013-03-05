using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface IDictService : IBaseService
    {
        List<Country> GetCountries();
        List<Province> GetProvincesByCountryId(string countryId);
        List<City> GetCitiesByProvinceId(string provinceId);

        //bool UpdateCountries(List<Country> countries);
        //bool UpdateProvinces(List<Province> provinces);
        //bool UpdateCities(List<City> cities);

        bool InsertCountry(Country country);
        bool UpdateCountry(Country country);
        bool DeleteCountryByCountryId(string countryId);
        bool InsertProvince(Province province);
        bool UpdateProvince(Province province);
        bool DeleteProvinceByProvinceId(string provinceId);
        bool InsertCity(City city);
        bool UpdateCity(City city);
        bool DeleteCityByCityId(string cityId);
    }
}
