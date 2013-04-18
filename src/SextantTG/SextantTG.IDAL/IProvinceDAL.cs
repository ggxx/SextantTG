using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IProvinceDAL : IBaseDAL
    {
        /// <summary>
        /// 获取所有省份
        /// </summary>
        /// <returns>省份列表</returns>
        List<Province> GetProvinces();

        /// <summary>
        /// 向数据库中插入一条省份记录
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertProvince(Province province, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一条省份记录
        /// </summary>
        /// <param name="province">新的省份</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateProvince(Province province, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条省份记录
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteProvince(Province province, DbTransaction trans);
    }
}
