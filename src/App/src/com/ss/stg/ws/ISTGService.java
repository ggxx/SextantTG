package com.ss.stg.ws;

import java.util.Date;
import java.util.HashMap;
import java.util.List;

import com.ss.stg.model.*;

public interface ISTGService {

	// Web Service Method ID
	int ID__ERROR = -1;
	int ID__HELLOWORLD = 100000;
	int ID__GETUSERS = 100001;
	int ID__LOGIN = 100002;
	int ID__GETUSERBYLOGINNAME = 100003;
	int ID__GETUSERBYEMAIL = 100004;
	int ID__GETUSERBYUSERID = 100005;
	int ID__GETPERMISSIONSBYUSERID = 100006;
	int ID__INSERTUSER = 100007;
	int ID__UPDATEUSER = 100008;
	int ID__GETFAVORITESBYUSERID = 100009;
	int ID__GETFAVORITEBYUSERIDANDSIGHTSID = 100010;
	int ID__UPDATEPERMISSIONSBYUSERID = 100011;
	int ID__SAVEFAVORITE = 100012;
	int ID__GETBLOGSBYUSERID = 100013;
	int ID__GETBLOGSBYSIGHTSID = 100014;
	int ID__GETBLOGSBYUSERIDANDSIGHTSID = 100015;
	int ID__GETBLOGSBYTOURIDANDSUBTOURID = 100016;
	int ID__GETBLOGBYBLOGID = 100017;
	int ID__GETBLOGSBYTOURID = 100018;
	int ID__DELETEBLOG = 100019;
	int ID__SAVEBLOG = 100020;
	int ID__GETPICTURECOMMENTSBYPICTUREID = 100021;
	int ID__GETSIGHTSCOMMENTSBYSIGHTSID = 100022;
	int ID__GETTOURCOMMENTSBYTOURID = 100023;
	int ID__GETUSERCOMMENTSBYUSERID = 100024;
	int ID__INSERTPICTURECOMMENT = 100025;
	int ID__UPDATEPICTURECOMMENT = 100026;
	int ID__DELETEPICTURECOMMENT = 100027;
	int ID__INSERTSIGHTSCOMMENT = 100028;
	int ID__UPDATESIGHTSCOMMENT = 100029;
	int ID__DELETESIGHTSCOMMENT = 100030;
	int ID__INSERTTOURCOMMENT = 100031;
	int ID__UPDATETOURCOMMENT = 100032;
	int ID__DELETETOURCOMMENT = 100033;
	int ID__INSERTUSERCOMMENT = 100034;
	int ID__UPDATEUSERCOMMENT = 100035;
	int ID__DELETEUSERCOMMENT = 100036;
	int ID__GETCOUNTRIES = 100037;
	int ID__GETPROVINCES = 100038;
	int ID__GETCITIES = 100039;
	int ID__GETPROVINCESBYCOUNTRYID = 100040;
	int ID__GETCITIESBYPROVINCEID = 100041;
	int ID__GETCITIESBYCOUNTRYID = 100042;
	int ID__GETCOUNTRYBYPROVINCEID = 100043;
	int ID__GETPROVINCEBYCITYID = 100044;
	int ID__GETCOUNTRYBYCOUNTRYID = 100045;
	int ID__GETPROVINCEBYPROVINCEID = 100046;
	int ID__GETCITYBYCITYID = 100047;
	int ID__GETPERMISSIONSDICT = 100048;
	int ID__GETTOURSTATUSDICT = 100049;
	int ID__INSERTCOUNTRY = 100050;
	int ID__UPDATECOUNTRY = 100051;
	int ID__DELETECOUNTRY = 100052;
	int ID__INSERTPROVINCE = 100053;
	int ID__UPDATEPROVINCE = 100054;
	int ID__DELETEPROVINCE = 100055;
	int ID__INSERTCITY = 100056;
	int ID__UPDATECITY = 100057;
	int ID__DELETECITY = 100058;
	int ID__GETPICTUREBYPICTUREID = 100059;
	int ID__SAVEPICTURES = 100060;
	int ID__GETSIGHTS = 100061;
	int ID__GETSIGHTSBYCOUNTRYID = 100062;
	int ID__GETSIGHTSBYPROVINCEID = 100063;
	int ID__GETSIGHTSBYCITYID = 100064;
	int ID__GETSIGHTSBYSIGHTSID = 100065;
	int ID__GETAVERAGESTARSBYSIGHTSID = 100066;
	int ID__GETPICTURESBYSIGHTSIDANDUPLOADERID = 100067;
	int ID__GETVISITEDSIGHTS = 100068;
	int ID__GETVISITEDSIGHTSBYCOUNTRYID = 100069;
	int ID__GETVISITEDSIGHTSBYPROVINCEID = 100070;
	int ID__GETVISITEDSIGHTSBYCITYID = 100071;
	int ID__INSERTSIGHTS = 100072;
	int ID__UPDATESIGHTS = 100073;
	int ID__DELETESIGHTS = 100074;
	int ID__GETTOURSBYUSERID = 100075;
	int ID__GETTOURBYTOURID = 100076;
	int ID__GETTOURSBYSIGHTSID = 100077;
	int ID__GETTOURSBYDATE = 100078;
	int ID__GETTOURSBYSIGHTSIDANDDATE = 100079;
	int ID__DELETETOUR = 100080;
	int ID__SAVETOUR = 100081;
	int ID__GETSUBTOURSBYTOURID = 100082;
	int ID__GETSUBTOURBYTOURIDANDSUBTOURID = 100083;
	int ID__GETSUBTOURSBYUSERID = 100084;
	int ID__GETSUBTOURSBYSIGHTSID = 100085;
	int ID__GETPICTURESBYTOURID = 100086;
	int ID__GETPICTURESBYTOURIDANDSUBTOURID = 100087;

