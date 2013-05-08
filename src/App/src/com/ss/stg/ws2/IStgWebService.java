package com.ss.stg.ws2;

import java.util.List;

import com.ss.stg.dto.SightItem;
import com.ss.stg.dto.SightObject;
import com.ss.stg.dto.UserObject;

public interface IStgWebService {

	UserObject Login(String loginName, String password);

	boolean Regist(UserObject user, String password);

	String HelloWorld();

	List<SightItem> GetSights();

	List<SightItem> GetSightsByUserId(String userId);

	SightObject GetSightBySightId(String sightId);

}
