using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ISightsCommentDAL : IBaseDAL
    {
        List<SightsComment> GetSightsCommentsBySightsId(string sightsId);

        int InsertSightsComment(SightsComment comment, DbTransaction trans);
        int UpdateSightsComment(SightsComment comment, DbTransaction trans);
        int DeleteSightsCommentByCommentId(string commentId, DbTransaction trans);
    }
}