	// Web Service Method Name
	String METHOD__HELLOWORLD = "HelloWorld";
	String METHOD__GETUSERS = "GetUsers";
	String METHOD__LOGIN = "Login";
	String METHOD__GETUSERBYLOGINNAME = "GetUserByLoginName";
	String METHOD__GETUSERBYEMAIL = "GetUserByEmail";
	String METHOD__GETUSERBYUSERID = "GetUserByUserId";
	String METHOD__GETPERMISSIONSBYUSERID = "GetPermissionsByUserId";
	String METHOD__INSERTUSER = "InsertUser";
	String METHOD__UPDATEUSER = "UpdateUser";
	String METHOD__GETFAVORITESBYUSERID = "GetFavoritesByUserId";
	String METHOD__GETFAVORITEBYUSERIDANDSIGHTSID = "GetFavoriteByUserIdAndSightsId";
	String METHOD__UPDATEPERMISSIONSBYUSERID = "UpdatePermissionsByUserId";
	String METHOD__SAVEFAVORITE = "SaveFavorite";
	String METHOD__GETBLOGSBYUSERID = "GetBlogsByUserId";
	String METHOD__GETBLOGSBYSIGHTSID = "GetBlogsBySightsId";
	String METHOD__GETBLOGSBYUSERIDANDSIGHTSID = "GetBlogsByUserIdAndSightsId";
	String METHOD__GETBLOGSBYTOURIDANDSUBTOURID = "GetBlogsByTourIdAndSubTourId";
	String METHOD__GETBLOGBYBLOGID = "GetBlogByBlogId";
	String METHOD__GETBLOGSBYTOURID = "GetBlogsByTourId";
	String METHOD__DELETEBLOG = "DeleteBlog";
	String METHOD__SAVEBLOG = "SaveBlog";
	String METHOD__GETPICTURECOMMENTSBYPICTUREID = "GetPictureCommentsByPictureId";
	String METHOD__GETSIGHTSCOMMENTSBYSIGHTSID = "GetSightsCommentsBySightsId";
	String METHOD__GETTOURCOMMENTSBYTOURID = "GetTourCommentsByTourId";
	String METHOD__GETUSERCOMMENTSBYUSERID = "GetUserCommentsByUserId";
	String METHOD__INSERTPICTURECOMMENT = "InsertPictureComment";
	String METHOD__UPDATEPICTURECOMMENT = "UpdatePictureComment";
	String METHOD__DELETEPICTURECOMMENT = "DeletePictureComment";
	String METHOD__INSERTSIGHTSCOMMENT = "InsertSightsComment";
	String METHOD__UPDATESIGHTSCOMMENT = "UpdateSightsComment";
	String METHOD__DELETESIGHTSCOMMENT = "DeleteSightsComment";
	String METHOD__INSERTTOURCOMMENT = "InsertTourComment";
	String METHOD__UPDATETOURCOMMENT = "UpdateTourComment";
	String METHOD__DELETETOURCOMMENT = "DeleteTourComment";
	String METHOD__INSERTUSERCOMMENT = "InsertUserComment";
	String METHOD__UPDATEUSERCOMMENT = "UpdateUserComment";
	String METHOD__DELETEUSERCOMMENT = "DeleteUserComment";
	String METHOD__GETCOUNTRIES = "GetCountries";
	String METHOD__GETPROVINCES = "GetProvinces";
	String METHOD__GETCITIES = "GetCities";
	String METHOD__GETPROVINCESBYCOUNTRYID = "GetProvincesByCountryId";
	String METHOD__GETCITIESBYPROVINCEID = "GetCitiesByProvinceId";
	String METHOD__GETCITIESBYCOUNTRYID = "GetCitiesByCountryId";
	String METHOD__GETCOUNTRYBYPROVINCEID = "GetCountryByProvinceId";
	String METHOD__GETPROVINCEBYCITYID = "GetProvinceByCityId";
	String METHOD__GETCOUNTRYBYCOUNTRYID = "GetCountryByCountryId";
	String METHOD__GETPROVINCEBYPROVINCEID = "GetProvinceByProvinceId";
	String METHOD__GETCITYBYCITYID = "GetCityByCityId";
	String METHOD__GETPERMISSIONSDICT = "GetPermissionsDict";
	String METHOD__GETTOURSTATUSDICT = "GetTourStatusDict";
	String METHOD__INSERTCOUNTRY = "InsertCountry";
	String METHOD__UPDATECOUNTRY = "UpdateCountry";
	String METHOD__DELETECOUNTRY = "DeleteCountry";
	String METHOD__INSERTPROVINCE = "InsertProvince";
	String METHOD__UPDATEPROVINCE = "UpdateProvince";
	String METHOD__DELETEPROVINCE = "DeleteProvince";
	String METHOD__INSERTCITY = "InsertCity";
	String METHOD__UPDATECITY = "UpdateCity";
	String METHOD__DELETECITY = "DeleteCity";
	String METHOD__GETPICTUREBYPICTUREID = "GetPictureByPictureId";
	String METHOD__SAVEPICTURES = "SavePictures";
	String METHOD__GETSIGHTS = "GetSights";
	String METHOD__GETSIGHTSBYCOUNTRYID = "GetSightsByCountryId";
	String METHOD__GETSIGHTSBYPROVINCEID = "GetSightsByProvinceId";
	String METHOD__GETSIGHTSBYCITYID = "GetSightsByCityId";
	String METHOD__GETSIGHTSBYSIGHTSID = "GetSightsBySightsId";
	String METHOD__GETAVERAGESTARSBYSIGHTSID = "GetAverageStarsBySightsId";
	String METHOD__GETPICTURESBYSIGHTSIDANDUPLOADERID = "GetPicturesBySightsIdAndUploaderId";
	String METHOD__GETVISITEDSIGHTS = "GetVisitedSights";
	String METHOD__GETVISITEDSIGHTSBYCOUNTRYID = "GetVisitedSightsByCountryId";
	String METHOD__GETVISITEDSIGHTSBYPROVINCEID = "GetVisitedSightsByProvinceId";
	String METHOD__GETVISITEDSIGHTSBYCITYID = "GetVisitedSightsByCityId";
	String METHOD__INSERTSIGHTS = "InsertSights";
	String METHOD__UPDATESIGHTS = "UpdateSights";
	String METHOD__DELETESIGHTS = "DeleteSights";
	String METHOD__GETTOURSBYUSERID = "GetToursByUserId";
	String METHOD__GETTOURBYTOURID = "GetTourByTourId";
	String METHOD__GETTOURSBYSIGHTSID = "GetToursBySightsId";
	String METHOD__GETTOURSBYDATE = "GetToursByDate";
	String METHOD__GETTOURSBYSIGHTSIDANDDATE = "GetToursBySightsIdAndDate";
	String METHOD__DELETETOUR = "DeleteTour";
	String METHOD__SAVETOUR = "SaveTour";
	String METHOD__GETSUBTOURSBYTOURID = "GetSubToursByTourId";
	String METHOD__GETSUBTOURBYTOURIDANDSUBTOURID = "GetSubTourByTourIdAndSubTourId";
	String METHOD__GETSUBTOURSBYUSERID = "GetSubToursByUserId";
	String METHOD__GETSUBTOURSBYSIGHTSID = "GetSubToursBySightsId";
	String METHOD__GETPICTURESBYTOURID = "GetPicturesByTourId";
	String METHOD__GETPICTURESBYTOURIDANDSUBTOURID = "GetPicturesByTourIdAndSubTourId";

