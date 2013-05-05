package com.ss.stg.model;

import java.io.Serializable;

/**
 * 城市
 * 
 * @author ggxx
 * 
 */
public class City implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3711249912923394253L;
	private String cityId;
	private String cityName;
	private String provinceId;

	public City() {
	}

	public String getCityId() {
		return cityId;
	}

	public void setCityId(String cityId) {
		this.cityId = cityId;
	}

	public String getCityName() {
		return cityName;
	}

	public void setCityName(String cityName) {
		this.cityName = cityName;
	}

	public String getProvinceId() {
		return provinceId;
	}

	public void setProvinceId(String provinceId) {
		this.provinceId = provinceId;
	}
}
