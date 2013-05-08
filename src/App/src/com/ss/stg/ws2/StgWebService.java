package com.ss.stg.ws2;

import java.util.List;

import com.ss.stg.dto.SightItem;
import com.ss.stg.dto.SightObject;
import com.ss.stg.dto.UserObject;

public class StgWebService implements IStgWebService {

	@Override
	public UserObject Login(String loginName, String password) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public boolean Regist(UserObject user, String password) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public String HelloWorld() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<SightItem> GetSights() {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public List<SightItem> GetSightsByUserId(String userId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public SightObject GetSightBySightId(String sightId) {
		// TODO Auto-generated method stub
		return null;
	}

}