	// Web Service Method Parameters Key
	String PARAM__LOGIN__LOGINNAME = "loginName";
	String PARAM__LOGIN__PASSWORD = "password";
	String PARAM__GETUSERBYLOGINNAME = "loginName";
	String PARAM__GETUSERBYEMAIL = "email";
	String PARAM__GETUSERBYUSERID = "userId";
	String PARAM__GETPERMISSIONSBYUSERID = "userId";
	String PARAM__INSERTUSER__INPUTUSER = "inputUser";
	String PARAM__INSERTUSER__PASSWORD = "password";
	String PARAM__UPDATEUSER = "inputUser";
	String PARAM__GETFAVORITESBYUSERID = "userId";
	String PARAM__GETFAVORITEBYUSERIDANDSIGHTSID__USERID = "userId";
	String PARAM__GETFAVORITEBYUSERIDANDSIGHTSID__SIGHTSID = "sightsId";
	String PARAM__UPDATEPERMISSIONSBYUSERID__USERID = "userId";
	String PARAM__UPDATEPERMISSIONSBYUSERID__INPUTPERMISSIONS = "inputPermissions";
	String PARAM__SAVEFAVORITE = "inputFavorite";
	String PARAM__GETBLOGSBYUSERID = "userId";
	String PARAM__GETBLOGSBYSIGHTSID = "sightsId";
	String PARAM__GETBLOGSBYUSERIDANDSIGHTSID__USRID = "userId";
	String PARAM__GETBLOGSBYUSERIDANDSIGHTSID__SIGHTSID = "sightsId";
	String PARAM__GETBLOGSBYTOURIDANDSUBTOURID__TOURID = "tourId";
	String PARAM__GETBLOGSBYTOURIDANDSUBTOURID__SUBTOURID = "subTourId";
	String PARAM__GETBLOGBYBLOGID = "blogId";
	String PARAM__GETBLOGSBYTOURID = "tourId";
	String PARAM__DELETEBLOG__INPUTBLOG = "inputBlog";
	String PARAM__DELETEBLOG__DELETEPICTURES = "deletePictures";
	String PARAM__SAVEBLOG = "inputBlog";
	String PARAM__GETPICTURECOMMENTSBYPICTUREID = "pictureId";
	String PARAM__GETSIGHTSCOMMENTSBYSIGHTSID = "sightsId";
	String PARAM__GETTOURCOMMENTSBYTOURID = "tourId";
	String PARAM__GETUSERCOMMENTSBYUSERID = "userId";
	String PARAM__INSERTPICTURECOMMENT = "inputComment";
	String PARAM__UPDATEPICTURECOMMENT = "inputComment";
	String PARAM__DELETEPICTURECOMMENT = "inputComment";
	String PARAM__INSERTSIGHTSCOMMENT = "inputComment";
	String PARAM__UPDATESIGHTSCOMMENT = "inputComment";
	String PARAM__DELETESIGHTSCOMMENT = "inputComment";
	String PARAM__INSERTTOURCOMMENT = "inputComment";
	String PARAM__UPDATETOURCOMMENT = "inputComment";
	String PARAM__DELETETOURCOMMENT = "inputComment";
	String PARAM__INSERTUSERCOMMENT = "inputComment";
	String PARAM__UPDATEUSERCOMMENT = "inputComment";
	String PARAM__DELETEUSERCOMMENT = "inputComment";
	String PARAM__GETPROVINCESBYCOUNTRYID = "countryId";
	String PARAM__GETCITIESBYPROVINCEID = "provinceId";
	String PARAM__GETCITIESBYCOUNTRYID = "countryId";
	String PARAM__GETCOUNTRYBYPROVINCEID = "provinceId";
	String PARAM__GETPROVINCEBYCITYID = "cityId";
	String PARAM__GETCOUNTRYBYCOUNTRYID = "countryId";
	String PARAM__GETPROVINCEBYPROVINCEID = "provinceId";
	String PARAM__GETCITYBYCITYID = "cityId";
	String PARAM__INSERTCOUNTRY = "inputCountry";
	String PARAM__UPDATECOUNTRY = "inputCountry";
	String PARAM__DELETECOUNTRY = "inputCountry";
	String PARAM__INSERTPROVINCE = "inputProvince";
	String PARAM__UPDATEPROVINCE = "inputProvince";
	String PARAM__DELETEPROVINCE = "inputProvince";
	String PARAM__INSERTCITY = "inputCity";
	String PARAM__UPDATECITY = "inputCity";
	String PARAM__DELETECITY = "inputCity";
	String PARAM__GETPICTUREBYPICTUREID = "pictureId";
	String PARAM__SAVEPICTURES__INPUTPICTURES = "inputPictures";
	String PARAM__SAVEPICTURES__INPUTREMOVEDPICTURES = "inputRemovedPictures";
	String PARAM__GETSIGHTSBYCOUNTRYID = "countryId";
	String PARAM__GETSIGHTSBYPROVINCEID = "provinceId";
	String PARAM__GETSIGHTSBYCITYID = "cityId";
	String PARAM__GETSIGHTSBYSIGHTSID = "sightsId";
	String PARAM__GETAVERAGESTARSBYSIGHTSID = "sightsId";
	String PARAM__GETPICTURESBYSIGHTSIDANDUPLOADERID__SIGHTSID = "sightsId";
	String PARAM__GETPICTURESBYSIGHTSIDANDUPLOADERID__UPLOADERID = "uploaderId";
	String PARAM__GETVISITEDSIGHTS = "userId";
	String PARAM__GETVISITEDSIGHTSBYCOUNTRYID__COUNTRYID = "countryId";
	String PARAM__GETVISITEDSIGHTSBYCOUNTRYID__USERID = "userId";
	String PARAM__GETVISITEDSIGHTSBYPROVINCEID__PROVINCEID = "provinceId";
	String PARAM__GETVISITEDSIGHTSBYPROVINCEID__USERID = "userId";
	String PARAM__GETVISITEDSIGHTSBYCITYID__CITYID = "cityId";
	String PARAM__GETVISITEDSIGHTSBYCITYID__USERID = "userId";
	String PARAM__INSERTSIGHTS__INPUTSIGHTS = "inputSights";
	String PARAM__INSERTSIGHTS__INPUTPICTURES = "inputPictures";
	String PARAM__UPDATESIGHTS__INPUTSIGHTS = "inputSights";
	String PARAM__UPDATESIGHTS__INPUTPICTURES = "inputPictures";
	String PARAM__UPDATESIGHTS__INPUTREMOVEDPICTURES = "inputRemovedPictures";
	String PARAM__DELETESIGHTS = "inputSights";
	String PARAM__GETTOURSBYUSERID = "userId";
	String PARAM__GETTOURBYTOURID = "tourId";
	String PARAM__GETTOURSBYSIGHTSID = "sightsId";
	String PARAM__GETTOURSBYDATE = "date";
	String PARAM__GETTOURSBYSIGHTSIDANDDATE_SIGHTSID = "sightsId";
	String PARAM__GETTOURSBYSIGHTSIDANDDATE_DATE = "date";
	String PARAM__DELETETOUR__INPUTTOUR = "inputTour";
	String PARAM__DELETETOUR__DELETEPICTURES = "deletePictures";
	String PARAM__SAVETOUR__INPUTTOUR = "inputTour";
	String PARAM__SAVETOUR__INPUTSUBTOURS = "inputSubTours";
	String PARAM__SAVETOUR__INPUTREMOVEDSUBTOURS = "inputRemovedSubTours";
	String PARAM__GETSUBTOURSBYTOURID = "tourId";
	String PARAM__GETSUBTOURBYTOURIDANDSUBTOURID__TOURID = "tourId";
	String PARAM__GETSUBTOURBYTOURIDANDSUBTOURID__SUBTOURID = "subTourId";
	String PARAM__GETSUBTOURSBYUSERID = "userId";
	String PARAM__GETSUBTOURSBYSIGHTSID = "sightsId";
	String PARAM__GETPICTURESBYTOURID = "tourId";
	String PARAM__GETPICTURESBYTOURIDANDSUBTOURID__TOURID = "tourId";
	String PARAM__GETPICTURESBYTOURIDANDSUBTOURID__SUBTOURID = "subTourId";

