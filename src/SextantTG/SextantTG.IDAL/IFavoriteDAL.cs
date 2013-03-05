using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IFavoriteDAL : IBaseDAL
    {
        List<Favorite> GetFavoritesByUserId(string userId);
        List<Favorite> GetFavoritesBySightsId(string sightsId);

        int InsertFavorite(Favorite favorite, DbTransaction trans);
        int UpdateFavorite(Favorite favorite, DbTransaction trans);
        int DeleteFavoriteByUserIdAndSightsId(string userId, string sightsId, DbTransaction trans);
        int DeleteFavoriteByUserId(string userId, DbTransaction trans);
        int DeleteFavoriteBySightsId(string sightsId, DbTransaction trans);
    }
}
