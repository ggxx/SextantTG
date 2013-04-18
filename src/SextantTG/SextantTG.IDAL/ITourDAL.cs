using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ITourDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定用户的所有旅行
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursByUserId(string userId);

        /// <summary>
        /// 获取指定的旅行
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>旅行</returns>
        Tour GetTourByTourId(string tourId);

        /// <summary>
        /// 获取指定景点相关的旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>景点</returns>
        List<Tour> GetToursBySightsId(string sightsId);

        /// <summary>
        /// 获取包含指定日期的旅行
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursByDate(DateTime date);

        /// <summary>
        /// 获取与指定景点相关，包含指定日期的旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <param name="date">日期</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date);

        /// <summary>
        /// 向数据库中插入一条旅行记录
        /// </summary>
        /// <param name="tour">旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertTour(Tour tour, DbTransaction trans);

        /// <summary>
        /// 更新数据中的一条旅行记录
        /// </summary>
        /// <param name="newItem">新的旅行</param>
        /// <param name="oldItem">旧的旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateTourFromOld(Tour newItem, Tour oldItem, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条旅行记录
        /// </summary>
        /// <param name="tour">旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteTour(Tour tour, DbTransaction trans);
    }
}