	// Web Service Return Key
	String WS_RETURN = "WS_RETURN";

	// Interface
	// SoapObject GetSoapResponse(int methodId, HashMap<String, Object> params);

	String helloWorld();

	List<User> getUsers();

	User login(String loginName, String password);

	User getUserByLoginName(String loginName);

	User getUserByEmail(String email);

	User getUserByUserId(String userId);

	List<Permission> getPermissionsByUserId(String userId);

	boolean insertUser(User user, String password);

	boolean updateUser(User user);

	List<Favorite> getFavoritesByUserId(String userId);

	Favorite getFavoriteByUserIdAndSightsId(String userId, String sightsId);

	boolean updatePermissionsByUserId(String userId, List<Permission> permissions);

	boolean saveFavorite(Favorite favorite);

	List<Blog> getBlogsByUserId(String userId);

	List<Blog> getBlogsBySightsId(String sightsId);

	List<Blog> getBlogsByUserIdAndSightsId(String userId, String sightsId);

	List<Blog> getBlogsByTourIdAndSubTourId(String tourId, String subTourId);

	Blog getBlogByBlogId(String blogId);

	List<Blog> getBlogsByTourId(String tourId);

	boolean deleteBlog(Blog blog, boolean deletePictures);

	boolean saveBlog(Blog blog);

