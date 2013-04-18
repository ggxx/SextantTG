using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;
using SextantTG.PSAop;

namespace SextantTG.OracleDAL
{
    [MethodAspect]
    public class PictureDAL : AbstractDAL<Picture>, IPictureDAL
    {
        public PictureDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override Picture BuildObjectByReader(DbDataReader r)
        {
            Picture picture = new Picture();
            picture.PictureId = CustomTypeConverter.ToString(r["picture_id"]);
            picture.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            picture.TourId = CustomTypeConverter.ToString(r["tour_id"]);
            picture.SubTourId = CustomTypeConverter.ToString(r["sub_tour_id"]);
            picture.Path = CustomTypeConverter.ToString(r["path"]);
            picture.Description = CustomTypeConverter.ToString(r["description"]);
            picture.UploaderId = CustomTypeConverter.ToString(r["user_id"]);
            picture.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            return picture;
        }

        private static readonly string SELECT___SIGHTS_ID__USER_ID = "select * from stg_picture where sights_id = :SightsId and user_id = :UserId  order by creating_time desc";
        private static readonly string SELECT___PICTURE_ID = "select * from stg_picture where picture_id = :PictureId  order by creating_time desc";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_picture where sights_id = :SightsId  order by creating_time desc";
        private static readonly string SELECT___TOUR_ID = "select * from stg_picture where tour_id = :TourId  order by creating_time desc";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_picture where tour_id = :TourId and sub_tour_id = :SubTourId  order by creating_time desc";

        private static readonly string INSERT = "insert into stg_picture(picture_id, sights_id, tour_id, sub_tour_id, path, description, user_id, creating_time ) values(:PictureId, :SightsId, :TourId, :SubTourId, :Path, :Description, :UserId, :CreatingTime)";
        private static readonly string UPDATE = "update stg_picture set sights_id = :SightsId, tour_id = :TourId, sub_tour_id = :SubTourId, path = :Path, description = :Description, user_id = :UserId, creating_time = :CreatingTime  where picture_id = :PictureId";
        private static readonly string DELETE___PICTURE_ID = "delete from stg_picture where picture_id = :PictureId";
        //private static readonly string DELETE___TOUR_ID = "delete from stg_picture where tour_id = :TourId";


        public List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            pars.Add("UserId", uploaderId);
            return this.GetList(SELECT___SIGHTS_ID__USER_ID, pars);
        }

        public List<Picture> GetPicturesBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public List<Picture> GetPicturesByTourId(string tourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return this.GetList(SELECT___TOUR_ID, pars);
        }


        public List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId);
            return this.GetList(SELECT___TOUR_ID__SUB_TOUR_ID, pars);
        }

        public Picture GetPictureByPictureId(string pictureId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            return this.GetObject(SELECT___PICTURE_ID, pars);
        }

        public int InsertPicture(Picture picture, DbTransaction trans)
        {
            if (string.IsNullOrEmpty(picture.PictureId))
                picture.PictureId = Util.StringHelper.CreateGuid();
            picture.CreatingTime = DateTime.Now;

            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", picture.PictureId);
            pars.Add("SightsId", picture.SightsId);
            pars.Add("TourId", picture.TourId);
            pars.Add("SubTourId", picture.SubTourId);
            pars.Add("Path", picture.Path);
            pars.Add("Description", picture.Description);
            pars.Add("UserId", picture.UploaderId);
            pars.Add("CreatingTime", picture.CreatingTime);
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdatePicture(Picture picture, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", picture.PictureId);
            pars.Add("SightsId", picture.SightsId);
            pars.Add("TourId", picture.TourId);
            pars.Add("SubTourId", picture.SubTourId);
            pars.Add("Path", picture.Path);
            pars.Add("Description", picture.Description);
            pars.Add("UserId", picture.UploaderId);
            pars.Add("CreatingTime", picture.CreatingTime);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        //public int UpdatePictureFromOld(Picture newItem, Picture oldItem, DbTransaction trans)
        //{
        //    Picture pic = (Picture)newItem.Clone();
        //    pic.PictureId = oldItem.PictureId;
        //    return UpdatePicture(pic, trans);
        //}

        public int DeletePicture(Picture pic, DbTransaction trans)
        {
            return DeletePictureByPictureId(pic.PictureId, trans);
        }

        private int DeletePictureByPictureId(string pictureId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            return this.ExecuteNonQuery(trans, DELETE___PICTURE_ID, pars);
        }

        //public int DeletePictureByTourId(string tourId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("TourId", tourId);
        //    return this.ExecuteNonQuery(trans, DELETE___TOUR_ID, pars);
        //}

    }
}
