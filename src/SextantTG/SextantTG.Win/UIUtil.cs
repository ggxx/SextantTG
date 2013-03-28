using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using SextantTG.ActiveRecord;
using SextantTG.IServices;

namespace SextantTG.Win
{
    /// <summary>
    /// 为UI层访问Service层提供统一的出口
    /// </summary>
    internal class UIUtil
    {
        private static readonly IBlogService blogSrv = ServiceFactory.CreateService<IBlogService>();
        private static readonly IDictService dictSrv = ServiceFactory.CreateService<IDictService>();
        private static readonly ICommentService commentSrv = ServiceFactory.CreateService<ICommentService>();
        private static readonly ISightsService sightsSrv = ServiceFactory.CreateService<ISightsService>();
        private static readonly ITourService tourSrv = ServiceFactory.CreateService<ITourService>();
        private static readonly IUserService userSrv = ServiceFactory.CreateService<IUserService>();
        private static readonly IPictureService pictureSrv = ServiceFactory.CreateService<IPictureService>();

        #region User Services

        internal static User Login(string loginName, string password)
        {
            return userSrv.Login(loginName, password);
        }

        internal static List<Permission> GetPermissionsByUserId(string userId)
        {
            return userSrv.GetPermissionsByUserId(userId);
        }

        internal static User GetUserByLoginName(string loginName)
        {
            return userSrv.GetUserByLoginName(loginName);
        }

        internal static User GetUserByEmail(string email)
        {
            return userSrv.GetUserByEmail(email);
        }

        internal static User GetUserByUserId(string userId)
        {
            return userSrv.GetUserByUserId(userId);
        }

        internal static bool InsertUser(User user, string password, out string message)
        {
            return userSrv.InsertUser(user, password, out message);
        }

        internal static List<User> GetUsers()
        {
            return userSrv.GetUsers();
        }

        internal static bool UpdateUser(User user, out string message)
        {
            return userSrv.UpdateUser(user, out message);
        }

        internal static bool UpdatePermissionsByUserId(string userId, List<Permission> permissions, out string message)
        {
            return userSrv.UpdatePermissionsByUserId(userId, permissions, out message);
        }

        internal static List<Favorite> GetFavoritesByUserId(string userId)
        {
            return userSrv.GetFavoritesByUserId(userId);
        }

        internal static Favorite GetFavoriteByUserIdAndSightsId(string userId, string sightsId)
        {
            return userSrv.GetFavoriteByUserIdAndSightsId(userId, sightsId);
        }

        internal static bool SaveFavorite(Favorite favorite, out string message)
        {
            return userSrv.SaveFavorite(favorite, out message);
        }

        #endregion


        #region Dict Services

        internal static List<Country> GetCountries()
        {
            return dictSrv.GetCountries();
        }

        internal static List<Province> GetProvinces()
        {
            return dictSrv.GetProvinces();
        }

        internal static List<City> GetCities()
        {
            return dictSrv.GetCities();
        }

        internal static List<Province> GetProvincesByCountryId(string countryId)
        {
            return dictSrv.GetProvincesByCountryId(countryId);
        }

        internal static List<City> GetCitiesByProvinceId(string provinceId)
        {
            return dictSrv.GetCitiesByProvinceId(provinceId);
        }

        internal static List<City> GetCitiesByCountryId(string countryId)
        {
            return dictSrv.GetCitiesByCountryId(countryId);
        }

        internal static Country GetCountryByProvinceId(string provinceId)
        {
            return dictSrv.GetCountryByProvinceId(provinceId);
        }

        internal static Province GetProvinceByCityId(string cityId)
        {
            return dictSrv.GetProvinceByCityId(cityId);
        }

        internal static City GetCityByCityId(string cityId)
        {
            return dictSrv.GetCityByCityId(cityId);
        }

        internal static Dictionary<int, string> GetPermissionsDict()
        {
            return dictSrv.GetPermissionsDict();
        }

        internal static Dictionary<int, string> GetTourStatusDict()
        {
            return dictSrv.GetTourStatusDict();
        }

        internal static bool InsertCountry(Country country, out string message)
        {
            return dictSrv.InsertCountry(country, out message);
        }

        internal static bool UpdateCountry(Country country, out string message)
        {
            return dictSrv.UpdateCountry(country, out message);
        }

        internal static bool DeleteCountry(Country country, out string message)
        {
            return dictSrv.DeleteCountry(country, out message);
        }

