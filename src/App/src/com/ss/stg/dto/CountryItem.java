package com.ss.stg.dto;

public class CountryItem extends DTO {
	private String countryId;
	private String countryName;

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
	
	@Override
	public String toString(){
		return this.countryName;
	}
}
