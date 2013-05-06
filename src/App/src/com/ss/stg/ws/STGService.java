package com.ss.stg.ws;

import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map.Entry;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.ss.stg.model.*;

public class STGService implements ISTGService {

	private static final String WS_NAMESPACE = "http://github.com/ggxx/SextantTG/";
	private static final String WS_URL = "http://10.0.2.2:1153/WS.asmx";

	private String getMethodName(int methodId) {
		if (methodId == ISTGService.ID__HELLOWORLD) {
			return ISTGService.METHOD__HELLOWORLD;
		} else if (methodId == ISTGService.ID__GETUSERS) {
			return ISTGService.METHOD__GETUSERS;
		} else if (methodId == ISTGService.ID__LOGIN) {
			return ISTGService.METHOD__LOGIN;
		} else if (methodId == ISTGService.ID__GETUSERBYLOGINNAME) {
			return ISTGService.METHOD__GETUSERBYLOGINNAME;
		} else if (methodId == ISTGService.ID__GETUSERBYEMAIL) {
			return ISTGService.METHOD__GETUSERBYEMAIL;
		} else if (methodId == ISTGService.ID__GETUSERBYUSERID) {
			return ISTGService.METHOD__GETUSERBYUSERID;
		} else if (methodId == ISTGService.ID__GETPERMISSIONSBYUSERID) {
			return ISTGService.METHOD__GETPERMISSIONSBYUSERID;
		} else if (methodId == ISTGService.ID__INSERTUSER) {
			return ISTGService.METHOD__INSERTUSER;
		} else if (methodId == ISTGService.ID__UPDATEUSER) {
			return ISTGService.METHOD__UPDATEUSER;
		} else if (methodId == ISTGService.ID__GETFAVORITESBYUSERID) {
			return ISTGService.METHOD__GETFAVORITESBYUSERID;
		} else if (methodId == ISTGService.ID__GETFAVORITEBYUSERIDANDSIGHTSID) {
			return ISTGService.METHOD__GETFAVORITEBYUSERIDANDSIGHTSID;
		} else if (methodId == ISTGService.ID__UPDATEPERMISSIONSBYUSERID) {
			return ISTGService.METHOD__UPDATEPERMISSIONSBYUSERID;
		} else if (methodId == ISTGService.ID__SAVEFAVORITE) {
			return ISTGService.METHOD__SAVEFAVORITE;
		} else if (methodId == ISTGService.ID__GETBLOGSBYUSERID) {
			return ISTGService.METHOD__GETBLOGSBYUSERID;
		} else if (methodId == ISTGService.ID__GETBLOGSBYSIGHTSID) {
			return ISTGService.METHOD__GETBLOGSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETBLOGSBYUSERIDANDSIGHTSID) {
			return ISTGService.METHOD__GETBLOGSBYUSERIDANDSIGHTSID;
		} else if (methodId == ISTGService.ID__GETBLOGSBYTOURIDANDSUBTOURID) {
			return ISTGService.METHOD__GETBLOGSBYTOURIDANDSUBTOURID;
		} else if (methodId == ISTGService.ID__GETBLOGBYBLOGID) {
			return ISTGService.METHOD__GETBLOGBYBLOGID;
		} else if (methodId == ISTGService.ID__GETBLOGSBYTOURID) {
			return ISTGService.METHOD__GETBLOGSBYTOURID;
		} else if (methodId == ISTGService.ID__DELETEBLOG) {
			return ISTGService.METHOD__DELETEBLOG;
		} else if (methodId == ISTGService.ID__SAVEBLOG) {
			return ISTGService.METHOD__SAVEBLOG;
		} else if (methodId == ISTGService.ID__GETPICTURECOMMENTSBYPICTUREID) {
			return ISTGService.METHOD__GETPICTURECOMMENTSBYPICTUREID;
		} else if (methodId == ISTGService.ID__GETSIGHTSCOMMENTSBYSIGHTSID) {
			return ISTGService.METHOD__GETSIGHTSCOMMENTSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETTOURCOMMENTSBYTOURID) {
			return ISTGService.METHOD__GETTOURCOMMENTSBYTOURID;
		} else if (methodId == ISTGService.ID__GETUSERCOMMENTSBYUSERID) {
			return ISTGService.METHOD__GETUSERCOMMENTSBYUSERID;
		} else if (methodId == ISTGService.ID__INSERTPICTURECOMMENT) {
			return ISTGService.METHOD__INSERTPICTURECOMMENT;
		} else if (methodId == ISTGService.ID__UPDATEPICTURECOMMENT) {
			return ISTGService.METHOD__UPDATEPICTURECOMMENT;
		} else if (methodId == ISTGService.ID__DELETEPICTURECOMMENT) {
			return ISTGService.METHOD__DELETEPICTURECOMMENT;
		} else if (methodId == ISTGService.ID__INSERTSIGHTSCOMMENT) {
			return ISTGService.METHOD__INSERTSIGHTSCOMMENT;
		} else if (methodId == ISTGService.ID__UPDATESIGHTSCOMMENT) {
			return ISTGService.METHOD__UPDATESIGHTSCOMMENT;
		} else if (methodId == ISTGService.ID__DELETESIGHTSCOMMENT) {
			return ISTGService.METHOD__DELETESIGHTSCOMMENT;
		} else if (methodId == ISTGService.ID__INSERTTOURCOMMENT) {
			return ISTGService.METHOD__INSERTTOURCOMMENT;
		} else if (methodId == ISTGService.ID__UPDATETOURCOMMENT) {
			return ISTGService.METHOD__UPDATETOURCOMMENT;
		} else if (methodId == ISTGService.ID__DELETETOURCOMMENT) {
			return ISTGService.METHOD__DELETETOURCOMMENT;
		} else if (methodId == ISTGService.ID__INSERTUSERCOMMENT) {
			return ISTGService.METHOD__INSERTUSERCOMMENT;
		} else if (methodId == ISTGService.ID__UPDATEUSERCOMMENT) {
			return ISTGService.METHOD__UPDATEUSERCOMMENT;
		} else if (methodId == ISTGService.ID__DELETEUSERCOMMENT) {
			return ISTGService.METHOD__DELETEUSERCOMMENT;
		} else if (methodId == ISTGService.ID__GETCOUNTRIES) {
			return ISTGService.METHOD__GETCOUNTRIES;
		} else if (methodId == ISTGService.ID__GETPROVINCES) {
			return ISTGService.METHOD__GETPROVINCES;
		} else if (methodId == ISTGService.ID__GETCITIES) {
			return ISTGService.METHOD__GETCITIES;
		} else if (methodId == ISTGService.ID__GETPROVINCESBYCOUNTRYID) {
			return ISTGService.METHOD__GETPROVINCESBYCOUNTRYID;
		} else if (methodId == ISTGService.ID__GETCITIESBYPROVINCEID) {
			return ISTGService.METHOD__GETCITIESBYPROVINCEID;
		} else if (methodId == ISTGService.ID__GETCITIESBYCOUNTRYID) {
			return ISTGService.METHOD__GETCITIESBYCOUNTRYID;
		} else if (methodId == ISTGService.ID__GETCOUNTRYBYPROVINCEID) {
			return ISTGService.METHOD__GETCOUNTRYBYPROVINCEID;
		} else if (methodId == ISTGService.ID__GETPROVINCEBYCITYID) {
			return ISTGService.METHOD__GETPROVINCEBYCITYID;
		} else if (methodId == ISTGService.ID__GETCOUNTRYBYCOUNTRYID) {
			return ISTGService.METHOD__GETCOUNTRYBYCOUNTRYID;
		} else if (methodId == ISTGService.ID__GETPROVINCEBYPROVINCEID) {
			return ISTGService.METHOD__GETPROVINCEBYPROVINCEID;
		} else if (methodId == ISTGService.ID__GETCITYBYCITYID) {
			return ISTGService.METHOD__GETCITYBYCITYID;
		} else if (methodId == ISTGService.ID__GETPERMISSIONSDICT) {
			return ISTGService.METHOD__GETPERMISSIONSDICT;
		} else if (methodId == ISTGService.ID__GETTOURSTATUSDICT) {
			return ISTGService.METHOD__GETTOURSTATUSDICT;
		} else if (methodId == ISTGService.ID__INSERTCOUNTRY) {
			return ISTGService.METHOD__INSERTCOUNTRY;
		} else if (methodId == ISTGService.ID__UPDATECOUNTRY) {
			return ISTGService.METHOD__UPDATECOUNTRY;
		} else if (methodId == ISTGService.ID__DELETECOUNTRY) {
			return ISTGService.METHOD__DELETECOUNTRY;
		} else if (methodId == ISTGService.ID__INSERTPROVINCE) {
			return ISTGService.METHOD__INSERTPROVINCE;
		} else if (methodId == ISTGService.ID__UPDATEPROVINCE) {
			return ISTGService.METHOD__UPDATEPROVINCE;
		} else if (methodId == ISTGService.ID__DELETEPROVINCE) {
			return ISTGService.METHOD__DELETEPROVINCE;
		} else if (methodId == ISTGService.ID__INSERTCITY) {
			return ISTGService.METHOD__INSERTCITY;
		} else if (methodId == ISTGService.ID__UPDATECITY) {
			return ISTGService.METHOD__UPDATECITY;
		} else if (methodId == ISTGService.ID__DELETECITY) {
			return ISTGService.METHOD__DELETECITY;
		} else if (methodId == ISTGService.ID__GETPICTUREBYPICTUREID) {
			return ISTGService.METHOD__GETPICTUREBYPICTUREID;
		} else if (methodId == ISTGService.ID__SAVEPICTURES) {
			return ISTGService.METHOD__SAVEPICTURES;
		} else if (methodId == ISTGService.ID__GETSIGHTS) {
			return ISTGService.METHOD__GETSIGHTS;
		} else if (methodId == ISTGService.ID__GETSIGHTSBYCOUNTRYID) {
			return ISTGService.METHOD__GETSIGHTSBYCOUNTRYID;
		} else if (methodId == ISTGService.ID__GETSIGHTSBYPROVINCEID) {
			return ISTGService.METHOD__GETSIGHTSBYPROVINCEID;
		} else if (methodId == ISTGService.ID__GETSIGHTSBYCITYID) {
			return ISTGService.METHOD__GETSIGHTSBYCITYID;
		} else if (methodId == ISTGService.ID__GETSIGHTSBYSIGHTSID) {
			return ISTGService.METHOD__GETSIGHTSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETAVERAGESTARSBYSIGHTSID) {
			return ISTGService.METHOD__GETAVERAGESTARSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETPICTURESBYSIGHTSIDANDUPLOADERID) {
			return ISTGService.METHOD__GETPICTURESBYSIGHTSIDANDUPLOADERID;
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTS) {
			return ISTGService.METHOD__GETVISITEDSIGHTS;
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYCOUNTRYID) {
			return ISTGService.METHOD__GETVISITEDSIGHTSBYCOUNTRYID;
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYPROVINCEID) {
			return ISTGService.METHOD__GETVISITEDSIGHTSBYPROVINCEID;
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYCITYID) {
			return ISTGService.METHOD__GETVISITEDSIGHTSBYCITYID;
		} else if (methodId == ISTGService.ID__INSERTSIGHTS) {
			return ISTGService.METHOD__INSERTSIGHTS;
		} else if (methodId == ISTGService.ID__UPDATESIGHTS) {
			return ISTGService.METHOD__UPDATESIGHTS;
		} else if (methodId == ISTGService.ID__DELETESIGHTS) {
			return ISTGService.METHOD__DELETESIGHTS;
		} else if (methodId == ISTGService.ID__GETTOURSBYUSERID) {
			return ISTGService.METHOD__GETTOURSBYUSERID;
		} else if (methodId == ISTGService.ID__GETTOURBYTOURID) {
			return ISTGService.METHOD__GETTOURBYTOURID;
		} else if (methodId == ISTGService.ID__GETTOURSBYSIGHTSID) {
			return ISTGService.METHOD__GETTOURSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETTOURSBYDATE) {
			return ISTGService.METHOD__GETTOURSBYDATE;
		} else if (methodId == ISTGService.ID__GETTOURSBYSIGHTSIDANDDATE) {
			return ISTGService.METHOD__GETTOURSBYSIGHTSIDANDDATE;
		} else if (methodId == ISTGService.ID__DELETETOUR) {
			return ISTGService.METHOD__DELETETOUR;
		} else if (methodId == ISTGService.ID__SAVETOUR) {
			return ISTGService.METHOD__SAVETOUR;
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYTOURID) {
			return ISTGService.METHOD__GETSUBTOURSBYTOURID;
		} else if (methodId == ISTGService.ID__GETSUBTOURBYTOURIDANDSUBTOURID) {
			return ISTGService.METHOD__GETSUBTOURBYTOURIDANDSUBTOURID;
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYUSERID) {
			return ISTGService.METHOD__GETSUBTOURSBYUSERID;
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYSIGHTSID) {
			return ISTGService.METHOD__GETSUBTOURSBYSIGHTSID;
		} else if (methodId == ISTGService.ID__GETPICTURESBYTOURID) {
			return ISTGService.METHOD__GETPICTURESBYTOURID;
		} else if (methodId == ISTGService.ID__GETPICTURESBYTOURIDANDSUBTOURID) {
			return ISTGService.METHOD__GETPICTURESBYTOURIDANDSUBTOURID;
		} else {
			return "";
		}
	}