        internal static bool InsertProvince(Province province, out string message)
        {
            return dictSrv.InsertProvince(province, out message);
        }

        internal static bool UpdateProvince(Province province, out string message)
        {
            return dictSrv.UpdateProvince(province, out message);
        }

        internal static bool DeleteProvince(Province province, out string message)
        {
            return dictSrv.DeleteProvince(province, out message);
        }

        internal static bool InsertCity(City city, out string message)
        {
            return dictSrv.InsertCity(city, out message);
        }

        internal static bool UpdateCity(City city, out string message)
        {
            return dictSrv.UpdateCity(city, out message);
        }

        internal static bool DeleteCity(City city, out string message)
        {
            return dictSrv.DeleteCity(city, out message);
        }

        #endregion


        #region Sights

        internal static List<Sights> GetSights()
        {
            return sightsSrv.GetSights();
        }

        internal static List<Sights> GetSightsByCityId(string cityId)
        {
            return sightsSrv.GetSightsByCityId(cityId);
        }

        internal static List<Sights> GetSightsByCountryId(string countryId)
        {
            return sightsSrv.GetSightsByCountryId(countryId);
        }

        internal static List<Sights> GetSightsByProvinceId(string provinceId)
        {
            return sightsSrv.GetSightsByProvinceId(provinceId);
        }

        internal static List<Sights> GetVisitedSights(string userId)
        {
            return sightsSrv.GetVisitedSights(userId);
        }

        internal static List<Sights> GetVisitedSightsByCountryId(string countryId, string userId)
        {
            return sightsSrv.GetVisitedSightsByCountryId(countryId, userId);
        }

        internal static List<Sights> GetVisitedSightsByProvinceId(string provinceId, string userId)
        {
            return sightsSrv.GetVisitedSightsByProvinceId(provinceId, userId);
        }

        internal static List<Sights> GetVisitedSightsByCityId(string cityId, string userId)
        {
            return sightsSrv.GetVisitedSightsByCityId(cityId, userId);
        }

        internal static Sights GetSightsBySightsId(string sightsId)
        {
            return sightsSrv.GetSightsBySightsId(sightsId);
        }

        internal static bool InsertSights(Sights sights, List<Picture> pictures, out string message)
        {
            return sightsSrv.InsertSights(sights, pictures, out message);
        }

        internal static bool UpdateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures, out string message)
        {
            return sightsSrv.UpdateSights(sights, pictures, removedPictures, out message);
        }

        internal static bool DeleteSights(Sights sights, out string message)
        {
            return sightsSrv.DeleteSights(sights, out message);
        }

        internal static float? GetAverageStarsBySightsId(string sightsId)
        {
            return sightsSrv.GetAverageStarsBySightsId(sightsId);
        }

        internal static List<Picture> GetPicturesBySightsIdAndUploaderId(string sightsId, string uploaderId)
        {
            return sightsSrv.GetPicturesBySightsIdAndUploaderId(sightsId, uploaderId);
        }

        #endregion


        #region Comment

        internal static List<PictureComment> GetPictureCommentsByPictureId(string pictureId)
        {
            return commentSrv.GetPictureCommentsByPictureId(pictureId);
        }

        internal static List<SightsComment> GetSightsCommentsBySightsId(string sightsId)
        {
            return commentSrv.GetSightsCommentsBySightsId(sightsId);
        }

        internal static List<TourComment> GetTourCommentsByTourId(string tourId)
        {
            return commentSrv.GetTourCommentsByTourId(tourId);
        }

        internal static List<UserComment> GetUserCommentsByUserId(string userId)
        {
            return commentSrv.GetUserCommentsByUserId(userId);
        }

        internal static bool InsertPictureComment(PictureComment comment, out string message)
        {
            return commentSrv.InsertPictureComment(comment, out  message);
        }

        internal static bool UpdatePictureComment(PictureComment comment, out string message)
        {
            return commentSrv.UpdatePictureComment(comment, out  message);

        }

        internal static bool DeletePictureComment(PictureComment comment, out string message)
        {
            return commentSrv.DeletePictureComment(comment, out  message);
        }

        internal static bool InsertSightsComment(SightsComment comment, out string message)
        {
            return commentSrv.InsertSightsComment(comment, out  message);
        }

        internal static bool UpdateSightsComment(SightsComment comment, out string message)
        {
            return commentSrv.UpdateSightsComment(comment, out  message);
        }

        internal static bool DeleteSightsComment(SightsComment comment, out string message)
        {
            return commentSrv.DeleteSightsComment(comment, out  message);
        }