	List<PictureComment> getPictureCommentsByPictureId(String pictureId);

	List<SightsComment> getSightsCommentsBySightsId(String sightsId);

	List<TourComment> getTourCommentsByTourId(String tourId);

	List<UserComment> getUserCommentsByUserId(String userId);

	boolean insertPictureComment(PictureComment comment);

	boolean updatePictureComment(PictureComment comment);

	boolean deletePictureComment(PictureComment comment);

	boolean insertSightsComment(SightsComment comment);

	boolean updateSightsComment(SightsComment comment);

	boolean deleteSightsComment(SightsComment comment);

	boolean insertTourComment(TourComment comment);

	boolean updateTourComment(TourComment comment);

	boolean deleteTourComment(TourComment comment);

	boolean insertUserComment(UserComment comment);

	boolean updateUserComment(UserComment comment);

	boolean deleteUserComment(UserComment comment);

	List<Country> getCountries();

	List<Province> getProvinces();

	List<City> getCities();

	List<Province> getProvincesByCountryId(String countryId);

	List<City> getCitiesByProvinceId(String provinceId);

	List<City> getCitiesByCountryId(String countryId);

	Country getCountryByProvinceId(String provinceId);

	Province getProvinceByCityId(String cityId);

	Country getCountryByCountryId(String countryId);

