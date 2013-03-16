using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
using System.Configuration;

namespace SextantTG.SQLiteDAL
{
    public class PictureDAL : IPictureDAL
    {
        private DbHelper dbHelper = null;

        public PictureDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public PictureDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }

        private static readonly string SELECT___SIGHTS_ID__USER_ID = "select * from stg_picture where sights_id = :SightsId and user_id = :UserId  order by creating_time desc";
        private static readonly string SELECT___PICTURE_ID = "select * from stg_picture where picture_id = :PictureId  order by creating_time desc";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_picture where sights_id = :SightsId  order by creating_time desc";
        private static readonly string SELECT___TOUR_ID = "select * from stg_picture where tour_id = :TourId  order by creating_time desc";
        private static readonly string SELECT___TOUR_ID__SUB_TOUR_ID = "select * from stg_picture where tour_id = :TourId and sub_tour_id = :SubTourId  order by creating_time desc"; 
                
        private static readonly string INSERT = "insert into stg_picture(picture_id, sights_id, tour_id, sub_tour_id, path, description, user_id, creating_time ) values(:PictureId, :SightsId, :TourId, :SubTourId, :Path, :Description, :UserId, :CreatingTime)";
        private static readonly string UPDATE = "update stg_picture set sights_id = :SightsId, tour_id = :TourId, sub_tour_id = :SubTourId, path = :Path, description = :Description, user_id = :UserId, creating_time = :CreatingTime  where picture_id = :PictureId" ;
        private static readonly string DELETE___PICTURE_ID = "delete from stg_picture where picture_id = :PictureId";
        private static readonly string DELETE___TOUR_ID = "delete from stg_picture where tour_id = :TourId";

        private Picture BuildPictureByReader(DbDataReader r)
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

        public List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            pars.Add("UserId", uploaderId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID__USER_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public List<Picture> GetPicturesBySightsId(string sightsId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public List<Picture> GetPicturesByTourId(string tourId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }


        public List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            pars.Add("SubTourId", subTourId); 
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___TOUR_ID__SUB_TOUR_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public Picture GetPictureByPictureId(string pictureId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                if (r.Read())
                {
                    return BuildPictureByReader(r);
                }
            }
            return null;
        }


        public int InsertPicture(Picture picture, DbTransaction trans)
        {
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
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
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
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeletePictureByPictureId(string pictureId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", pictureId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___PICTURE_ID, pars);
        }

        public int DeletePictureByTourId(string tourId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("TourId", tourId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___TOUR_ID, pars);
        }
        public void Dispose()
        {
            this.dbHelper.Dispose();
        }





    }
}
