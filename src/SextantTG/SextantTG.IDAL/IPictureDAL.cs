using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IPictureDAL : IBaseDAL
    {
        /// <summary>
        /// 获取指定用户上传的关于指定景点的图片
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <param name="uploaderId">用户ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId);
        
        /// <summary>
        /// 获取指定景点的图片
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesBySightsId(string sightsId);
        
        /// <summary>
        /// 获取指定旅行的图片
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesByTourId(string tourId);
        
        /// <summary>
        /// 获取指定旅行中一次子旅行的图片
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <param name="subTourId">子旅行ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId);
        
        /// <summary>
        /// 获取指定图片
        /// </summary>
        /// <param name="picId">图片ID</param>
        /// <returns>图片</returns>
        Picture GetPictureByPictureId(string picId);

        /// <summary>
        /// 向数据库中插入一条图片记录
        /// </summary>
        /// <param name="pic">图片</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int InsertPicture(Picture pic, DbTransaction trans);
        
        /// <summary>
        /// 更新数据库中的一条图片记录
        /// </summary>
        /// <param name="pic">新的图片</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int UpdatePicture(Picture pic, DbTransaction trans);
        
        /// <summary>
        /// 删除数据库中的一条图片记录
        /// </summary>
        /// <param name="pic">图片</param>
        /// <param name="trans">数据库事务</param>
        /// <returns>数据库中发生变更的行数</returns>
        int DeletePicture(Picture pic, DbTransaction trans);
    }
}
