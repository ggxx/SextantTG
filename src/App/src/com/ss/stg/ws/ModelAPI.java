package com.ss.stg.ws;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.List;

import org.ksoap2.serialization.SoapObject;

import com.ss.stg.model.*;

public class ModelAPI {

	public static String parseString(SoapObject obj) {
		return obj.getPropertySafelyAsString("Value");
	}

	public static boolean parseBoolean(SoapObject obj) {
		return Boolean.parseBoolean(obj.getPropertySafelyAsString("Value"));
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
			user.setStatus(Integer.valueOf(tmp.getPropertySafelyAsString("Status")));
			users.add(user);
		}
		return users;
	}

	public static User parseUser(SoapObject obj) {
		User user = new User();
		user.setUserId(obj.getPropertySafelyAsString("UserId"));
		user.setLoginName(obj.getPropertySafelyAsString("LoginName"));
		user.setEmail(obj.getPropertySafelyAsString("Email"));
		user.setStatus(Integer.valueOf(obj.getPropertySafelyAsString("Status")));
		return user;
	}

	public static String convertToString(User user) {
		return MessageFormat.format("<Request><User><UserId>{0}</UserId><LoginName>{1}</LoginName><Email>{2}</Email><Status>{3}</Status></User></Request>", 
				user.getUserId(), user.getLoginName(), user.getEmail(), user.getStatus());
	}
}
