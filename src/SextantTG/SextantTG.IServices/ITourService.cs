using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface ITourService : IBaseService
    {
        /// <summary>
        /// 获取指定用户的所有旅行
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursByUserId(string userId);
        
        /// <summary>
        /// 获取指定旅行
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>旅行</returns>
        Tour GetTourByTourId(string tourId);
        
        /// <summary>
        /// 获取指定景点相关的旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>旅行ID</returns>
        List<Tour> GetToursBySightsId(string sightsId);
        
        /// <summary>
        /// 获取包括指定日期的旅行
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursByDate(DateTime date);
        
        /// <summary>
        /// 获取指定景点相关，并包括指定日期的旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <param name="date">日期</param>
        /// <returns>旅行列表</returns>
        List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date);
        
        /// <summary>
        /// 删除旅行
        /// </summary>
        /// <param name="tour">旅行</param>
        /// <param name="deletePictures">是否删除相关图片</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteTour(Tour tour, bool deletePictures, out string message);
        
        /// <summary>
        /// 保存旅行
        /// </summary>
        /// <param name="tour">旅行</param>
        /// <param name="subTours">待保存的子旅行列表</param>
        /// <param name="removedSubTours">待删除的子旅行列表</param>
        /// <param name="msg">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool SaveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours, out string msg);

        /// <summary>
        /// 获取指定旅行的子旅行
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>子旅行列表</returns>
        List<SubTour> GetSubToursByTourId(string tourId);
        
        /// <summary>
        /// 获取指定子旅行
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
        /// 获取指定景点相关的所有子旅行
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>子旅行列表</returns>
        List<SubTour> GetSubToursBySightsId(string sightsId);

        /// <summary>
        /// 获取指定旅行的图片
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesByTourId(string tourId);
        
        /// <summary>
        /// 获取指定子旅行的图片
        /// </summary>
        /// <param name="tourId">旅行ID</param>
        /// <param name="subTourId">子旅行ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId);
    }
}
