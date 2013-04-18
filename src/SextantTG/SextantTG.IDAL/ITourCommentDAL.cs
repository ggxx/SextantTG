using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ITourCommentDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定旅行的评论
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>旅行评论列表</returns>
        List<TourComment> GetTourCommentsByTourId(string tourId);

        /// <summary>
        /// 向数据库中插入一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertTourComment(TourComment comment, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateTourComment(TourComment comment, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条旅行评论
        /// </summary>
        /// <param name="comment">旅行评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteTourComment(TourComment comment, DbTransaction trans);        
    }
}
