using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IPictureCommentDAL : IBaseDAL
    {
        List<PictureComment> GetPictureCommentsByPictureId(string pictureId);

        int InsertPictureComment(PictureComment comment, DbTransaction trans);
        int UpdatePictureComment(PictureComment comment, DbTransaction trans);
        int DeletePictureComment(PictureComment comment, DbTransaction trans);
        //int DeletePictureCommentByCommentId(string commentId, DbTransaction trans);
    }
}
