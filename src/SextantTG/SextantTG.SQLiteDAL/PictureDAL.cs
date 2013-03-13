using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantGT.Util;
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
        
        private static readonly string SELECT = "select * from stg_picture";
        private static readonly string SELECT___PICTURE_ID = "select * from stg_picture where picture_id = :PictureId";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_picture where sights_id = :SightsId";
        private static readonly string SELECT___BLOG_ID = "select * from stg_picture where blog_id = :BlogId";
        //private static readonly string SELECT___USER_ID = "select * from stg_picture where user_id = :UserId";
        //private static readonly string SELECT___BLOG_ID__SIGHTS_ID__USER_ID = "select * from stg_picture where blog_id = :BlogId and sights_id = :SightsId and user_id = :UserId";
                
        private static readonly string INSERT = "insert into stg_picture(picture_id, sights_id, blog_id, path, description, user_id, creating_time ) values(:PictureId, :SightsId, :BlogId, :Path, :Description, :UserId, :CreatingTime)";
        private static readonly string UPDATE = "update stg_picture set sights_id = :SightsId, blog_id = :BlogId, path = :Path, description = :Description, user_id = :UserId, creating_time = :CreatingTime  where picture_id = :PictureId" ;
        private static readonly string DELETE = "delete from stg_picture where picture_id = :PictureId";

        private Picture BuildPictureByReader(DbDataReader r)
        {
            Picture picture = new Picture();
            picture.PictureId = TypeConverter.ToString(r["picture_id"]);
            picture.SightsId = TypeConverter.ToString(r["sights_id"]);
            picture.BlogId = TypeConverter.ToString(r["blog_id"]);
            picture.Path = TypeConverter.ToString(r["path"]);
            picture.Description = TypeConverter.ToString(r["description"]);
            picture.UploaderId = TypeConverter.ToString(r["user_id"]);
            picture.CreatingTime = TypeConverter.ToDateTimeNull(r["creating_time"]);
            return picture;
        }

        public List<Picture> GetPictures()
        {
            List<Picture> pictures = new List<Picture>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        //public List<Picture> GetPicturesByUserId(string userId)
        //{
        //    List<Picture> pictures = new List<Picture>();
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("UserId", userId);
        //    using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
        //    {
        //        while (r.Read())
        //        {
        //            pictures.Add(BuildPictureByReader(r));
        //        }
        //    }
        //    return pictures;
        //}

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

        public List<Picture> GetPicturesByBlogId(string blogId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", blogId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___BLOG_ID, pars))
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
            pars.Add("BlogId", picture.BlogId);
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
            pars.Add("BlogId", picture.BlogId);
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
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
