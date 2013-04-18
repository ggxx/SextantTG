using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IPictureCommentDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定图片的评论
        /// </summary>
        /// <param name="pictureId">图片ID</param>
        /// <returns>图片评论列表</returns>
        List<PictureComment> GetPictureCommentsByPictureId(string pictureId);

        /// <summary>
        /// 向数据库中插入一条图片评论
        /// </summary>
        /// <param name="comment">图片评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertPictureComment(PictureComment comment, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一条图片评论
        /// </summary>
        /// <param name="comment">新的图片评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdatePictureComment(PictureComment comment, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条图片评论
        /// </summary>
        /// <param name="comment">图片评论</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeletePictureComment(PictureComment comment, DbTransaction trans);
    }
}
