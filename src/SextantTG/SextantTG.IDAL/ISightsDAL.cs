using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISightsDAL : IBaseDAL
    {
        /// <summary>
        /// 获取全部景点
        /// </summary>
        /// <returns>景点列表</returns>
        List<Sights> GetSights();

        /// <summary>
        /// 获取指定城市的景点
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetSightsByCityId(string cityId);
        
        /// <summary>
        /// 获取指定省份的景点
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetSightsByProvinceId(string provinceId);
        
        /// <summary>
        /// 获取指定国家的景点
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetSightsByCountryId(string countryId);
        
        /// <summary>
        /// 获取指定景点
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>景点</returns>
        Sights GetSightBySightsId(string sightsId);

        /// <summary>
        /// 向数据库中插入一条景点信息
        /// </summary>
        /// <param name="sights">景点</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertSights(Sights sights, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一条景点信息
        /// </summary>
        /// <param name="newItem">新的景点</param>
        /// <param name="oldItem">旧的景点</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateSightsFromOld(Sights newItem, Sights oldItem, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条景点信息
        /// </summary>
        /// <param name="sights">景点信息</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteSights(Sights sights, DbTransaction trans);

    }
}
