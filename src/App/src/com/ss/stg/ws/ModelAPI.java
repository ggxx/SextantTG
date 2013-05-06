package com.ss.stg.ws;

import java.text.DateFormat;
import java.text.MessageFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.ksoap2.serialization.SoapObject;

import android.util.Log;

import com.ss.stg.model.*;

public class ModelAPI {

	private static final DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
	private static final DateFormat datetimeFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

	private static Date toDate(String s) {
		try {
			return dateFormat.parse(s);
		} catch (ParseException ex) {
			return new Date(1900, 1, 1);
		}
	}

	private static Date toDateTime(String s) {
		try {
			return datetimeFormat.parse(s);
		} catch (ParseException ex) {
			return new Date(1900, 1, 1);
		}
	}

	private static int toInteger(String s) {
		try {
			return Integer.parseInt(s);
		} catch (Exception ex) {
			return 0;
		}
	}
	
	private static boolean toBoolean(String s){
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

	public static List<User> parseUsers(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		List<User> users = new ArrayList<User>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			User user = new User();
			user.setUserId(tmp.getPropertySafelyAsString("UserId"));
			user.setLoginName(tmp.getPropertySafelyAsString("LoginName"));
			user.setEmail(tmp.getPropertySafelyAsString("Email"));
			user.setStatus(toInteger(tmp.getPropertySafelyAsString("Status")));
			users.add(user);
		}
		return users;
	}

	public static User parseUser(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		User user = new User();
		user.setUserId(tmps.getPropertySafelyAsString("UserId"));
		user.setLoginName(tmps.getPropertySafelyAsString("LoginName"));
		user.setEmail(tmps.getPropertySafelyAsString("Email"));
		user.setStatus(toInteger(tmps.getPropertySafelyAsString("Status")));
		return user;
	}

	public static String convertToString(User user) {
		return MessageFormat.format("<Request><User><UserId>{0}</UserId><LoginName>{1}</LoginName><Email>{2}</Email><Status>{3}</Status></User></Request>", user.getUserId(), user.getLoginName(),
				user.getEmail(), user.getStatus());
	}

	public static List<Sights> parseSightsList(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		List<Sights> sightsList = new ArrayList<Sights>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			Sights sights = new Sights();
			sights.setCityId(tmp.getPropertySafelyAsString("CityId"));
			sights.setCreatingTime(toDateTime(tmp.getPropertySafelyAsString("CreatingTime")));
			sights.setDescription(tmp.getPropertySafelyAsString("Description"));
			sights.setMemos(tmp.getPropertySafelyAsString("Memos"));
			sights.setPrice(toInteger(tmp.getPropertySafelyAsString("Price")));
			sights.setSightsId(tmp.getPropertySafelyAsString("SightsId"));
			sights.setSightsLevel(tmp.getPropertySafelyAsString("SightsLevel"));
			sights.setSightsName(tmp.getPropertySafelyAsString("SightsName"));
			sightsList.add(sights);
		}
		return sightsList;
	}

	public static Sights parseSights(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		Sights sights = new Sights();
		sights.setCityId(tmps.getPropertySafelyAsString("CityId"));
		sights.setCreatingTime(toDateTime(tmps.getPropertySafelyAsString("CreatingTime")));
		sights.setDescription(tmps.getPropertySafelyAsString("Description"));
		sights.setMemos(tmps.getPropertySafelyAsString("Memos"));
		sights.setPrice(toInteger(tmps.getPropertySafelyAsString("Price")));
		sights.setSightsId(tmps.getPropertySafelyAsString("SightsId"));
		sights.setSightsLevel(tmps.getPropertySafelyAsString("SightsLevel"));
		sights.setSightsName(tmps.getPropertySafelyAsString("SightsName"));
		return sights;
	}

	public static List<Tour> parseTours(SoapObject obj) {
		SoapObject tmps = (SoapObject) obj.getProperty(0);
		List<Tour> tours = new ArrayList<Tour>();
		for (int i = 0; i < tmps.getPropertyCount(); i++) {
			SoapObject tmp = (SoapObject) tmps.getProperty(i);
			Tour tour = new Tour();
			tour.setBeginDate(toDateTime(tmp.getPropertySafelyAsString("BeginDate")));
			tour.setCost(toInteger(tmp.getPropertySafelyAsString("Cost")));
			tour.setCreatingTime(toDateTime(tmp.getPropertySafelyAsString("CreatingTime")));
			tour.setEndDate(toDateTime(tmp.getPropertySafelyAsString("EndDate")));
			tour.setMemos(tmp.getPropertySafelyAsString("Memos"));
			tour.setStatus(toInteger(tmp.getPropertySafelyAsString("Status")));
			tour.setTourId(tmp.getPropertySafelyAsString("TourId"));
			tour.setTourName(tmp.getPropertySafelyAsString("TourName"));
			tour.setUserId(tmp.getPropertySafelyAsString("UserId"));
			tours.add(tour);
		}
		return tours;
	}
}
