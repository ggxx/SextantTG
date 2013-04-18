using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ICountryDAL : IBaseDAL
    {
        /// <summary>
        /// 获取所有的国家
        /// </summary>
        /// <returns></returns>
        List<Country> GetCountries();

        /// <summary>
        /// 向数据库中插入一个国家
        /// </summary>
        /// <param name="country">国家</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertCountry(Country country, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一个国家
        /// </summary>
        /// <param name="country">新的国家</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateCountry(Country country, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一个国家
        /// </summary>
        /// <param name="country">国家</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteCountry(Country country, DbTransaction trans);
    }
}
