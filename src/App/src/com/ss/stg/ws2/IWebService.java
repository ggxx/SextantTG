package com.ss.stg.ws2;

import java.util.List;

import com.ss.stg.dto.*;

public interface IWebService {

	String WS_RETURN = "ReturnValue";

	int ID__ERROR = -1;
	int ID__HELLO_WORLD = 1;
	int ID__LOGIN = 2;
	int ID__REGIST = 3;
	int ID__GET_SIGHTS = 4;
	int ID__GET_SIGHTS_BY_USERID = 5;
	int ID__GET_SIGHT_BY_SIGHTID = 6;
	int ID__GET_PICTURE_BY_PICTUREID = 7;
	int ID__GET_BLOG_BY_BLOGID = 8;
	int ID__GET_TOURS_BY_USERID = 9;
	int ID__GET_TOUR_BY_TOURID = 10;
	int ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID = 11;
	int ID__GET_SIGHT_BY_SIGHTID_AND_USERID = 12;
	int ID__GET_COUNTRIES = 13;
	int ID__GET_PROVINCES = 14;
	int ID__GET_CITIES = 15;
	int ID__SAVE_TOUR = 16;
	int ID__UPLOAD_PICTURE = 17;
	int ID__INSERT_TOUR_COMMENT = 18;
	int ID__INSERT_BLOG = 19;

	String METHOD__HELLO_WORLD = "HelloWorld";
	String METHOD__LOGIN = "Login";
	String METHOD__REGIST = "Regist";
	String METHOD__GET_SIGHTS = "GetSights";
	String METHOD__GET_SIGHTS_BY_USERID = "GetSights2";
	String METHOD__GET_SIGHT_BY_SIGHTID = "GetSightBySightId";
	String METHOD__GET_SIGHT_BY_SIGHTID_AND_USERID = "GetSightBySightId2";
	String METHOD__GET_PICTURE_BY_PICTUREID = "GetPictureByPictureId";
	String METHOD__GET_BLOG_BY_BLOGID = "GetBlogByBlogId";
	String METHOD__GET_TOURS_BY_USERID = "GetToursByUserId";
	String METHOD__GET_TOUR_BY_TOURID = "GetTourByTourId";
	String METHOD__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID = "GetSubtourByTourIdAndSubtourId";
	String METHOD__GET_COUNTRIES = "GetCountries";
	String METHOD__GET_PROVINCES = "GetProvinces";
	String METHOD__GET_CITIES = "GetCities";
	String METHOD__SAVE_TOUR = "SaveTour";
	String METHOD__UPLOAD_PICTURE = "UploadPicture";
	String METHOD__INSERT_TOUR_COMMENT = "InsertTourComment";
	String METHOD__INSERT_BLOG = "InsertBlog";

	String PARAM__LOGIN__LOGIN_NAME = "loginName";
	String PARAM__LOGIN__PASSWORD = "password";
	String PARAM__REGIST__USER = "userString";
	String PARAM__REGIST__PASSWORD = "password";
	String PARAM__GET_SIGHTS_BY_USERID = "userId";
	String PARAM__GET_SIGHT_BY_SIGHTID = "sightId";
	String PARAM__GET_PICTURE_BY_PICTUREID = "pictureId";
	String PARAM__GET_BLOG_BY_BLOGID = "blogId";
	String PARAM__GET_TOURS_BY_USERID = "userId";
	String PARAM__GET_TOUR_BY_TOURID = "tourId";
	String PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID = "tourId";
	String PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID = "subtourId";
	String PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__SIGHTID = "sightId";
	String PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__USERID = "userId";
	String PARAM__SAVE_TOUR__TOUR = "tourString";
	String PARAM__SAVE_TOUR__SUBTOURS = "subtoursString";
	String PARAM__SAVE_TOUR__REMOVED_SUBTOURS = "removedSubtoursString";
	String PARAM__UPLOAD_PICTURE__PICTURESTRING = "pictureString";
	String PARAM__UPLOAD_PICTURE__BASE64CODE = "base64code";
	String PARAM__INSERT_TOUR_COMMENT = "commentString";
	String PARAM__INSERT_BLOG = "blogString";

	String helloWorld();

	UserObject login(String loginName, String password);

	boolean regist(UserObject user, String password);

	List<SightItem> getSights();

	List<SightItem> getSightsByUserId(String userId);

	SightObject getSightBySightId(String sightId);

	PictureObject getPictureByPictureId(String pictureId);

	BlogObject getBlogByBlogId(String blogId);

	List<TourItem> getToursByUserId(String userId);

	TourObject getTourByTourId(String tourId);

	SubtourObject getSubtourByTourIdAndSubtourId(String tourId, String subtourId);

	SightObject getSightBySightIdAndUserId(String sightId, String userId);

	List<CountryItem> getCountries();

	List<ProvinceItem> getProvinces();

	List<CityItem> getCities();

	boolean saveTour(TourObject tour, List<SubtourItem> subtourItems, List<SubtourItem> removedSubtourItems);
	
	boolean uploadPicture(PictureItem picture, String base64code);
	
	boolean insertTourComment(CommentItem comment);
	
	boolean insertBlog(BlogObject blog);
}
