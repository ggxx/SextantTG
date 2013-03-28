using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using System.Data.Common;

namespace SextantTG.IServices
{
    public interface ISightsService : IBaseService
    {
        List<Sights> GetSights();
        List<Sights> GetSightsByCountryId(string countryId);
        List<Sights> GetSightsByProvinceId(string provinceId);
        List<Sights> GetSightsByCityId(string cityId);
        Sights GetSightsBySightsId(string sightsId);
        float? GetAverageStarsBySightsId(string sightsId);
        List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId);
        List<Sights> GetVisitedSights(string userId);
        List<Sights> GetVisitedSightsByCountryId(string countryId, string userId);
        List<Sights> GetVisitedSightsByProvinceId(string provinceId, string userId);
        List<Sights> GetVisitedSightsByCityId(string cityId, string userId);

        bool InsertSights(Sights sights, List<Picture> pictures, out string message);
        bool UpdateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures, out string message);
        bool DeleteSights(Sights sights, out string message);
    }
}
