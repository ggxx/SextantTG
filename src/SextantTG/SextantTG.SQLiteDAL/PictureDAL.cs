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
        private static readonly string SELECT___USER_ID = "select * from stg_picture where user_id = :UserId";
        private static readonly string SELECT___BLOG_ID__SIGHTS_ID__USER_ID = "select * from stg_picture where blog_id = :BlogId and sights_id = :SightsId and user_id = :UserId";
                
        private static readonly string INSERT = "insert into stg_picture(picture_id, sights_id, blog_id, path, description, user_id, creating_time ) values(:PictureId, :SightsId, :BlogId, :Path, :Description, :UserId, CreatingTime)";
        private static readonly string UPDATE = "update stg_picture set picture_id = :PictureId, sights_id = :SightsId, blog_id = :BlogId, path = :Path, description = :Description, user_id = :UserId, creating_time = :CreatingTime  where picture_id = :PictureId" ;
        private static readonly string DELETE = "delete from stg_picture where picture_id = :PictureId";

        private Picture BuildPictureByReader(DbDataReader r)
        {
            Picture picture = new Picture();
            picture.PictureId = TypeConverter.ToString(r["picture_id"]);
            picture.SightsId = TypeConverter.ToString(r["sights_id"]);
            picture.BlogId = TypeConverter.ToDateTimeNull(r["blog_id"]);
            picture.Path = TypeConverter.ToString(r["path"]);
            picture.Description = TypeConverter.ToString(r["description"]);
            picture.UserId = TypeConverter.ToString(r["user_id"]);
            picture.CreatingTime = TypeConverter.ToString(r["creating_time"]);
           
            return picture;
        }

        public List<Picture> GetPictures()
        {
            List<Picture> Pictures = new List<Picture>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    Pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public List<Picture> GetPicturesByUserId(string userId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    Pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public List<Picture> GetPicturesByPictureId(string PictureId)
        {
            List<Picture> Pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", PictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }


        public List<Picture> GetPicturesBySightsId(string SightsId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

      
        public List<Picture> GetPicturesByBlogId(string BlogId)
        {
            List<Picture> pictures = new List<Picture>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", BlogId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___BLOG_ID, pars))
            {
                while (r.Read())
                {
                    pictures.Add(BuildPictureByReader(r));
                }
            }
            return pictures;
        }

        public Picture GetPictureById(string PictureId)
        {
            Picture picture = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", PictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                if (r.Read())
                {
                    picture = BuildPictureByReader(r);
                }
            }
            return picture;
        }

        public Picture GetPictureBySightsId(string SightsId)
        {
            Picture picture = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                if (r.Read())
                {
                    Picture = BuildPictureByReader(r);
                }
            }
            return Picture;
        }

        public Picture GetPictureByBLogId(string BLogId)
        {
            Picture Picture = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BLogId", BLogId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___BLOG_ID, pars))
            {
                if (r.Read())
                {
                    Picture = BuildPictureByReader(r);
                }
            }
            return picture;
        }

        public Picture GetPictureByUserId(string UserId)
        {
            Picture Picture = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                if (r.Read())
                {
                    Picture = BuildPictureByReader(r);
                }
            }
            return picture;
        }

        public Picture GetPictureByBlogIDAndSightsIDAndUserId(string BlogId, String SightsID,string UserId)
        {
            Picture Picture = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("BlogId", BlogId);
            pars.Add("SightsID", SightsID);
            pars.Add("UserId", UserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___BLOG_ID__SIGHTS_ID__USER_ID, pars))
            {
                if (r.Read())
                {
                    picture = BuildPictureByReader(r);
                }
            }
            return picture;
        }



        public int InsertPicture(Picture picture, DbTransaction trans)
        {
            picture.UserId = StringHelper.CreateGuid();
            picture.CreatingTime = DateTime.Now;
            
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", picture.PictureId);
            pars.Add("SightsId", picture.SightsId);
            pars.Add("BlogId", picture.BlogId);
            pars.Add("Path", picture.Path);
            pars.Add("Description", picture.Description);
            pars.Add("UserId", picture.UserId);
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
            pars.Add("UserId", picture.UserId);
            pars.Add("CreatingTime", picture.CreatingTime);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeletePictureById(string PictureId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", PictureId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
