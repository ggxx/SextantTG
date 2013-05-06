package com.ss.stg.ws;

import java.io.Serializable;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import com.ss.stg.model.*;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;

/**
 * 启用新的线程访问WebService, 对传入的参数进行转换
 * 
 * @author ggxx
 * 
 */
public class WebServiceThread extends Thread {

	private Handler handler = null;
	private ISTGService stgService = null;
	private HashMap<String, Object> params = null;
	private int methodId = 0;
	private ProgressDialog progressDialog = null;

	// 构造函数
	public WebServiceThread(Handler handler, int methodId, HashMap<String, Object> params) {
		this.handler = handler;
		this.methodId = methodId;
		this.params = params;
		this.stgService = new STGService();
	}

	public WebServiceThread(Handler handler, int methodId) {
		this.handler = handler;
		this.methodId = methodId;
		this.stgService = new STGService();
	}

	public void startWithProgressDialog(Context context) {
		progressDialog = ProgressDialog.show(context, "提示", "正在加载数据，请稍后......", true);
		this.start();
	}

	@Override
	public void run() {
		super.run();
		System.out.println("启动线程----->" + Thread.currentThread().getId());
		callWebService();

		// 取消进度对话框
		if (progressDialog != null) {
			progressDialog.dismiss();
		}
	}

