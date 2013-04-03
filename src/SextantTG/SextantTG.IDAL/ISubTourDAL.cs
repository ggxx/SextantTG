using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISubTourDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定旅行的所有子旅行
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>子旅行列表</returns>
        List<SubTour> GetSubToursByTourId(string tourId);
        
        /// <summary>
        /// 获取指定旅行中一次指定的子旅行
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <param name="subTourId">子旅行ID</param>
        /// <returns>子旅行</returns>
        SubTour GetSubTourByTourIdAndSubTourId(string tourId, string subTourId);
        
        /// <summary>
        /// 获取指定用户的子旅行
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>子旅行列表</returns>
        List<SubTour> GetSubToursByUserId(string userId);
        
        /// <summary>
        /// 获取指定景点所有的子旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>子旅行列表</returns>
        List<SubTour> GetSubToursBySightsId(string sightsId);

        /// <summary>
        /// 向数据库中插入一条子旅行
        /// </summary>
        /// <param name="subTour">子旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertSubTour(SubTour subTour, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一条子旅行
        /// </summary>
        /// <param name="newItem">新的子旅行</param>
        /// <param name="oldItem">旧的子旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateSubTourFromOld(SubTour newItem, SubTour oldItem, DbTransaction trans);

        /// <summary>
        /// 删除数据库中的一条子旅行
        /// </summary>
        /// <param name="subTour">子旅行</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteSubTour(SubTour subTour, DbTransaction trans);

    }
}