        internal static bool InsertTourComment(TourComment comment, out string message)
        {
            return commentSrv.InsertTourComment(comment, out  message);
        }

        internal static bool UpdateTourComment(TourComment comment, out string message)
        {
            return commentSrv.UpdateTourComment(comment, out  message);
        }

        internal static bool DeleteTourComment(TourComment comment, out string message)
        {
            return commentSrv.DeleteTourComment(comment, out  message);
        }

        internal static bool InsertUserComment(UserComment comment, out string message)
        {
            return commentSrv.InsertUserComment(comment, out  message);
        }

        internal static bool UpdateUserComment(UserComment comment, out string message)
        {
            return commentSrv.UpdateUserComment(comment, out  message);
        }

        internal static bool DeleteUserComment(UserComment comment, out string message)
        {
            return commentSrv.DeleteUserComment(comment, out  message);
        }

        #endregion


        #region Blog

        internal static List<Blog> GetBlogsByUserId(string userId)
        {
            return blogSrv.GetBlogsByUserId(userId);
        }

        internal static List<Blog> GetBlogsBySightsId(string sightsId)
        {
            return blogSrv.GetBlogsBySightsId(sightsId);
        }

        internal static List<Blog> GetBlogsByUserIdAndSightsId(string userId, string sightsId)
        {
            return blogSrv.GetBlogsByUserIdAndSightsId(userId, sightsId);
        }

        internal static List<Blog> GetBlogsByTourIdAndSubTourId(string tourId, string subTourId)
        {
            return blogSrv.GetBlogsByTourIdAndSubTourId(tourId, subTourId);
        }

        internal static List<Blog> GetBlogsByTourId(string tourId)
        {
            return blogSrv.GetBlogsByTourId(tourId);
        }

        internal static Blog GetBlogByBlogId(string blogId)
        {
            return blogSrv.GetBlogByBlogId(blogId);
        }

        internal static bool DeleteBlog(Blog blog, bool deletePictures, out string message)
        {
            return blogSrv.DeleteBlog(blog, deletePictures, out  message);
        }

        internal static bool SaveBlog(Blog blog, out string message)
        {
            return blogSrv.SaveBlob(blog, out message);
        }

        #endregion


        #region Tour

        internal static List<Tour> GetToursBySightsId(string sightsId)
        {
            return tourSrv.GetToursBySightsId(sightsId);
        }

        internal static List<Tour> GetToursByDate(DateTime date)
        {
            return tourSrv.GetToursByDate(date);
        }

        internal static List<Tour> GetToursBySightsIdAndDate(string sightsId, DateTime date)
        {
            return tourSrv.GetToursBySightsIdAndDate(sightsId, date);
        }

        internal static List<SubTour> GetSubToursByTourId(string tourId)
        {
            return tourSrv.GetSubToursByTourId(tourId);
        }

        internal static List<SubTour> GetSubToursByUserId(string userId)
        {
            return tourSrv.GetSubToursByUserId(userId);
        }

        internal static List<SubTour> GetSubToursBySightsId(string sightsId)
        {
            return tourSrv.GetSubToursBySightsId(sightsId);
        }

        internal static List<Tour> GetToursByUserId(string userId)
        {
            return tourSrv.GetToursByUserId(userId);
        }

        internal static Tour GetTourByTourId(string tourId)
        {
            return tourSrv.GetTourByTourId(tourId);
        }

        internal static List<Picture> GetPicturesByTourId(string tourId)
        {
            return tourSrv.GetPicturesByTourId(tourId);
        }

        internal static List<Picture> GetPicturesByTourIdAndSubTourId(string tourId, string subTourId)
        {
            return tourSrv.GetPicturesByTourIdAndSubTourId(tourId, subTourId);
        }

        internal static bool SaveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours, out string message)
        {
            return tourSrv.SaveTour(tour, subTours, removedSubTours, out message);
        }

        internal static bool DeleteTour(Tour tour, bool deletePictures, out string message)
        {
            return tourSrv.DeleteTour(tour, deletePictures, out message);
        }

        #endregion


        internal static bool SavePictures(List<Picture> pictures, List<Picture> removedPictures, out string message)
        {
            return pictureSrv.SavePictures(pictures, removedPictures, out message);
        }

        internal static Picture GetPictureByPictureId(string pictureId)
        {
            return pictureSrv.GetPictureByPictureId(pictureId);
        }

    }
}
