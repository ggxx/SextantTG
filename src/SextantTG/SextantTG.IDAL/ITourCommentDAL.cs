using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface ITourCommentDAL : IBaseDAL
    {
        List<TourComment> GetTourCommentsByTourId(string tourId);

        int InsertTourComment(TourComment comment, DbTransaction trans);
        int UpdateTourComment(TourComment comment, DbTransaction trans);
        int DeleteTourCommentByCommentId(string commentId, DbTransaction trans);
    }
}
