using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ICityDAL : IBaseDAL
    {
        /// <summary>
        /// 获取所有城市
        /// </summary>
        /// <returns>城市列表</returns>
        List<City> GetCities();

        /// <summary>
        /// 向数据库中插入一个城市
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertCity(City city, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一个城市
        /// </summary>
        /// <param name="city">新的城市</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateCity(City city, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一个城市
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteCity(City city, DbTransaction trans);
    }
}
