package com.ss.stg.ws2;

import java.io.IOException;
import java.io.InputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.text.DateFormat;
import java.text.MessageFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;

import org.ksoap2.serialization.SoapObject;

import android.R.string;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

import com.ss.stg.dto.*;

public class DTOApi {

	private static Calendar cal;
	static {
		cal = Calendar.getInstance();
		cal.set(Calendar.YEAR, 1900);
		cal.set(Calendar.MONTH, 1);
		cal.set(Calendar.DAY_OF_MONTH, 1);
	}

	public static final DateFormat dateFormat = new SimpleDateFormat("yyyy/M/d");
	public static final DateFormat datetimeFormat = new SimpleDateFormat("yyyy/M/d H:mm:ss");
	private static final Date defaultDate = cal.getTime();

	private static Bitmap returnBitMap(String url) {
		URL myFileUrl = null;
		Bitmap bitmap = null;
		try {
			myFileUrl = new URL(url);
		} catch (MalformedURLException e) {
			e.printStackTrace();
		}
		try {
			System.out.println("My Image Url is : " + url);
			HttpURLConnection conn = (HttpURLConnection) myFileUrl.openConnection();
			conn.setDoInput(true);
			conn.connect();
			InputStream is = conn.getInputStream();
			bitmap = BitmapFactory.decodeStream(is);
			is.close();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return bitmap;
	}

	private static String getString(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		if (s.equals("anyType{}")) {
			s = "";
		}
		return s;
	}

	private static Date getDate(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		try {
			return dateFormat.parse(s);
		} catch (ParseException ex) {

			return defaultDate;
		}
	}

	private static Date getDateTime(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		try {
			return datetimeFormat.parse(s);
		} catch (ParseException ex) {
			return defaultDate;
		}
	}

	private static boolean getBoolean(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		try {
			return Boolean.parseBoolean(s);
		} catch (Exception ex) {
			return false;
		}
	}

	private static int getInteger(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		try {
			return Integer.parseInt(s);
		} catch (Exception ex) {
			return 0;
		}
	}

	private static float getFloat(SoapObject obj, String property) {
		String s = obj.getPropertySafelyAsString(property);
		try {
			return Float.parseFloat(s);
		} catch (Exception ex) {
			return 0;
		}
	}

	public static String parseString(SoapObject obj) {
		return getString(obj, "Value");
	}

	public static boolean parseBoolean(SoapObject obj) {
		return getBoolean(obj, "Value");
	}

	public static String convertToString(UserObject user) {
		return MessageFormat.format("<Request><UserObject><UserId>{0}</UserId><LoginName>{1}</LoginName><Email>{2}</Email><Status>{3}</Status></UserObject></Request>", user.getUserId(),
				user.getLoginName(), user.getEmail(), user.getStatus());
	}

	public static UserObject parseUserObject(SoapObject obj) {
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		UserObject user = new UserObject();
		user.setUserId(getString(tmp, "UserId"));
		user.setLoginName(getString(tmp, "LoginName"));
		user.setEmail(getString(tmp, "Email"));
		user.setStatus(getInteger(tmp, "Status"));
		return user;
	}

	public static SightObject parseSightObject(SoapObject obj) {
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		SightObject item = new SightObject();
		item.setCityName(getString(tmp, "CityName"));
		item.setCountryName(getString(tmp, "CountryName"));
		item.setHasVisited(getBoolean(tmp, "HasVisited"));
		item.setProvinceName(getString(tmp, "ProvinceName"));
		item.setSightsId(getString(tmp, "SightsId"));
		item.setSightsLevel(getString(tmp, "SightsLevel"));
		item.setSightName(getString(tmp, "SightsName"));
		item.setStars(getFloat(tmp, "Stars"));
		item.setDescription(getString(tmp, "Description"));
		item.setMyStar(getInteger(tmp, "MyStar"));
		item.setPrice(getInteger(tmp, "Price"));
		item.setBlogList(parseBlogItems(tmp));
		item.setCommentList(parseCommentItems(tmp));
		item.setPictureList(parsePictureItems(tmp));
		return item;
	}

	public static TourObject parseTourObject(SoapObject obj) {
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		TourObject item = new TourObject();
		item.setBeginDate(getDate(tmp, "BeginDate"));
		item.setCost(getInteger(tmp, "Cost"));
		item.setEndDate(getDate(tmp, "EndDate"));
		item.setStatus(getString(tmp, "Status"));
		item.setTourId(getString(tmp, "TourId"));
		item.setTourName(getString(tmp, "TourName"));
		item.setStatus(getString(tmp, "Status"));
		item.setBlogList(parseBlogItems(tmp));
		item.setCommentList(parseCommentItems(tmp));
		item.setPictureList(parsePictureItems(tmp));
		item.setSubtourList(parseSubtourItems(tmp));
		return item;
	}

	public static List<SightItem> parseSightItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("SightsItemList");
		List<SightItem> sights = new ArrayList<SightItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			SightItem item = new SightItem();
			item.setCityName(getString(tmp, "CityName"));
			item.setCountryName(getString(tmp, "CountryName"));
			item.setHasVisited(getBoolean(tmp, "HasVisited"));
			item.setProvinceName(getString(tmp, "ProvinceName"));
			item.setSightsId(getString(tmp, "SightsId"));
			item.setSightsLevel(getString(tmp, "SightsLevel"));
			item.setSightName(getString(tmp, "SightsName"));
			item.setStars(getFloat(tmp, "Stars"));
			sights.add(item);
		}
		return sights;
	}

	public static List<BlogItem> parseBlogItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("BlogItemList");
		List<BlogItem> blogList = new ArrayList<BlogItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			BlogItem item = new BlogItem();
			item.setAnthor(getString(tmp, "Author"));
			item.setBlogId(getString(tmp, "BlogId"));
			item.setContent(getString(tmp, "Content"));
			item.setCreatingTime(getDateTime(tmp, "CreatingTime"));
			item.setSightName(getString(tmp, "SightsName"));
			item.setSubtourName(getString(tmp, "SubtourName"));
			item.setTitle(getString(tmp, "Title"));
			item.setTourName(getString(tmp, "TourName"));
			blogList.add(item);
		}
		return blogList;
	}

	private static List<CommentItem> parseCommentItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("CommentItemList");
		List<CommentItem> commentList = new ArrayList<CommentItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			CommentItem item = new CommentItem();
			item.setComment(getString(tmp, "Comment"));
			item.setCommentId(getString(tmp, "CommentId"));
			item.setCommentUserName(getString(tmp, "CommentUserName"));
			item.setCreatingTime(getDateTime(tmp, "CreatingTime"));
			item.setTargetId(getString(tmp, "TargetId"));
			commentList.add(item);
		}
		return commentList;
	}

	private static List<PictureItem> parsePictureItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("PictureItemList");
		List<PictureItem> pictureList = new ArrayList<PictureItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			PictureItem item = new PictureItem();
			item.setCreatingTime(getDateTime(tmp, "CreatingTime"));
			item.setDescription(getString(tmp, "Description"));
			item.setPath(getString(tmp, "Path"));
			item.setPictureId(getString(tmp, "PictureId"));
			item.setUploaderName(getString(tmp, "UploaderName"));
			item.setBitmap(returnBitMap(item.getPath()));
			pictureList.add(item);
		}
		return pictureList;
	}

	private static List<SubtourItem> parseSubtourItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("SubtourItemList");
		List<SubtourItem> list = new ArrayList<SubtourItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			SubtourItem item = new SubtourItem();
			item.setBeginDate(getDate(tmp, "BeginDate"));
			item.setEndDate(getDate(tmp, "EndDate"));
			item.setTourId(getString(tmp, "TourId"));
			item.setSightsName(getString(tmp, "SightsName"));
			item.setSubtourId(getString(tmp, "SubtourId"));
			item.setSubtourName(getString(tmp, "SubtourName"));
			list.add(item);
		}

		System.out.println("convert to subtour items' num is " + list.size());
		return list;
	}

	public static List<TourItem> parseTourItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("TourItemList");
		List<TourItem> tourList = new ArrayList<TourItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			TourItem item = new TourItem();
			item.setBeginDate(getDate(tmp, "BeginDate"));
			item.setEndDate(getDate(tmp, "EndDate"));
			item.setStatus(getString(tmp, "Status"));
			item.setTourId(getString(tmp, "TourId"));
			item.setTourName(getString(tmp, "TourName"));
			tourList.add(item);
		}
		return tourList;
	}

}
