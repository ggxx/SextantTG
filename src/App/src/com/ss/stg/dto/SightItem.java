package com.ss.stg.dto;

public class SightItem extends DTO {

	public SightItem() {
	}

	private String sightId;
	private String sightName;
	private String cityName;
	private String provinceName;
	private String countryName;
	private String sightLevel;
	private boolean hasVisited;
	private float stars;

	public String getSightId() {
		return sightId;
	}

	public void setSightId(String sightId) {
		this.sightId = sightId;
	}

	public String getSightName() {
		return sightName;
	}

	public void setSightName(String sightName) {
		this.sightName = sightName;
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

	public String getSightLevel() {
		return sightLevel;
	}

	public void setSightLevel(String sightLevel) {
		this.sightLevel = sightLevel;
	}

	public boolean getHasVisited() {
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
