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

        bool DeletePictureComment(PictureComment comment, out string message);

        bool InsertSightsComment(SightsComment comment, out string message);

        bool UpdateSightsComment(SightsComment comment, out string message);

        bool DeleteSightsComment(SightsComment comment, out string message);

        bool InsertTourComment(TourComment comment, out string message);

        bool UpdateTourComment(TourComment comment, out string message);

        bool DeleteTourComment(TourComment comment, out string message);

        bool InsertUserComment(UserComment comment, out string message);

        bool UpdateUserComment(UserComment comment, out string message);

        bool DeleteUserComment(UserComment comment, out string message);
    }
}
