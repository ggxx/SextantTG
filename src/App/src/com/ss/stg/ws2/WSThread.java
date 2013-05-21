package com.ss.stg.ws2;

import java.io.Serializable;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;

import com.ss.stg.dto.*;

public class WSThread extends Thread {
	private Handler handler = null;
	private IWebService ws = null;
	private HashMap<String, Object> params = null;
	private int methodId = 0;
	private ProgressDialog progressDialog = null;

	// 构造函数
	public WSThread(Handler handler, int methodId, HashMap<String, Object> params) {
		this.handler = handler;
		this.methodId = methodId;
		this.params = params;
		this.ws = new WebService();
	}

	public WSThread(Handler handler, int methodId) {
		this.handler = handler;
		this.methodId = methodId;
		this.ws = new WebService();
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

		Object returnObject = null;

		try {
			if (this.methodId == IWebService.ID__HELLO_WORLD) {
				returnObject = ws.helloWorld();
			} else if (this.methodId == IWebService.ID__LOGIN) {
				String loginName = this.params.get(IWebService.PARAM__LOGIN__LOGIN_NAME).toString();
				String password = this.params.get(IWebService.PARAM__LOGIN__PASSWORD).toString();
				returnObject = ws.login(loginName, password);
			} else if (this.methodId == IWebService.ID__REGIST) {
				UserObject user = (UserObject) this.params.get(IWebService.PARAM__REGIST__USER);
				String password = this.params.get(IWebService.PARAM__REGIST__PASSWORD).toString();
				returnObject = ws.regist(user, password);
			} else if (this.methodId == IWebService.ID__GET_SIGHTS) {
				returnObject = ws.getSights();
			} else if (this.methodId == IWebService.ID__GET_SIGHTS_BY_USERID) {
				String userId = this.params.get(IWebService.PARAM__GET_SIGHTS_BY_USERID).toString();
				returnObject = ws.getSightsByUserId(userId);
			} else if (this.methodId == IWebService.ID__GET_SIGHT_BY_SIGHTID) {
				String sightsId = this.params.get(IWebService.PARAM__GET_SIGHT_BY_SIGHTID).toString();
				returnObject = ws.getSightBySightId(sightsId);
			} else if (this.methodId == IWebService.ID__GET_SIGHT_BY_SIGHTID_AND_USERID) {
				String sightsId = this.params.get(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__SIGHTID).toString();
				String userId = this.params.get(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__USERID).toString();
				returnObject = ws.getSightBySightIdAndUserId(sightsId, userId);
			} else if (this.methodId == IWebService.ID__GET_TOURS_BY_USERID) {
				String userId = this.params.get(IWebService.PARAM__GET_TOURS_BY_USERID).toString();
				returnObject = ws.getToursByUserId(userId);
			} else if (this.methodId == IWebService.ID__GET_TOUR_BY_TOURID) {
				String tourId = this.params.get(IWebService.PARAM__GET_TOUR_BY_TOURID).toString();
				returnObject = ws.getTourByTourId(tourId);
			} else if (this.methodId == IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID) {
				String tourId = this.params.get(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID).toString();
				String subtourId = this.params.get(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID).toString();
				returnObject = ws.getSubtourByTourIdAndSubtourId(tourId, subtourId);
			} else if (methodId == IWebService.ID__GET_COUNTRIES) {
				returnObject = ws.getCountries();
			} else if (methodId == IWebService.ID__GET_PROVINCES) {
				returnObject = ws.getProvinces();
			} else if (methodId == IWebService.ID__GET_CITIES) {
				returnObject = ws.getCities();
			} else if (methodId == IWebService.ID__SAVE_TOUR) {
				TourObject tour = (TourObject) this.params.get(IWebService.PARAM__SAVE_TOUR__TOUR);
				List<SubtourItem> subtourItems = (List<SubtourItem>) this.params.get(IWebService.PARAM__SAVE_TOUR__SUBTOURS);
				List<SubtourItem> removedSubtourItems = (List<SubtourItem>) this.params.get(IWebService.PARAM__SAVE_TOUR__REMOVED_SUBTOURS);
				returnObject = ws.saveTour(tour, subtourItems, removedSubtourItems);
			} else if (methodId == IWebService.ID__UPLOAD_PICTURE) {
				PictureItem picture = (PictureItem) this.params.get(IWebService.PARAM__UPLOAD_PICTURE__PICTURESTRING);
				String base64code = this.params.get(IWebService.PARAM__UPLOAD_PICTURE__BASE64CODE).toString();
				returnObject = ws.uploadPicture(picture, base64code);
			} else if (methodId == IWebService.ID__INSERT_TOUR_COMMENT) {
				CommentItem comment = (CommentItem) this.params.get(IWebService.PARAM__INSERT_TOUR_COMMENT);
				returnObject = ws.insertTourComment(comment);
			} else if (methodId == IWebService.ID__GET_BLOG_BY_BLOGID) {
				String blogId = this.params.get(IWebService.PARAM__GET_BLOG_BY_BLOGID).toString();
				returnObject = ws.getBlogByBlogId(blogId);
			} else if (methodId == IWebService.ID__INSERT_BLOG) {
				BlogObject blog = (BlogObject) this.params.get(IWebService.PARAM__INSERT_BLOG);
				returnObject = ws.insertBlog(blog);
			}

			else {

			}

			if (returnObject != null) {
				Message message = handler.obtainMessage();
				message.what = methodId;
				Bundle bundle = new Bundle();
				bundle.putSerializable(IWebService.WS_RETURN, (Serializable) returnObject);
				message.setData(bundle);
				handler.sendMessage(message);
			} else {
				System.out.println("return result--->null");
			}
		} catch (Exception e) {
			Message message = handler.obtainMessage();
			Bundle bundle = new Bundle();
			message.what = IWebService.ID__ERROR;
			bundle.putString(IWebService.WS_RETURN, e.getMessage());
			message.setData(bundle);
			handler.sendMessage(message);
		}
	}
}
