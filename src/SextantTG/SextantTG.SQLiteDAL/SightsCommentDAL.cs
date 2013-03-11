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
    public class SightsCommentDAL : ISightsCommentDAL
    {
        private DbHelper dbHelper = null;

        public SightsCommentDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public SightsCommentDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_sightscomment";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_sightscomment where sights_id = :SightsId";
        private static readonly string SELECT___COMM_USER_ID = "select * from stg_sightscomment where comm_user_id = :CommUserId";
                        
        private static readonly string INSERT = "insert into stg_sightscomment(sights_id, comm_user_id, creating_time, comment) values(:SightsId, :CommUserId, :CreatingTime, :Comment)";
        private static readonly string UPDATE = "update stg_sightscomment set sights_id = :SightsId, comm_user_id = :CommUserId, creating_time = :CreatingTime, comment = :Comment where sights_id = :SightsId" ;
        private static readonly string DELETE = "delete from stg_sightscomment where sights_id = :SightsId";

        private SightsComment BuildSightsCommentByReader(DbDataReader r)
        {
            SightsComment sightscomment = new Favorite();
            sightscomment.SightsId = TypeConverter.ToString(r["sights_id"]);
            sightscomment.CommUserId = TypeConverter.ToString(r["comm_user_id"]);
            sightscomment.CreatingtTime = TypeConverter.ToString(r["creating_time"]);
            sightscomment.Comment = TypeConverter.ToDateTimeNull(r["comment"]);           
           
            return sightscomment;
        }

        public List<SightsComment> GetSightsComments()
        {
            List<SightsComment> sightscomments = new List<SightsComment>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    sightscomments.Add(BuildSightsCommentByReader(r));
                }
            }
            return sightscomments;
        }

       
        public List<SightsComment> GetSightsCommentsBySightsId(string SightsId)
        {
            List<SightsComment> sightscomments = new List<SightsComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    sightscomments.Add(BuildSightsCommentByReader(r));
                }
            }
            return sightscomments;
        }


        public List<SightsComment> GetSightsCommentsByCommUserId(string CommUserId)
        {
            List<SightsComment> sightscomments = new List<SightsComment>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                while (r.Read())
                {
                    sightscomments.Add(BuildSightsCommentByReader(r));
                }
            }
            return sightscomments;
        }

      
       public SightsComment GetSightsCommentBySightsId(string SightsId)
        {
            SightsComment sightscomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                if (r.Read())
                {
                    sightscomment = BuildSightsCommentByReader(r);
                }
            }
            return sightscomment;
        }

        public SightsComment GetSightsCommentByCommUserId(string CommUserId)
        {
            SightsComment sightscomment = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("CommUserId", CommUserId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___COMM_USER_ID, pars))
            {
                if (r.Read())
                {
                    sightscomment = BuildSightsCommentByReader(r);
                }
            }
            return sightscomment;
        }

      
        public int InsertSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            picturecomment.CreatingTime = DateTime.Now;         
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateSightsComment(SightsComment sightscomment, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightscomment.SightsId);
            pars.Add("CommUserId", sightscomment.CommUserId);
            pars.Add("CreatingTime", sightscomment.CreatingTime);
            pars.Add("Comment", sightscomment.Comment);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavoriteBySightsId(string SightsId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
