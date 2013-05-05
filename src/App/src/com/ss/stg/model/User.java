package com.ss.stg.model;

import java.io.Serializable;

/**
 * 用户
 * 
 * @author ggxx
 * 
 */
public class User implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -2846832991551314139L;
	private String userId;
	private String loginName;
	private String email;
	private int status;

	public User() {
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getLoginName() {
		return loginName;
	}

	public void setLoginName(String loginName) {
		this.loginName = loginName;
	}

	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}
}
