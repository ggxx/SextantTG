using SextantTG.Model.Dict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IDictDAL
    {
        List<Country> GetCountries();
        List<Province> GetProvinces();
        List<Province> GetProvincesByCountryId(string countryId);
        List<City> GetCities();
        List<City> GetCitiesByCountryId(string provinceId);
        Country GetCountryById(string countryId);
        Province GetProvinceById(string provinceId);
        City GetCityById(string cityId);
    }
}