	// //调用webService
	private void callWebService() {

		Object obj = null;

		if (this.methodId == ISTGService.ID__HELLOWORLD) {
			obj = stgService.helloWorld();
		} else if (this.methodId == ISTGService.ID__GETUSERS) {
			obj = stgService.getUsers();
		} else if (methodId == ISTGService.ID__LOGIN) {
			String loginName = this.params.get(ISTGService.PARAM__LOGIN__LOGINNAME).toString();
			String password = this.params.get(ISTGService.PARAM__LOGIN__PASSWORD).toString();
			obj = stgService.login(loginName, password);
		} else if (methodId == ISTGService.ID__GETUSERBYLOGINNAME) {
			String loginName = this.params.get(ISTGService.PARAM__GETUSERBYLOGINNAME).toString();
			obj = stgService.getUserByLoginName(loginName);
		} else if (methodId == ISTGService.ID__GETUSERBYEMAIL) {
			String email = this.params.get(ISTGService.PARAM__GETUSERBYEMAIL).toString();
			obj = stgService.getUserByEmail(email);
		} else if (methodId == ISTGService.ID__GETUSERBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETUSERBYUSERID).toString();
			obj = stgService.getUserByUserId(userId);
		} else if (methodId == ISTGService.ID__GETPERMISSIONSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETPERMISSIONSBYUSERID).toString();
			obj = stgService.getPermissionsByUserId(userId);
		} else if (methodId == ISTGService.ID__INSERTUSER) {
			User user = (User) this.params.get(ISTGService.PARAM__INSERTUSER__INPUTUSER);
			String password = this.params.get(ISTGService.PARAM__INSERTUSER__PASSWORD).toString();
			obj = stgService.insertUser(user, password);
		} else if (methodId == ISTGService.ID__UPDATEUSER) {
			User user = (User) this.params.get(ISTGService.PARAM__UPDATEUSER);
			obj = stgService.updateUser(user);
		} else if (methodId == ISTGService.ID__GETFAVORITESBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETFAVORITESBYUSERID).toString();
			obj = stgService.getFavoritesByUserId(userId);
		} else if (methodId == ISTGService.ID__GETFAVORITEBYUSERIDANDSIGHTSID) {
			String userId = this.params.get(ISTGService.PARAM__GETFAVORITEBYUSERIDANDSIGHTSID__USERID).toString();
			String sightsId = this.params.get(ISTGService.PARAM__GETFAVORITEBYUSERIDANDSIGHTSID__SIGHTSID).toString();
			obj = stgService.getFavoriteByUserIdAndSightsId(userId, sightsId);
		} else if (methodId == ISTGService.ID__UPDATEPERMISSIONSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__UPDATEPERMISSIONSBYUSERID__USERID).toString();
			List<Permission> permissions = (List<Permission>) this.params.get(ISTGService.PARAM__UPDATEPERMISSIONSBYUSERID__INPUTPERMISSIONS);
			obj = stgService.updatePermissionsByUserId(userId, permissions);
		} else if (methodId == ISTGService.ID__SAVEFAVORITE) {
			Favorite favorite = (Favorite) this.params.get(ISTGService.PARAM__SAVEFAVORITE);
			obj = stgService.saveFavorite(favorite);
		} else if (methodId == ISTGService.ID__GETBLOGSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETBLOGSBYUSERID).toString();
			obj = stgService.getBlogsByUserId(userId);
		} else if (methodId == ISTGService.ID__GETBLOGSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETBLOGSBYSIGHTSID).toString();
			obj = stgService.getBlogsBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETBLOGSBYUSERIDANDSIGHTSID) {
			String userId = this.params.get(ISTGService.PARAM__GETBLOGSBYUSERIDANDSIGHTSID__USRID).toString();
			String sightsId = this.params.get(ISTGService.PARAM__GETBLOGSBYUSERIDANDSIGHTSID__SIGHTSID).toString();
			obj = stgService.getBlogsByUserIdAndSightsId(userId, sightsId);
		} else if (methodId == ISTGService.ID__GETBLOGSBYTOURIDANDSUBTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETBLOGSBYTOURIDANDSUBTOURID__TOURID).toString();
			String subTourId = this.params.get(ISTGService.PARAM__GETBLOGSBYTOURIDANDSUBTOURID__SUBTOURID).toString();
			obj = stgService.getBlogsByTourIdAndSubTourId(tourId, subTourId);
		} else if (methodId == ISTGService.ID__GETBLOGBYBLOGID) {
			String blogId = this.params.get(ISTGService.PARAM__GETBLOGBYBLOGID).toString();
			obj = stgService.getBlogByBlogId(blogId);
		} else if (methodId == ISTGService.ID__GETBLOGSBYTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETBLOGSBYTOURID).toString();
			obj = stgService.getBlogsByTourId(tourId);
		} else if (methodId == ISTGService.ID__DELETEBLOG) {
			Blog blog = (Blog) this.params.get(ISTGService.PARAM__DELETEBLOG__INPUTBLOG);
			boolean deletePictures = Boolean.parseBoolean(this.params.get(ISTGService.PARAM__DELETEBLOG__DELETEPICTURES).toString());
			obj = stgService.deleteBlog(blog, deletePictures);
		} else if (methodId == ISTGService.ID__SAVEBLOG) {
			Blog blog = (Blog) this.params.get(ISTGService.PARAM__SAVEBLOG);
			obj = stgService.saveBlog(blog);
		} else if (methodId == ISTGService.ID__GETPICTURECOMMENTSBYPICTUREID) {
			String pictureId = this.params.get(ISTGService.PARAM__GETPICTURECOMMENTSBYPICTUREID).toString();
			obj = stgService.getPictureCommentsByPictureId(pictureId);
		} else if (methodId == ISTGService.ID__GETSIGHTSCOMMENTSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETSIGHTSCOMMENTSBYSIGHTSID).toString();
			obj = stgService.getSightsCommentsBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETTOURCOMMENTSBYTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETTOURCOMMENTSBYTOURID).toString();
			obj = stgService.getTourCommentsByTourId(tourId);
		} else if (methodId == ISTGService.ID__GETUSERCOMMENTSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETUSERCOMMENTSBYUSERID).toString();
			obj = stgService.getUserCommentsByUserId(userId);
		} else if (methodId == ISTGService.ID__INSERTPICTURECOMMENT) {
			PictureComment comment = (PictureComment) this.params.get(ISTGService.PARAM__INSERTPICTURECOMMENT);
			obj = stgService.insertPictureComment(comment);
		} else if (methodId == ISTGService.ID__UPDATEPICTURECOMMENT) {
			PictureComment comment = (PictureComment) this.params.get(ISTGService.PARAM__UPDATEPICTURECOMMENT);
			obj = stgService.updatePictureComment(comment);
		} else if (methodId == ISTGService.ID__DELETEPICTURECOMMENT) {
			PictureComment comment = (PictureComment) this.params.get(ISTGService.PARAM__DELETEPICTURECOMMENT);
			obj = stgService.deletePictureComment(comment);
		} else if (methodId == ISTGService.ID__INSERTSIGHTSCOMMENT) {
			SightsComment comment = (SightsComment) this.params.get(ISTGService.PARAM__INSERTSIGHTSCOMMENT);
			obj = stgService.insertSightsComment(comment);
		} else if (methodId == ISTGService.ID__UPDATESIGHTSCOMMENT) {
			SightsComment comment = (SightsComment) this.params.get(ISTGService.PARAM__UPDATESIGHTSCOMMENT);
			obj = stgService.updateSightsComment(comment);
		} else if (methodId == ISTGService.ID__DELETESIGHTSCOMMENT) {
			SightsComment comment = (SightsComment) this.params.get(ISTGService.PARAM__DELETESIGHTSCOMMENT);
			obj = stgService.deleteSightsComment(comment);
		} else if (methodId == ISTGService.ID__INSERTTOURCOMMENT) {
			TourComment comment = (TourComment) this.params.get(ISTGService.PARAM__INSERTTOURCOMMENT);
			obj = stgService.insertTourComment(comment);
		} else if (methodId == ISTGService.ID__UPDATETOURCOMMENT) {
			TourComment comment = (TourComment) this.params.get(ISTGService.PARAM__UPDATETOURCOMMENT);
			obj = stgService.updateTourComment(comment);
		} else if (methodId == ISTGService.ID__DELETETOURCOMMENT) {
			TourComment comment = (TourComment) this.params.get(ISTGService.PARAM__DELETETOURCOMMENT);
			obj = stgService.deleteTourComment(comment);
		} else if (methodId == ISTGService.ID__INSERTUSERCOMMENT) {
			UserComment comment = (UserComment) this.params.get(ISTGService.PARAM__INSERTUSERCOMMENT);
			obj = stgService.insertUserComment(comment);
		} else if (methodId == ISTGService.ID__UPDATEUSERCOMMENT) {
			UserComment comment = (UserComment) this.params.get(ISTGService.PARAM__UPDATEUSERCOMMENT);
			obj = stgService.updateUserComment(comment);
		} else if (methodId == ISTGService.ID__DELETEUSERCOMMENT) {
			UserComment comment = (UserComment) this.params.get(ISTGService.PARAM__DELETEUSERCOMMENT);
			obj = stgService.deleteUserComment(comment);
		} else if (methodId == ISTGService.ID__GETCOUNTRIES) {
			obj = stgService.getCountries();
		} else if (methodId == ISTGService.ID__GETPROVINCES) {
			obj = stgService.getProvinces();
		} else if (methodId == ISTGService.ID__GETCITIES) {
			obj = stgService.getCities();
		} else if (methodId == ISTGService.ID__GETPROVINCESBYCOUNTRYID) {
			String countryId = this.params.get(ISTGService.PARAM__GETPROVINCESBYCOUNTRYID).toString();
			obj = stgService.getProvincesByCountryId(countryId);
		} else if (methodId == ISTGService.ID__GETCITIESBYPROVINCEID) {
			String provinceId = this.params.get(ISTGService.PARAM__GETCITIESBYPROVINCEID).toString();
			obj = stgService.getCitiesByProvinceId(provinceId);
		} else if (methodId == ISTGService.ID__GETCITIESBYCOUNTRYID) {
			String countryId = this.params.get(ISTGService.PARAM__GETCITIESBYCOUNTRYID).toString();
			obj = stgService.getCitiesByCountryId(countryId);
		} else if (methodId == ISTGService.ID__GETCOUNTRYBYPROVINCEID) {
			String provinceId = this.params.get(ISTGService.PARAM__GETCOUNTRYBYPROVINCEID).toString();
			obj = stgService.getCountryByProvinceId(provinceId);
		} else if (methodId == ISTGService.ID__GETPROVINCEBYCITYID) {
			String cityId = this.params.get(ISTGService.PARAM__GETPROVINCEBYCITYID).toString();
			obj = stgService.getProvinceByCityId(cityId);
		} else if (methodId == ISTGService.ID__GETCOUNTRYBYCOUNTRYID) {
			String countryId = this.params.get(ISTGService.PARAM__GETCOUNTRYBYCOUNTRYID).toString();
			obj = stgService.getCountryByCountryId(countryId);
		} else if (methodId == ISTGService.ID__GETPROVINCEBYPROVINCEID) {
			String provinceId = this.params.get(ISTGService.PARAM__GETPROVINCEBYPROVINCEID).toString();
			obj = stgService.getProvinceByProvinceId(provinceId);
		} else if (methodId == ISTGService.ID__GETCITYBYCITYID) {
			String cityId = this.params.get(ISTGService.PARAM__GETCITYBYCITYID).toString();
			obj = stgService.getCityByCityId(cityId);
		} else if (methodId == ISTGService.ID__GETPERMISSIONSDICT) {
			obj = stgService.getPermissionsDict();
		} else if (methodId == ISTGService.ID__GETTOURSTATUSDICT) {
			obj = stgService.getTourStatusDict();
		} else if (methodId == ISTGService.ID__INSERTCOUNTRY) {
			Country country = (Country) this.params.get(ISTGService.PARAM__INSERTCOUNTRY);
			obj = stgService.insertCountry(country);
		} else if (methodId == ISTGService.ID__UPDATECOUNTRY) {
			Country country = (Country) this.params.get(ISTGService.PARAM__UPDATECOUNTRY);
			obj = stgService.updateCountry(country);
		} else if (methodId == ISTGService.ID__DELETECOUNTRY) {
			Country country = (Country) this.params.get(ISTGService.PARAM__DELETECOUNTRY);
			obj = stgService.deleteCountry(country);
		} else if (methodId == ISTGService.ID__INSERTPROVINCE) {
			Province province = (Province) this.params.get(ISTGService.PARAM__INSERTPROVINCE);
			obj = stgService.insertProvince(province);
		} else if (methodId == ISTGService.ID__UPDATEPROVINCE) {
			Province province = (Province) this.params.get(ISTGService.PARAM__UPDATEPROVINCE);
			obj = stgService.updateProvince(province);
		} else if (methodId == ISTGService.ID__DELETEPROVINCE) {
			Province province = (Province) this.params.get(ISTGService.PARAM__DELETEPROVINCE);
			obj = stgService.deleteProvince(province);
		} else if (methodId == ISTGService.ID__INSERTCITY) {
			City city = (City) this.params.get(ISTGService.PARAM__INSERTCITY);
			obj = stgService.insertCity(city);
		} else if (methodId == ISTGService.ID__UPDATECITY) {
			City city = (City) this.params.get(ISTGService.PARAM__UPDATECITY);
			obj = stgService.updateCity(city);
		} else if (methodId == ISTGService.ID__DELETECITY) {
			City city = (City) this.params.get(ISTGService.PARAM__DELETECITY);
			obj = stgService.deleteCity(city);
		} else if (methodId == ISTGService.ID__GETPICTUREBYPICTUREID) {
			String pictureId = this.params.get(ISTGService.PARAM__GETPICTUREBYPICTUREID).toString();
			obj = stgService.getPictureByPictureId(pictureId);
		} else if (methodId == ISTGService.ID__SAVEPICTURES) {
			List<Picture> pictures = (List<Picture>) this.params.get(ISTGService.PARAM__SAVEPICTURES__INPUTPICTURES);
			List<Picture> removedPictures = (List<Picture>) this.params.get(ISTGService.PARAM__SAVEPICTURES__INPUTREMOVEDPICTURES);
			obj = stgService.savePictures(pictures, removedPictures);
		} else if (methodId == ISTGService.ID__GETSIGHTS) {
			obj = stgService.getSights();
		} else if (methodId == ISTGService.ID__GETSIGHTSBYCOUNTRYID) {
			String countryId = this.params.get(ISTGService.PARAM__GETSIGHTSBYCOUNTRYID).toString();
			obj = stgService.getSightsByCountryId(countryId);
		} else if (methodId == ISTGService.ID__GETSIGHTSBYPROVINCEID) {
			String provinceId = this.params.get(ISTGService.PARAM__GETSIGHTSBYPROVINCEID).toString();
			obj = stgService.getSightsByProvinceId(provinceId);
		} else if (methodId == ISTGService.ID__GETSIGHTSBYCITYID) {
			String cityId = this.params.get(ISTGService.PARAM__GETSIGHTSBYCITYID).toString();
			obj = stgService.getSightsByCityId(cityId);
		} else if (methodId == ISTGService.ID__GETSIGHTSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETSIGHTSBYSIGHTSID).toString();
			obj = stgService.getSightsBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETAVERAGESTARSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETAVERAGESTARSBYSIGHTSID).toString();
			obj = stgService.getAverageStarsBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETPICTURESBYSIGHTSIDANDUPLOADERID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETPICTURESBYSIGHTSIDANDUPLOADERID__SIGHTSID).toString();
			String uploaderId = this.params.get(ISTGService.PARAM__GETPICTURESBYSIGHTSIDANDUPLOADERID__UPLOADERID).toString();
			obj = stgService.getPicturesBySightsIdAndUploaderId(sightsId, uploaderId);
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTS) {
			String userId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTS).toString();
			obj = stgService.getVisitedSights(userId);
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYCOUNTRYID) {
			String countryId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYCOUNTRYID__COUNTRYID).toString();
			String userId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYCOUNTRYID__USERID).toString();
			obj = stgService.getVisitedSightsByCountryId(countryId, userId);
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYPROVINCEID) {
			String provinceId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYPROVINCEID__PROVINCEID).toString();
			String userId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYPROVINCEID__USERID).toString();
			obj = stgService.getVisitedSightsByProvinceId(provinceId, userId);
		} else if (methodId == ISTGService.ID__GETVISITEDSIGHTSBYCITYID) {
			String cityId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYCITYID__CITYID).toString();
			String userId = this.params.get(ISTGService.PARAM__GETVISITEDSIGHTSBYCITYID__USERID).toString();
			obj = stgService.getVisitedSightsByCityId(cityId, userId);
		} else if (methodId == ISTGService.ID__INSERTSIGHTS) {
			Sights sights = (Sights) this.params.get(ISTGService.PARAM__INSERTSIGHTS__INPUTSIGHTS);
			List<Picture> pictures = (List<Picture>) this.params.get(ISTGService.PARAM__INSERTSIGHTS__INPUTPICTURES);
			obj = stgService.insertSights(sights, pictures);
		} else if (methodId == ISTGService.ID__UPDATESIGHTS) {
			Sights sights = (Sights) this.params.get(ISTGService.PARAM__UPDATESIGHTS__INPUTSIGHTS);
			List<Picture> pictures = (List<Picture>) this.params.get(ISTGService.PARAM__UPDATESIGHTS__INPUTPICTURES);
			List<Picture> removedPictures = (List<Picture>) this.params.get(ISTGService.PARAM__UPDATESIGHTS__INPUTREMOVEDPICTURES);
			obj = stgService.updateSights(sights, pictures, removedPictures);
		} else if (methodId == ISTGService.ID__DELETESIGHTS) {
			Sights sights = (Sights) this.params.get(ISTGService.PARAM__DELETESIGHTS);
			obj = stgService.deleteSights(sights);
		} else if (methodId == ISTGService.ID__GETTOURSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETTOURSBYUSERID).toString();
			obj = stgService.getToursByUserId(userId);
		} else if (methodId == ISTGService.ID__GETTOURBYTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETTOURBYTOURID).toString();
			obj = stgService.getTourByTourId(tourId);
		} else if (methodId == ISTGService.ID__GETTOURSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETTOURSBYSIGHTSID).toString();
			obj = stgService.getToursBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETTOURSBYDATE) {
			Date date = new Date(this.params.get(ISTGService.PARAM__GETTOURSBYDATE).toString());
			obj = stgService.getToursByDate(date);
		} else if (methodId == ISTGService.ID__GETTOURSBYSIGHTSIDANDDATE) {
			String sightsId = this.params.get(ISTGService.PARAM__GETTOURSBYSIGHTSIDANDDATE_SIGHTSID).toString();
			Date date = new Date(this.params.get(ISTGService.PARAM__GETTOURSBYSIGHTSIDANDDATE_DATE).toString());
			obj = stgService.getToursBySightsIdAndDate(sightsId, date);
		} else if (methodId == ISTGService.ID__DELETETOUR) {
			Tour tour = (Tour) this.params.get(ISTGService.PARAM__DELETETOUR__INPUTTOUR);
			boolean deletePictures = Boolean.parseBoolean(this.params.get(ISTGService.PARAM__DELETETOUR__DELETEPICTURES).toString());
			obj = stgService.deleteTour(tour, deletePictures);
		} else if (methodId == ISTGService.ID__SAVETOUR) {
			Tour tour = (Tour) this.params.get(ISTGService.PARAM__SAVETOUR__INPUTTOUR);
			List<SubTour> subTours = (List<SubTour>) this.params.get(ISTGService.PARAM__SAVETOUR__INPUTSUBTOURS);
			List<SubTour> removedSubTours = (List<SubTour>) this.params.get(ISTGService.PARAM__SAVETOUR__INPUTREMOVEDSUBTOURS);
			obj = stgService.saveTour(tour, subTours, removedSubTours);
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETSUBTOURSBYTOURID).toString();
			obj = stgService.getSubToursByTourId(tourId);
		} else if (methodId == ISTGService.ID__GETSUBTOURBYTOURIDANDSUBTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETSUBTOURBYTOURIDANDSUBTOURID__TOURID).toString();
			String subTourId = this.params.get(ISTGService.PARAM__GETSUBTOURBYTOURIDANDSUBTOURID__SUBTOURID).toString();
			obj = stgService.getSubTourByTourIdAndSubTourId(tourId, subTourId);
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYUSERID) {
			String userId = this.params.get(ISTGService.PARAM__GETSUBTOURSBYUSERID).toString();
			obj = stgService.getSubToursByUserId(userId);
		} else if (methodId == ISTGService.ID__GETSUBTOURSBYSIGHTSID) {
			String sightsId = this.params.get(ISTGService.PARAM__GETSUBTOURSBYSIGHTSID).toString();
			obj = stgService.getSubToursBySightsId(sightsId);
		} else if (methodId == ISTGService.ID__GETPICTURESBYTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETPICTURESBYTOURID).toString();
			obj = stgService.getPicturesByTourId(tourId);
		} else if (methodId == ISTGService.ID__GETPICTURESBYTOURIDANDSUBTOURID) {
			String tourId = this.params.get(ISTGService.PARAM__GETPICTURESBYTOURIDANDSUBTOURID__TOURID).toString();
			String subTourId = this.params.get(ISTGService.PARAM__GETPICTURESBYTOURIDANDSUBTOURID__SUBTOURID).toString();
			obj = stgService.getPicturesByTourIdAndSubTourId(tourId, subTourId);
		} else {

		}

		try {
			if (obj != null) {
				Message message = handler.obtainMessage();
				message.what = methodId;
				Bundle bundle = new Bundle();
				bundle.putSerializable(ISTGService.WS_RETURN, (Serializable) obj);
				message.setData(bundle);
				handler.sendMessage(message);
			} else {
				// System.out.println("return result--->null");
			}
		} catch (Exception e) {
			Message message = handler.obtainMessage();
			Bundle bundle = new Bundle();
			message.what = ISTGService.ID__ERROR;
			bundle.putString(ISTGService.WS_RETURN, e.getMessage());
			message.setData(bundle);
			handler.sendMessage(message);
		}
	}

}
