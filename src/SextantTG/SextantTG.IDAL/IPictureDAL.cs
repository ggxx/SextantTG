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
        List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId);
        List<Picture> GetPicturesBySightsId(string sightsId);
        List<Picture> GetPicturesByTourId(string tourId);
        List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId);
        Picture GetPictureByPictureId(string picId);

        int InsertPicture(Picture pic, DbTransaction trans);
        int UpdatePicture(Picture pic, DbTransaction trans);
        int DeletePictureByPictureId(string picId, DbTransaction trans);
        //int DeletePicturesBySightsId(string sightsId, DbTransaction trans);
        //int DeletePicturesByBlogId(string blogId, DbTransaction trans);
        int DeletePictureByTourId(string tourId, DbTransaction trans);
    }
}
