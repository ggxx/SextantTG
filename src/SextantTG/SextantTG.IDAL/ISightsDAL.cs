using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISightsDAL : IBaseDAL
    {
        List<Sights> GetSights();
        Sights GetSightBySightsId(string sightsId);

        int InsertSights(Sights sights, DbTransaction trans);
        int UpdateSights(Sights sights, DbTransaction trans);
        int DeleteSightsBySightsId(string sightsId, DbTransaction trans);
    }
}
