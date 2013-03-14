using SextantTG.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SexTantTG.DbUtil;
using System.Data.Common;
using SextantTG.Util;
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
        private static readonly string UPDATE = "update stg_favorite set visited = :Visited, stars = :Stars, creating_time = :CreatingTime  where user_id = :UserId and sights_id = :SightsId";
        private static readonly string DELETE = "delete from stg_favorite where user_id = :UserId and sights_id = :SightsId";
        private static readonly string DELETE___USER_ID = "delete from stg_favorite where user_id = :UserId";
        private static readonly string DELETE___SIGHTS_ID = "delete from stg_favorite where sights_id = :SightsId";

        private Favorite BuildFavoriteByReader(DbDataReader r)
        {
            Favorite favorite = new Favorite();
            favorite.UserId = TypeConverter.ToString(r["user_id"]);
            favorite.SightsId = TypeConverter.ToString(r["sights_id"]);
            favorite.Visited = TypeConverter.ToInt32Null(r["visited"]);
            favorite.Stars = TypeConverter.ToInt32Null(r["stars"]);
            favorite.CreatingTime = TypeConverter.ToDateTimeNull(r["creating_time"]);

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

        public List<Favorite> GetFavoritesBySightsId(string sightsId)
        {
            List<Favorite> favorites = new List<Favorite>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
        }

        public List<Favorite> GetFavoriteByUserIdAndSightsId(string userId, string sightsId)
        {
            List<Favorite> favorites = new List<Favorite>();
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            using (DbDataReader r = dbHelper.ExecuteReader(SELECT___USER_ID__SIGHTS_ID, pars))
            {
                while (r.Read())
                {
                    favorites.Add(BuildFavoriteByReader(r));
                }
            }
            return favorites;
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

        public int DeleteFavoriteByUserIdAndSightsId(string userId, string sightsId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            return dbHelper.ExecuteNonQuery(trans, DELETE, pars);
        }

        public int DeleteFavoriteByUserId(string userId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___USER_ID, pars);
        }

        public int DeleteFavoriteBySightsId(string sightsId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return dbHelper.ExecuteNonQuery(trans, DELETE___SIGHTS_ID, pars);
        }

        public void Dispose()
        {
            this.dbHelper = null;
        }



    }
}
