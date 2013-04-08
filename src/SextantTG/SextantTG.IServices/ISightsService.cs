using System.Collections.Generic;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface ISightsService : IBaseService
    {
        /// <summary>
        /// 获取所有景点
        /// </summary>
        /// <returns>景点列表</returns>
        List<Sights> GetSights();
        
        /// <summary>
        /// 获取指定国家的景点
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <returns>景点ID</returns>
        List<Sights> GetSightsByCountryId(string countryId);
        
        /// <summary>
        /// 获取指定省份的景点
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetSightsByProvinceId(string provinceId);
        
        /// <summary>
        /// 获取指定城市的景点
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetSightsByCityId(string cityId);
        
        /// <summary>
        /// 获取指定景点
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>景点</returns>
        Sights GetSightsBySightsId(string sightsId);
        
        /// <summary>
        /// 获取指定景点的平均评分
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <returns>分数</returns>
        float? GetAverageStarsBySightsId(string sightsId);
        
        /// <summary>
        /// 获取指定用户上传的指定景点的图片
        /// </summary>
        /// <param name="sightsId">景点ID</param>
        /// <param name="uploaderId">用户ID</param>
        /// <returns>图片列表</returns>
        List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId);
        
        /// <summary>
        /// 获取用户游览过的景点
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetVisitedSights(string userId);
        
        /// <summary>
        /// 获取用户游览过的指定国家的景点
        /// </summary>
        /// <param name="countryId">国家ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetVisitedSightsByCountryId(string countryId, string userId);
        
        /// <summary>
        /// 获取用户游览过的指定省份的景点
        /// </summary>
        /// <param name="provinceId">省份ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetVisitedSightsByProvinceId(string provinceId, string userId);
        
        /// <summary>
        /// 获取用户浏览过的指定城市的景点
        /// </summary>
        /// <param name="cityId">城市ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>景点列表</returns>
        List<Sights> GetVisitedSightsByCityId(string cityId, string userId);

        /// <summary>
        /// 新增景点
        /// </summary>
        /// <param name="sights">景点</param>
        /// <param name="pictures">相关图片</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool InsertSights(Sights sights, List<Picture> pictures, out string message);
        
        /// <summary>
        /// 更新景点
        /// </summary>
        /// <param name="sights">景点</param>
        /// <param name="pictures">待更新图片</param>
        /// <param name="removedPictures">待删除图片</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool UpdateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures, out string message);
        
        /// <summary>
        /// 删除景点
        /// </summary>
        /// <param name="sights">景点</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool DeleteSights(Sights sights, out string message);
    }
}
