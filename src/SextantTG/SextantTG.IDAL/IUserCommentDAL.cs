using SextantTG.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace SextantTG.IDAL
{
    public interface IUserCommentDAL : IBaseDAL
    {
        List<UserComment> GetUserCommentsByUserId(string userId);

        int InsertUserComment(UserComment comment, DbTransaction trans);
        int UpdateUserComment(UserComment comment, DbTransaction trans);
        int DeleteUserCommentByCommentId(string commentId, DbTransaction trans);
    }
}