	private SoapObject GetSoapResponse(int methodId, HashMap<String, Object> params) {
		try {
			String methodName = getMethodName(methodId);
			if (methodName.equals("")) {
				return null;
			}
			String soapAction = WS_NAMESPACE + methodName;
			SoapObject request = new SoapObject(WS_NAMESPACE, methodName);

			if (params != null) {
				Iterator<Entry<String, Object>> iter = params.entrySet().iterator();
				while (iter.hasNext()) {
					Entry<String, Object> entry = iter.next();
					request.addProperty(entry.getKey(), entry.getValue());
				}
			}

			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			HttpTransportSE androidHttpTransport = new HttpTransportSE(WS_URL);

			System.out.println("访问WebService---->" + WS_URL + "?" + methodName);

			androidHttpTransport.call(soapAction, envelope); // 调用web service
			SoapObject response = (SoapObject) envelope.getResponse();

			if (response != null) {
				System.out.println("WebService返回---->" + response.toString());

				response = (SoapObject) response.getProperty(0);
				String msg = response.getPropertySafelyAsString("Message");
				if (!msg.equals("") && !msg.equals("anyType{}")) {
					System.out.println("WebService内部业务发生错误---->" + msg);
					return null;
				}
				return (SoapObject) response.getProperty(1);
			} else {
				System.out.println("WebService返回空值");
				return null;
			}
		} catch (Exception ex) {
			System.out.println("访问WebService错误---->" + ex.getMessage());
			return null;
		}
	}

