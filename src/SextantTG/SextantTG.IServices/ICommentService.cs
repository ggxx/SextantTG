using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;

namespace SextantTG.IServices
{
    public interface ICommentService : IBaseService
    {
        List<PictureComment> GetPictureCommentsByPictureId(string pictureId);

        List<SightsComment> GetSightsCommentsBySightsId(string sightsId);

        List<TourComment> GetTourCommentsByTourId(string tourId);

        List<UserComment> GetUserCommentsByUserId(string userId);

        bool InsertPictureComment(PictureComment comment, out string message);

        bool UpdatePictureComment(PictureComment comment, out string message);

        bool DeletePictureCommentByCommentId(string commentId, out string message);

        bool InsertSightsComment(SightsComment comment, out string message);

        bool UpdateSightsComment(SightsComment comment, out string message);

        bool DeleteSightsCommentByCommentId(string commentId, out string message);

        bool InsertTourComment(TourComment comment, out string message);

        bool UpdateTourComment(TourComment comment, out string message);

        bool DeleteTourCommentByCommentId(string commentId, out string message);

        bool InsertUserComment(UserComment comment, out string message);

        bool UpdateUserComment(UserComment comment, out string message);

        bool DeleteUserCommentByCommentId(string commentId, out string message);
    }
}
