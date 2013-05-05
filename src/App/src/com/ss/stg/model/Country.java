package com.ss.stg.model;

import java.io.Serializable;

/**
 * 国家
 * 
 * @author ggxx
 * 
 */
public class Country implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2292118794825725596L;
	private String countryId;
	private String countryName;

	public Country() {
	}

	public String getCountryId() {
		return countryId;
	}

	public void setCountryId(String countryId) {
		this.countryId = countryId;
	}

	public String getCountryName() {
		return countryName;
	}

	public void setCountryName(String countryName) {
		this.countryName = countryName;
	}
}