	@Override
	public List<User> getUsers() {
		SoapObject response = GetSoapResponse(ISTGService.ID__GETUSERS, null);
		if (response != null) {
			return ModelAPI.parseUsers(response);
		} else {
			return null;
		}
	}

	@Override
	public User getUserByUserId(String userId) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__GETUSERBYUSERID, userId);
		SoapObject response = GetSoapResponse(ISTGService.ID__GETUSERBYUSERID, params);
		if (response != null) {
			return ModelAPI.parseUser(response);
		} else {
			return null;
		}
	}

	@Override
	public String helloWorld() {
		SoapObject response = GetSoapResponse(ISTGService.ID__HELLOWORLD, null);
		if (response != null) {
			return ModelAPI.parseString(response);
		} else {
			return null;
		}
	}

	@Override
	public User login(String loginName, String password) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__LOGIN__LOGINNAME, loginName);
		params.put(ISTGService.PARAM__LOGIN__PASSWORD, password);
		SoapObject response = GetSoapResponse(ISTGService.ID__LOGIN, params);
		if (response != null) {
			return ModelAPI.parseUser(response);
		} else {
			return null;
		}
	}

	@Override
	public User getUserByLoginName(String loginName) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public User getUserByEmail(String email) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Permission> getPermissionsByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean insertUser(User user, String password) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__INSERTUSER__INPUTUSER, ModelAPI.convertToString(user));
		params.put(ISTGService.PARAM__INSERTUSER__PASSWORD, password);
		SoapObject response = GetSoapResponse(ISTGService.ID__INSERTUSER, params);
		if (response != null) {
			return ModelAPI.parseBoolean(response);
		} else {
			return false;
		}
	}

	@Override
	public boolean updateUser(User user) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Favorite> getFavoritesByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Favorite getFavoriteByUserIdAndSightsId(String userId, String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean updatePermissionsByUserId(String userId, List<Permission> permissions) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean saveFavorite(Favorite favorite) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Blog> getBlogsByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Blog> getBlogsBySightsId(String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Blog> getBlogsByUserIdAndSightsId(String userId, String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Blog> getBlogsByTourIdAndSubTourId(String tourId, String subTourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Blog getBlogByBlogId(String blogId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Blog> getBlogsByTourId(String tourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean deleteBlog(Blog blog, boolean deletePictures) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean saveBlog(Blog blog) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<PictureComment> getPictureCommentsByPictureId(String pictureId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<SightsComment> getSightsCommentsBySightsId(String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<TourComment> getTourCommentsByTourId(String tourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<UserComment> getUserCommentsByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean insertPictureComment(PictureComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updatePictureComment(PictureComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deletePictureComment(PictureComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertSightsComment(SightsComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateSightsComment(SightsComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteSightsComment(SightsComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertTourComment(TourComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateTourComment(TourComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteTourComment(TourComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertUserComment(UserComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateUserComment(UserComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteUserComment(UserComment comment) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Country> getCountries() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Province> getProvinces() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<City> getCities() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Province> getProvincesByCountryId(String countryId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<City> getCitiesByProvinceId(String provinceId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<City> getCitiesByCountryId(String countryId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Country getCountryByProvinceId(String provinceId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Province getProvinceByCityId(String cityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Country getCountryByCountryId(String countryId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Province getProvinceByProvinceId(String provinceId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public City getCityByCityId(String cityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public HashMap<Integer, String> getPermissionsDict() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public HashMap<Integer, String> getTourStatusDict() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean insertCountry(Country country) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateCountry(Country country) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteCountry(Country country) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertProvince(Province province) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateProvince(Province province) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteProvince(Province province) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertCity(City city) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateCity(City city) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteCity(City city) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public Picture getPictureByPictureId(String pictureId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean savePictures(List<Picture> pictures, List<Picture> removedPictures) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Sights> getSights() {
		SoapObject response = GetSoapResponse(ISTGService.ID__GETSIGHTS, null);
		if (response != null) {
			return ModelAPI.parseSightsList(response);
		} else {
			return null;
		}
	}

	@Override
	public List<Sights> getSightsByCountryId(String countryId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getSightsByProvinceId(String provinceId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getSightsByCityId(String cityId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public Sights getSightsBySightsId(String sightsId) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__GETSIGHTSBYSIGHTSID,sightsId);
		SoapObject response = GetSoapResponse(ISTGService.ID__GETSIGHTSBYSIGHTSID, params);
		return ModelAPI.parseSights(response);
	}

	@Override
	public float getAverageStarsBySightsId(String sightsId) {
		// TODO Auto-generated method stub
		return 0;
	}

	@Override
	public List<Picture> getPicturesBySightsIdAndUploaderId(String sightsId, String uploaderId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getVisitedSights(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getVisitedSightsByCountryId(String countryId, String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getVisitedSightsByProvinceId(String provinceId, String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Sights> getVisitedSightsByCityId(String cityId, String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean insertSights(Sights sights, List<Picture> pictures) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean updateSights(Sights sights, List<Picture> pictures, List<Picture> removedPictures) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean deleteSights(Sights sights) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<Tour> getToursByUserId(String userId) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__GETTOURSBYUSERID, userId);
		SoapObject response = GetSoapResponse(ISTGService.ID__GETTOURSBYUSERID, params);
		if (response != null) {
			return ModelAPI.parseTours(response);
		} else {
			return null;
		}
	}

	@Override
	public Tour getTourByTourId(String tourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Tour> getToursBySightsId(String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Tour> getToursByDate(Date date) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Tour> getToursBySightsIdAndDate(String sightsId, Date date) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean deleteTour(Tour tour, boolean deletePictures) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean saveTour(Tour tour, List<SubTour> subTours, List<SubTour> removedSubTours) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public List<SubTour> getSubToursByTourId(String tourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public SubTour getSubTourByTourIdAndSubTourId(String tourId, String subTourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<SubTour> getSubToursByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<SubTour> getSubToursBySightsId(String sightsId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Picture> getPicturesByTourId(String tourId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<Picture> getPicturesByTourIdAndSubTourId(String tourId, String subTourId) {
		// TODO Auto-generated method stub
		return null;
	}
}