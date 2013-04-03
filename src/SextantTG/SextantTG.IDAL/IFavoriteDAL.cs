using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IFavoriteDAL : IBaseDAL
    {
        /// <summary>
        /// 获取所有用户收藏
        /// </summary>
        /// <returns>用户收藏列表</returns>
        List<Favorite> GetFavorites();
        
        /// <summary>
        /// 获取指定用户的收藏
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>用户收藏列表</returns>
        List<Favorite> GetFavoritesByUserId(string userId);
        
        /// <summary>
        /// 获取指定景点的用户收藏
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>用户收藏列表</returns>
        List<Favorite> GetFavoritesBySightsId(string sightsId);
        
        /// <summary>
        /// 获取指定用户对于指定景点的收藏
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="sightsId">景点ID</param>
        /// <returns>用户收藏</returns>
        Favorite GetFavoriteByUserIdAndSightsId(string userId, string sightsId);
        
        /// <summary>
        /// 获取指定景点的平均评分
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>平均评分</returns>
        float? GetAverageStarsBySightsId(string sightsId);

        /// <summary>
        /// 向数据库中插入一条用户收藏
        /// </summary>
        /// <param name="favorite">用户收藏</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertFavorite(Favorite favorite, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一条用户收藏
        /// </summary>
        /// <param name="favorite">新的用户收藏</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateFavorite(Favorite favorite, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条用户收藏
        /// </summary>
        /// <param name="favorite">用户收藏</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteFavorite(Favorite favorite, DbTransaction trans);
    }
}
