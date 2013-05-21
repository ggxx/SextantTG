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

import android.R.integer;
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

	private static Bitmap convertToBitMap(String url) {
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

	public static String convertToString(TourObject tour) {
		return MessageFormat
				.format("<Request><TourObject><TourId>{0}</TourId><TourName>{1}</TourName><Status>{2}</Status><BeginDate>{3}</BeginDate><EndDate>{4}</EndDate><Cost>{5}</Cost><UserId>{6}</UserId></TourObject></Request>",
						tour.getTourId(), tour.getTourName(), tour.getStatus(), tour.getBeginDate(), tour.getEndDate(), tour.getCost(), tour.getUserId());
	}

	public static String convertToString(List<SubtourItem> items) {
		StringBuilder sb = new StringBuilder("");
		for (SubtourItem item : items) {
			sb.append(MessageFormat
					.format("<SubtourItem><TourId>{0}</TourId><SubtourId>{1}</SubtourId><SubtourName>{2}</SubtourName><SightName>{3}</SightName><SightId>{4}</SightId><BeginDate>{5}</BeginDate><EndDate>{6}</EndDate></SubtourItem>",
							item.getTourId(), item.getSubtourId(), item.getSubtourName(), item.getSightName(), item.getSightId(), item.getBeginDate(), item.getEndDate()));
		}

		return MessageFormat.format("<Request><SubtourItemList>{0}</SubtourItemList></Request>", sb.toString());
	}

	public static String convertToString(CommentItem comment) {
		return MessageFormat.format("<Request><CommentItem><CommentId>{0}</CommentId><TargetId>{1}</TargetId><UserId>{2}</UserId><Comment>{3}</Comment></CommentItem></Request>",
				comment.getCommentId(), comment.getTargetId(), comment.getUserId(), comment.getComment());
	}

	public static String convertToString(BlogObject blog) {
		return MessageFormat
				.format("<Request><BlogObject><BlogId>{0}</BlogId><Anthor>{1}</Anthor><Title>{2}</Title><SightName>{3}</SightName><TourName>{4}</TourName><SubtourName>{5}</SubtourName><Content>{6}</Content><CreatingTime>{7}</CreatingTime><SightId>{8}</SightId><TourId>{9}</TourId><SubtourId>{10}</SubtourId><UserId>{11}</UserId></BlogObject></Request>",
						blog.getBlogId(), blog.getAnthor(), blog.getTitle(), blog.getSightName(), blog.getTourName(), blog.getSubtourName(), blog.getContent(), blog.getCreatingTime(),
						blog.getSightId(), blog.getTourId(), blog.getSubtourId(), blog.getUserId());
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
		item.setCityId(getString(tmp, "CityId"));
		item.setCityName(getString(tmp, "CityName"));
		item.setCountryId(getString(tmp, "CountryId"));
		item.setCountryName(getString(tmp, "CountryName"));
		item.setHasVisited(getBoolean(tmp, "HasVisited"));
		item.setProvinceId(getString(tmp, "ProvinceId"));
		item.setProvinceName(getString(tmp, "ProvinceName"));
		item.setSightId(getString(tmp, "SightId"));
		item.setSightLevel(getString(tmp, "SightLevel"));
		item.setSightName(getString(tmp, "SightName"));
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
		item.setUserId(getString(tmp, "UserId"));
		item.setBlogList(parseBlogItems(tmp));
		item.setCommentList(parseCommentItems(tmp));
		item.setPictureList(parsePictureItems(tmp));
		item.setSubtourList(parseSubtourItems(tmp));
		return item;
	}

	public static SubtourObject parseSubtourObject(SoapObject obj) {
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		SubtourObject item = new SubtourObject();
		item.setBeginDate(getDate(tmp, "BeginDate"));
		item.setEndDate(getDate(tmp, "EndDate"));
		item.setTourId(getString(tmp, "TourId"));
		item.setSightId(getString(tmp, "SightId"));
		item.setSightName(getString(tmp, "SightName"));
		item.setSubtourId(getString(tmp, "SubtourId"));
		item.setSubtourName(getString(tmp, "SubtourName"));
		item.setBlogList(parseBlogItems(tmp));
		item.setPictureList(parsePictureItems(tmp));
		return item;
	}

	public static BlogObject parseBlogObject(SoapObject obj) {
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		BlogObject item = new BlogObject();
		item.setBlogId(getString(tmp, "BlogId"));
		item.setAnthor(getString(tmp, "Anthor"));
		item.setTitle(getString(tmp, "Title"));
		item.setSightName(getString(tmp, "SightName"));
		item.setTourName(getString(tmp, "TourName"));
		item.setSubtourName(getString(tmp, "SubtourName"));
		item.setContent(getString(tmp, "Content"));
		item.setCreatingTime(getDateTime(tmp, "CreatingTime"));
		item.setSightId(getString(tmp, "SightId"));
		item.setTourId(getString(tmp, "TourId"));
		item.setSubtourId(getString(tmp, "SubtourId"));
		item.setUserId(getString(tmp, "UserId"));
		return item;
	}

	public static List<SightItem> parseSightItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("SightItemList");
		List<SightItem> sight = new ArrayList<SightItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			SightItem item = new SightItem();
			item.setCityId(getString(tmp, "CityId"));
			item.setCityName(getString(tmp, "CityName"));
			item.setCountryId(getString(tmp, "CountryId"));
			item.setCountryName(getString(tmp, "CountryName"));
			item.setHasVisited(getBoolean(tmp, "HasVisited"));
			item.setProvinceId(getString(tmp, "ProvinceId"));
			item.setProvinceName(getString(tmp, "ProvinceName"));
			item.setSightId(getString(tmp, "SightId"));
			item.setSightLevel(getString(tmp, "SightLevel"));
			item.setSightName(getString(tmp, "SightName"));
			item.setStars(getFloat(tmp, "Stars"));
			sight.add(item);
		}
		return sight;
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
			item.setSightName(getString(tmp, "SightName"));
			item.setSubtourName(getString(tmp, "SubtourName"));
			item.setTitle(getString(tmp, "Title"));
			item.setTourName(getString(tmp, "TourName"));
			item.setSightId(getString(tmp, "SightId"));
			item.setTourId(getString(tmp, "TourId"));
			item.setSubtourId(getString(tmp, "SubtourId"));
			item.setUserId(getString(tmp, "UserId"));
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
			item.setUserId(getString(tmp, "Userid"));
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
			item.setTourId(getString(tmp, "TourId"));
			item.setSubtourId(getString(tmp, "SubtourId"));
			item.setBitmap(convertToBitMap(item.getPath()));
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
			item.setSightId(getString(tmp, "SightId"));
			item.setSightName(getString(tmp, "SightName"));
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
			item.setUserId(getString(tmp, "UserId"));
			tourList.add(item);
		}
		return tourList;
	}

	public static List<CountryItem> parseCountryItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("CountryItemList");
		List<CountryItem> items = new ArrayList<CountryItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			CountryItem item = new CountryItem();
			item.setCountryId(getString(tmp, "CountryId"));
			item.setCountryName(getString(tmp, "CountryName"));
			items.add(item);
		}
		return items;
	}

	public static List<ProvinceItem> parseProvinceItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("ProvinceItemList");
		List<ProvinceItem> items = new ArrayList<ProvinceItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			ProvinceItem item = new ProvinceItem();
			item.setCountryId(getString(tmp, "CountryId"));
			item.setCountryName(getString(tmp, "CountryName"));
			item.setProvinceId(getString(tmp, "ProvinceId"));
			item.setProvinceName(getString(tmp, "ProvinceName"));
			items.add(item);
		}
		return items;
	}

	public static List<CityItem> parseCityItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty("CityItemList");
		List<CityItem> items = new ArrayList<CityItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			CityItem item = new CityItem();
			item.setCountryId(getString(tmp, "CountryId"));
			item.setCountryName(getString(tmp, "CountryName"));
			item.setProvinceId(getString(tmp, "ProvinceId"));
			item.setProvinceName(getString(tmp, "ProvinceName"));
			item.setCityId(getString(tmp, "CityId"));
			item.setCityName(getString(tmp, "CityName"));
			items.add(item);
		}
		return items;
	}

}
