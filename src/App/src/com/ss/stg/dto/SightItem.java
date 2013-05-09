package com.ss.stg.dto;

public class SightItem extends DTO {

	public SightItem() {
	}

	private String sightsId;
	private String sightsName;
	private String cityName;
	private String provinceName;
	private String countryName;
	private String sightsLevel;
	private boolean hasVisited;
	private float stars;

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

	public String getCityName() {
		return cityName;
	}

	public void setCityName(String cityName) {
		this.cityName = cityName;
	}

	public String getProvinceName() {
		return provinceName;
	}

	public void setProvinceName(String provinceName) {
		this.provinceName = provinceName;
	}

	public String getCountryName() {
		return countryName;
	}

	public void setCountryName(String countryName) {
		this.countryName = countryName;
	}

	public String getSightsLevel() {
		return sightsLevel;
	}

	public void setSightsLevel(String sightsLevel) {
		this.sightsLevel = sightsLevel;
	}

	public boolean isHasVisited() {
		return hasVisited;
	}

	public void setHasVisited(boolean hasVisited) {
		this.hasVisited = hasVisited;
	}

	public float getStars() {
		return stars;
	}

	public void setStars(float stars) {
		this.stars = stars;
	}

}
