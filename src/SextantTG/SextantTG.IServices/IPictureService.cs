using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface IPictureService : IBaseService
    {
        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="pictures">待保存的图片列表</param>
        /// <param name="removedPictures">待删除的图片列表</param>
        /// <param name="message">操作信息</param>
        /// <returns>操作是否成功</returns>
        bool SavePictures(List<Picture> pictures, List<Picture> removedPictures, out string message);
        
        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="pictureId">图片ID</param>
        /// <returns>图片</returns>
        Picture GetPictureByPictureId(string pictureId);
    }
}
