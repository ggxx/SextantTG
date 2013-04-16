using System;
using System.Collections.Generic;
using System.Data.Common;
using SextantTG.ActiveRecord;
using SextantTG.IDAL;
using SextantTG.Util;
using SextantTG.PSAop;

namespace SextantTG.OracleDAL
{
    [MethodAspect]
    public class FavoriteDAL : AbstractDAL<Favorite>, IFavoriteDAL
    {
        public FavoriteDAL() { }

        [MethodAspect(AttributeExclude = true)]
        protected override Favorite BuildObjectByReader(DbDataReader r)
        {
            Favorite favorite = new Favorite();
            favorite.UserId = CustomTypeConverter.ToString(r["user_id"]);
            favorite.SightsId = CustomTypeConverter.ToString(r["sights_id"]);
            favorite.Visited = CustomTypeConverter.ToInt32Null(r["visited"]);
            favorite.Stars = CustomTypeConverter.ToInt32Null(r["stars"]);
            favorite.CreatingTime = CustomTypeConverter.ToDateTimeNull(r["creating_time"]);
            return favorite;
        }

        private static readonly string SELECT = "select * from stg_favorite order by user_id, creating_time desc";
        private static readonly string SELECT___USER_ID = "select * from stg_favorite where user_id = :UserId  order by creating_time desc";
        private static readonly string SELECT___SIGHTS_ID = "select * from stg_favorite where sights_id = :SightsId  order by user_id, creating_time desc";
        private static readonly string SELECT___USER_ID__SIGHTS_ID = "select * from stg_favorite where user_id = :UserId and sights_id = :SightsId";
        private static readonly string SELECT___AVG_STARS___SIGHTS_ID = "select avg(stars) from stg_favorite where sights_id = :SightsId";

        private static readonly string INSERT = "insert into stg_favorite(user_id, sights_id, visited, stars, creating_time) values(:UserId, :SightsId, :Visited, :Stars, :CreatingTime)";
        private static readonly string UPDATE = "update stg_favorite set visited = :Visited, stars = :Stars, creating_time = :CreatingTime  where user_id = :UserId and sights_id = :SightsId";
        private static readonly string DELETE = "delete from stg_favorite where user_id = :UserId and sights_id = :SightsId";
        //private static readonly string DELETE___USER_ID = "delete from stg_favorite where user_id = :UserId";
        //private static readonly string DELETE___SIGHTS_ID = "delete from stg_favorite where sights_id = :SightsId";


        public List<Favorite> GetFavorites()
        {
            return this.GetList(SELECT, null);
        }

        public List<Favorite> GetFavoritesByUserId(string userId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            return this.GetList(SELECT___USER_ID, pars);
        }

        public List<Favorite> GetFavoritesBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return this.GetList(SELECT___SIGHTS_ID, pars);
        }

        public Favorite GetFavoriteByUserIdAndSightsId(string userId, string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            return this.GetObject(SELECT___USER_ID__SIGHTS_ID, pars);
        }

        public float? GetAverageStarsBySightsId(string sightsId)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("SightsId", sightsId);
            return CustomTypeConverter.ToFloatNull(this.ExecuteScalar(SELECT___AVG_STARS___SIGHTS_ID, pars));
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
            return this.ExecuteNonQuery(trans, INSERT, pars);
        }

        public int UpdateFavorite(Favorite favorite, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", favorite.UserId);
            pars.Add("SightsId", favorite.SightsId);
            pars.Add("Visited", favorite.Visited);
            pars.Add("Stars", favorite.Stars);
            pars.Add("CreatingTime", favorite.CreatingTime);
            return this.ExecuteNonQuery(trans, UPDATE, pars);
        }

        public int DeleteFavorite(Favorite favorite, DbTransaction trans)
        {
            return DeleteFavoriteByUserIdAndSightsId(favorite.UserId, favorite.SightsId, trans);
        }

        private int DeleteFavoriteByUserIdAndSightsId(string userId, string sightsId, DbTransaction trans)
        {
            Dictionary<string, object> pars = new Dictionary<string, object>();
            pars.Add("UserId", userId);
            pars.Add("SightsId", sightsId);
            return this.ExecuteNonQuery(trans, DELETE, pars);
        }

        //public int DeleteFavoriteByUserId(string userId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("UserId", userId);
        //    return this.ExecuteNonQuery(trans, DELETE___USER_ID, pars);
        //}

        //public int DeleteFavoriteBySightsId(string sightsId, DbTransaction trans)
        //{
        //    Dictionary<string, object> pars = new Dictionary<string, object>();
        //    pars.Add("SightsId", sightsId);
        //    return this.ExecuteNonQuery(trans, DELETE___SIGHTS_ID, pars);
        //}
    }
}
