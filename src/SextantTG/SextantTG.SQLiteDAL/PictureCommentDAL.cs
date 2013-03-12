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
    public class PictureCommentDAL : IPictureCommentDAL
    {
        private DbHelper dbHelper = null;

        public PictureCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public PictureCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_picturecomment";
        private static readonly string SELECT___PICTURE_ID = "select * from stg_picturecomment where picture_id = :PictureId";
        private static readonly string SELECT___COMM_USER_ID = "select * from stg_picturecomment where comm_user_id = :CommUserId";
                        
        private static readonly string INSERT = "insert into stg_picturecomment(picture_id, comm_user_id, creating_time, comment) values(:PictureId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_picturecomment set picture_id = :PictureId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where picture_id = :PictureId" ;
        private static readonly string DELETE = "delete from stg_picturecomment where picture_id = :PictureId";

        private PictureComment BuildPictureCommentByReader(DbDataReader r)
        {
            PictureComment picturecomment = new PictureComment();
            picturecomment.PictureId = TypeConverter.ToString(r["picture_id"]);
            picturecomment.CommUserId = TypeConverter.ToString(r["comm_user_id"]);
            picturecomment.CreatingtTime = TypeConverter.ToString(r["creating_time"]);
            picturecomment.Comment = TypeConverter.ToDateTimeNull(r["comment"]);           
           
            return picturecomment;
        }

        public List<PictureComment> GetPictureComments()
        {
            List<PictureComment> picturecomments = new List<PictureComment>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    picturecomments.Add(BuildPictureCommentByReader(r));
                }
            }
            return picturecomments;
        }

       
        public List<PictureComment> GetPictureCommentsByPictureId(string PictureId)
        {
            List<PictureComment> picturecomments = new List<PictureComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", PictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                while (r.Read())
                {
                    picturecomments.Add(BuildPictureCommentByReader(r));
                }
            }
            return picturecomments;
        }


        public List<PictureComment> GetPictureCommentsByCommUserId(string CommUserId)
        {
            List<PictureComment> picturecomments = new List<PictureComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                while (r.Read())
                {
                    picturecomments.Add(BuildPictureCommentByReader(r));
                }
            }
            return picturecomments;
        }

      
       public PictureComment GetPictureCommentByPictureId(string PictureId)
        {
            PictureComment picturecomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", PictureId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___PICTURE_ID, pars))
            {
                if (r.Read())
                {
                    picturecomment = BuildPictureCommentByReader(r);
                }
            }
            return picturecomment;
        }

        public PictureComment GetPictureCommentByCommUserId(string CommUserId)
        {
            PictureComment picturecomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                if (r.Read())
                {
                    picturecomment = BuildPictureCommentByReader(r);
                }
            }
            return picturecomment;
        }

      
        public int InsertPictureComment(PictureComment picturecomment, DbTransaction trans)
        {
            picturecomment.CreatingTime = DateTime.Now;                      
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", picturecomment.PictureId);
            pars.Add("CommUserId", picturecomment.CommUserId);
            pars.Add("CreatingTime", picturecomment.CreatingTime);
            pars.Add("Comment", picturecomment.Comment);
            
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdatePictureComment(PictureComment picturecomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("PictureId", picturecomment.PictureId);
            pars.Add("CommUserId", picturecomment.CommUserId);
            pars.Add("CreatingTime", picturecomment.CreatingTime);
            pars.Add("Comment", picturecomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavoriteByPictureId(string PictureId, DbTransaction trans)
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
