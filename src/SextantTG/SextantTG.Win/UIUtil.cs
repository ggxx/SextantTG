using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.IServices;

namespace SextantTG.Win
{
    /// <summary>
    /// 为UI层访问Service层提供统一的出口
    /// </summary>
    internal class UIUtil
    {
        private static readonly IBlogService blogSrv = ServiceFactory.CreateService<IBlogService>();
        private static readonly IDictService dictSrv = ServiceFactory.CreateService<IDictService>();
        private static readonly ICommentService commentSrv = ServiceFactory.CreateService<ICommentService>();
        private static readonly ISightsService sightsSrv = ServiceFactory.CreateService<ISightsService>();
        private static readonly ITourService tourSrv = ServiceFactory.CreateService<ITourService>();
        private static readonly IUserService userSrv = ServiceFactory.CreateService<IUserService>();

        #region User Services

        internal static User Login(string loginName, string password) 
        {
            return userSrv.Login(loginName, password);
        }

        internal static List<Permission> GetPermissionsByUserId(string userId)
        {
            return userSrv.GetPermissionsByUserId(userId);
        }

        internal static User GetUserByLoginName(string loginName)
        {
            return userSrv.GetUserByLoginName(loginName);
        }

        internal static User GetUserByEmail(string email)
        {
            return userSrv.GetUserByEmail(email);
        }

        internal static bool InsertUser(User user, string password, out string message)
        {
            return userSrv.InsertUser(user, password, out message);
        }

        internal static List<User> GetUsers()
        {
            return userSrv.GetUsers();
        }

        internal static bool UpdateUser(User user, out string message)
        {
            return userSrv.UpdateUser(user, out message);
        }

        internal static bool UpdatePermissionsByUserId(string userId, List<Permission> permissions, out string message)
        {
            return userSrv.UpdatePermissionsByUserId(userId, permissions, out message);
        }

        #endregion


        #region Dict Services

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

        internal static List<City> GetCitiesByCountryId(string countryId)
        {
            return dictSrv.GetCitiesByCountryId(countryId);
        }

        internal static Country GetCountryByProvinceId(string provinceId)
        {
            return dictSrv.GetCountryByProvinceId(provinceId);
        }

        internal static Province GetProvinceByCityId(string cityId)
        {
            return dictSrv.GetProvinceByCityId(cityId);
        }

        internal static Dictionary<int, string> GetPermissions()
        {
            return dictSrv.GetPermissions();
        }

        internal static bool InsertCountry(Country country, out string message)
        {
            return dictSrv.InsertCountry(country, out message);
        }

        internal static bool UpdateCountry(Country country, out string message)
        {
            return dictSrv.UpdateCountry(country, out message);
        }

        internal static bool DeleteCountryByCountryId(string countryId, out string message)
        {
            return dictSrv.DeleteCountryByCountryId(countryId, out message);
        }

        internal static bool InsertProvince(Province province, out string message)
        {
            return dictSrv.InsertProvince(province, out message);
        }

        internal static bool UpdateProvince(Province province, out string message)
        {
            return dictSrv.UpdateProvince(province, out message);
        }

        internal static bool DeleteProvinceByProvinceId(string provinceId, out string message)
        {
            return dictSrv.DeleteProvinceByProvinceId(provinceId, out message);
        }

        internal static bool InsertCity(City city, out string message)
        {
            return dictSrv.InsertCity(city, out message);
        }

        internal static bool UpdateCity(City city, out string message)
        {
            return dictSrv.UpdateCity(city, out message);
        }

        internal static bool DeleteCityByCityId(string cityId, out string message)
        {
            return dictSrv.DeleteCityByCityId(cityId, out message);
        }

        #endregion


        #region Sights Service

        internal static List<Sights> GetSightsByCityId(string cityId)
        {
            return sightsSrv.GetSightsByCityId(cityId);
        }

        internal static bool InsertSights(Sights sights, out string message)
        {
            return sightsSrv.InsertSights(sights, out message);
        }

        internal static bool UpdateSights(Sights sights, out string message)
        {
            return sightsSrv.UpdateSights(sights, out message);
        }

        internal static bool DeleteSightsBySightsId(string sightsId, out string message)
        {
            return sightsSrv.DeleteSightsBySightsId(sightsId, out message);
        }

        #endregion
    }
}
