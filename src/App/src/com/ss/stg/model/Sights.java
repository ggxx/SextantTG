package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

public class Sights implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2992240368343680967L;
	private String sightsId;
	private String sightsName;
	private String cityId;
	private String sightsLevel;
	private String description;
	private int price;
	private Date creatingTime;
	private String memos;
	
	//private float stars;
	//private String cityName;
	//private String countryName;

	public Sights() {
	}

	public String getSightsId() {
		return sightsId;
	}

	public void setSightsId(String sightsId) {
		this.sightsId = sightsId;
	}

	public String getSightsName() {
		return sightsName;
	}

	public void setSightsName(String sightsName) {
		this.sightsName = sightsName;
	}

	public String getCityId() {
		return cityId;
	}

	public void setCityId(String cityId) {
		this.cityId = cityId;
	}

	public String getSightsLevel() {
		return sightsLevel;
	}

	public void setSightsLevel(String sightsLevel) {
		this.sightsLevel = sightsLevel;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getPrice() {
		return price;
	}

	public void setPrice(int price) {
		this.price = price;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}

	public String getMemos() {
		return memos;
	}

	public void setMemos(String memos) {
		this.memos = memos;
	}
}
