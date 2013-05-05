package com.ss.stg.model;

import java.io.Serializable;

/**
 * 省份
 * 
 * @author ggxx
 * 
 */
public class Province implements Serializable  {

	/**
	 * 
	 */
	private static final long serialVersionUID = 5425043799426724187L;
	private String provinceId;
	private String provinceName;
	private String countryId;

	public Province() {
	}

	public String getProvinceId() {
		return provinceId;
	}

	public void setProvinceId(String provinceId) {
		this.provinceId = provinceId;
	}

	public String getProvinceName() {
		return provinceName;
	}

	public void setProvinceName(String provinceName) {
		this.provinceName = provinceName;
	}

	public String getCountryId() {
		return countryId;
	}

	public void setCountryId(String countryId) {
		this.countryId = countryId;
	}

}
