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
        /// <summary>
        /// 获取所有国家
        /// </summary>
        /// <returns>国家列表</returns>
        List<Country> GetCountries();

        /// <summary>
        /// 获取所有省份
        /// </summary>
        /// <returns>省份列表</returns>
        List<Province> GetProvinces();

        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns>城市列表</returns>
        List<City> GetCities();

        /// <summary>
        /// 获取指定国家的省份
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <returns>省份列表</returns>
        List<Province> GetProvincesByCountryId(string countryId);

        /// <summary>
        /// 获取指定省份的城市
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>城市列表</returns>
        List<City> GetCitiesByProvinceId(string provinceId);

        /// <summary>
        /// 获取指定国家的城市
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <returns>城市列表</returns>
        List<City> GetCitiesByCountryId(string countryId);

        /// <summary>
        /// 获取指定省份的国家
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>国家</returns>
        Country GetCountryByProvinceId(string provinceId);

        /// <summary>
        /// 获取指定城市的省份
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>省份</returns>
        Province GetProvinceByCityId(string cityId);

        /// <summary>
        /// 获取指定国家
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <returns>国家</returns>
        Country GetCountryByCountryId(string countryId);

        /// <summary>
        /// 获取指定省份
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>省份</returns>
        Province GetProvinceByProvinceId(string provinceId);

        /// <summary>
        /// 获取指定城市
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>城市</returns>
        City GetCityByCityId(string cityId);

        /// <summary>
        /// 获取权限类型字典
        /// </summary>
        /// <returns>权限类型字典</returns>
        Dictionary<int, string> GetPermissionsDict();

        /// <summary>
        /// 获取旅行状态字典
        /// </summary>
        /// <returns>旅行状态字典</returns>
        Dictionary<int, string> GetTourStatusDict();

        /// <summary>
        /// 新增国家
        /// </summary>
        /// <param name="country">国家</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertCountry(Country country, out string message);

        /// <summary>
        /// 更新国家
        /// </summary>
        /// <param name="country">国家</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateCountry(Country country, out string message);

        /// <summary>
        /// 删除国家
        /// </summary>
        /// <param name="country">国家</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteCountry(Country country, out string message);

        /// <summary>
        /// 新增省份
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertProvince(Province province, out string message);

        /// <summary>
        /// 更新省份
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateProvince(Province province, out string message);

        /// <summary>
        /// 删除省份
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteProvince(Province province, out string message);

        /// <summary>
        /// 新增城市
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertCity(City city, out string message);

        /// <summary>
        /// 更新城市
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateCity(City city, out string message);

        /// <summary>
        /// 删除城市
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteCity(City city, out string message);
    }
}
