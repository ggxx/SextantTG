using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISightsCommentDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定景点的评论
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>景点评论列表</returns>
        List<SightsComment> GetSightsCommentsBySightsId(string sightsId);

        /// <summary>
        /// 向数据库中插入一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertSightsComment(SightsComment comment, DbTransaction trans);

        /// <summary>
        /// 更新数据库中的一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdateSightsComment(SightsComment comment, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条景点评论
        /// </summary>
        /// <param name="comment">景点评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeleteSightsComment(SightsComment comment, DbTransaction trans);
    }
}
