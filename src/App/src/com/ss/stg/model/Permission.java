package com.ss.stg.model;

import java.io.Serializable;

/**
 * 用户权限
 * 
 * @author ggxx
 * 
 */
public class Permission implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4827743876988782972L;
	private String userId;
	private int permissionType;

	public Permission() {
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public int getPermissionType() {
		return permissionType;
	}

	public void setPermissionType(int permissionType) {
		this.permissionType = permissionType;
	}
}