	Province getProvinceByProvinceId(String provinceId);

	City getCityByCityId(String cityId);

	HashMap<Integer, String> getPermissionsDict();

	HashMap<Integer, String> getTourStatusDict();

	boolean insertCountry(Country country);

	boolean updateCountry(Country country);

	boolean deleteCountry(Country country);

	boolean insertProvince(Province province);

	boolean updateProvince(Province province);

	boolean deleteProvince(Province province);

	boolean insertCity(City city);

	boolean updateCity(City city);

	boolean deleteCity(City city);

	Picture getPictureByPictureId(String pictureId);

	boolean savePictures(List<Picture> pictures, List<Picture> removedPictures);

	List<Sights> getSights();

	List<Sights> getSightsByCountryId(String countryId);

	List<Sights> getSightsByProvinceId(String provinceId);

	List<Sights> getSightsByCityId(String cityId);

	Sights getSightsBySightsId(String sightsId);

	float getAverageStarsBySightsId(String sightsId);

	List<Picture> getPicturesBySightsIdAndUploaderId(String sightsId, String uploaderId);

	List<Sights> getVisitedSights(String userId);

	List<Sights> getVisitedSightsByCountryId(String countryId, String userId);

	List<Sights> getVisitedSightsByProvinceId(String provinceId, String userId);

	List<Sights> getVisitedSightsByCityId(String cityId, String userId);

	boolean insertSights(Sights sights, List<Picture> pictures);

	boolean updateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures);

	boolean deleteSights(Sights sights);

	List<Tour> getToursByUserId(String userId);

	Tour getTourByTourId(String tourId);

	List<Tour> getToursBySightsId(String sightsId);

	List<Tour> getToursByDate(Date date);

	List<Tour> getToursBySightsIdAndDate(String sightsId, Date date);

	boolean deleteTour(Tour tour, boolean deletePictures);

	boolean saveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours);

	List<SubTour> getSubToursByTourId(String tourId);

	SubTour getSubTourByTourIdAndSubTourId(String tourId, String subTourId);

	List<SubTour> getSubToursByUserId(String userId);

	List<SubTour> getSubToursBySightsId(String sightsId);

	List<Picture> getPicturesByTourId(String tourId);

	List<Picture> getPicturesByTourIdAndSubTourId(String tourId, String subTourId);
}
