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
    public class FavoriteDAL : IFavoriteDAL
    {
        private DbHelper dbHelper = null;

        public FavoriteDAL()
        {
            this.dbHelper = new DbHelper(ConfigurationManager.ConnectionStrings["SQLiteConnection"].ConnectionString, DbUtil.DbProviderType.SQLite);
        }

        public FavoriteDAL(string connectionString)
        {
            this.dbHelper = new DbHelper(connectionString, DbUtil.DbProviderType.SQLite);
        }
        
        private static readonly string SELECT = "select * from stg_favorite";
        private static readonly string SELECT___USER_ID = "select * from stg_favorite where user_id = :UserId";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_favorite where sights_id = :SightsId";
        private static readonly string SELECT___USER_ID__SIGHTS_ID = "select * from stg_favorite where user_id = :UserId and sights_id = :SightsId";
                
        private static readonly string INSERT = "insert into stg_favorite(user_id, sights_id, visited, stars, creating_time) values(:UserId, :SightsId, :Visited, :Stars, :CreatingTime)";
        private static readonly string UPDATE = "update stg_favorite set user_id = :UserId, sights_id = :SightsId, visited = :Visited, stars = :Stars, creating_time = :CreatingTime  where user_id = :UserId" ;
        private static readonly string DELETE = "delete from stg_favorite where user_id = :UserId";

        private Favorite BuildFavoriteByReader(DbDataReader r)
        {
            Favorite favorite = new Favorite();
            favorite.UserId = TypeConverter.ToString(r["user_id"]);
            favorite.SightsId = TypeConverter.ToString(r["sights_id"]);
            favorite.Visited = TypeConverter.ToDateTimeNull(r["visited"]);
            favorite.Stars = TypeConverter.ToString(r["stars"]);
            favorite.CreatingtTime = TypeConverter.ToString(r["creating_time"]);
           
            return favorite;
        }

        public List<Favorite> GetFavorites()
        {
            List<Favorite> favorites = new List<Favorite>();
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
        }

        public List<Favorite> GetFavoritesByUserId(string userId)
        {
            List<Favorite> favorites = new List<Favorite>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
        }

        public List<Favorite> GetFavoritesBySightsId(string SightsId)
        {
            List<User> users = new List<User>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
        }


        public List<Favorite> GetFavoritesByUserIdAndSightsId(string UserId, string SightsId)
        {
            List<Favorite> favorites = new List<Favorite>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID__SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
        }

      
       public Favorite GetFavoriteByUserId(string userId)
        {
            Favorite favorite = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID, pars))
            {
                if (r.Read())
                {
                    favorite = BuildFavoriteByReader(r);
                }
            }
            return favorite;
        }

        public Favorite GetFavoriteBySightsId(string SightsId)
        {
            Favorite favorite = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                if (r.Read())
                {
                    favorite = BuildFavoriteByReader(r);
                }
            }
            return favorite;
        }

        public Favorite GetFavoriteByUserIdAndSightsId(string UserId, string SightsId)
        {
            Favorite favorite = null;
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", UserId);
            pars.Add("SightsId", SightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID__SIGHTS_ID, pars))
            {
                if (r.Read())
                {
                    favorite = BuildFavoriteByReader(r);
                }
            }
            return favorite;
        }
       
        public int InsertFavorite(Favorite favorite, DbTransaction trans)
        {
            favorite.CreatingTime = DateTime.Now;
            
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", favorite.UserId);
            pars.Add("SightsId", favorite.SightsId);
            pars.Add("Visited", favorite.Visited);
            pars.Add("Stars", favorite.Stars);
            pars.Add("CreatingTime", favorite.CreatingTime);
            return dbHelper.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateFavorite(Favorite favorite, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", favorite.UserId);
            pars.Add("SightsId", favorite.SightsId);
            pars.Add("Visited", favorite.Visited);
            pars.Add("Stars", favorite.Stars);
            pars.Add("CreatingTime", favorite.CreatingTime);
            return dbHelper.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavoriteByUserId(string userId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }
    }
}
