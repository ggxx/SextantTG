package com.ss.stg.ws2;

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

import com.ss.stg.dto.*;

public class DTOApi {

	private static Calendar cal;
	static {
		cal = Calendar.getInstance();
		cal.set(Calendar.YEAR, 1900);
		cal.set(Calendar.MONTH, 1);
		cal.set(Calendar.DAY_OF_MONTH, 1);
	}

	private static final DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
	private static final DateFormat datetimeFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
	private static final Date defaultDate = cal.getTime();

	private static Date toDate(String s) {
		try {
			return dateFormat.parse(s);
		} catch (ParseException ex) {

			return defaultDate;
		}
	}

	private static Date toDateTime(String s) {
		try {
			return datetimeFormat.parse(s);
		} catch (ParseException ex) {
			return defaultDate;
		}
	}

	private static int toInteger(String s) {
		try {
			return Integer.parseInt(s);
		} catch (Exception ex) {
			return 0;
		}
	}

	private static boolean toBoolean(String s) {
		try {
			return Boolean.parseBoolean(s);
		} catch (Exception ex) {
			return false;
		}
	}

	public static String parseString(SoapObject obj) {
		return obj.getPropertySafelyAsString("Value");
	}

	public static boolean parseBoolean(SoapObject obj) {
		return toBoolean(obj.getPropertySafelyAsString("Value"));
	}

	public static List<BlogItem> parseBlogItems(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		List<BlogItem> sightsList = new ArrayList<BlogItem>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			BlogItem item = new BlogItem();
			item.setAnthor(tmp.getPropertySafelyAsString("Author"));
			item.setBlogId(tmp.getPropertySafelyAsString("BlogId"));
			item.setContent(tmp.getPropertySafelyAsString("Content"));
			item.setCreatingTime(toDateTime(tmp.getPropertySafelyAsString("CreatingTime")));
			item.setSightName(tmp.getPropertySafelyAsString("SightName"));
			item.setSubtourName(tmp.getPropertySafelyAsString("SubtourName"));
			item.setTitle(tmp.getPropertySafelyAsString("Title"));
			item.setTourName(tmp.getPropertySafelyAsString("TourName"));
			sightsList.add(item);
		}
		return sightsList;
	}

	public static String convertToString(UserObject user) {
		return MessageFormat.format("<Request><User><UserId>{0}</UserId><LoginName>{1}</LoginName><Email>{2}</Email><Status>{3}</Status></User></Request>", user.getUserId(), user.getLoginName(), user.getEmail(), user.getStatus());
	}
	
	public static UserObject parseUserObject(SoapObject obj){
		SoapObject tmp = (SoapObject) obj.getProperty(0);
		UserObject user = new UserObject();
		user.setUserId(tmp.getPropertySafelyAsString("UserId"));
		user.setLoginName(tmp.getPropertySafelyAsString("LoginName"));
		user.setEmail(tmp.getPropertySafelyAsString("Email"));
		user.setStatus(toInteger(tmp.getPropertySafelyAsString("Status")));
		return user;
	}

}
