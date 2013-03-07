using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.IServices;

namespace SextantTG.Win
{
    internal class UIUtil
    {
        private static readonly IBlogService blogSrv = ServiceFactory.CreateService<IBlogService>();
        private static readonly IDictService dictSrv = ServiceFactory.CreateService<IDictService>();
        private static readonly ICommentService commentSrv = ServiceFactory.CreateService<ICommentService>();
        private static readonly ISightsService sightsSrv = ServiceFactory.CreateService<ISightsService>();
        private static readonly ITourService tourSrv = ServiceFactory.CreateService<ITourService>();
        private static readonly IUserService userSrv = ServiceFactory.CreateService<IUserService>();

        internal static List<Country> GetCountries()
        {
            return dictSrv.GetCountries();
        }

        internal static List<Province> GetProvinces()
        {
            return dictSrv.GetProvinces();
        }

        internal static List<City> GetCities()
        {
            return dictSrv.GetCities();
        }

        internal static List<Province> GetProvincesByCountryId(string countryId)
        {
            return dictSrv.GetProvincesByCountryId(countryId);
        }

        internal static List<City> GetCitiesByProvinceId(string provinceId)
        {
            return dictSrv.GetCitiesByProvinceId(provinceId);
        }

        internal List<Sights> GetSightsByCityId(string cityId)
        {
            return sightsSrv.GetSightsByCityId(cityId);
        }
    }
}
