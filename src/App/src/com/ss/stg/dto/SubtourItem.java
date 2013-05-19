package com.ss.stg.dto;

import java.util.Date;

/**
 * 子旅行
 * 
 * @author ggxx
 * 
 */
public class SubtourItem extends DTO {

	public SubtourItem() {
	}

	private String tourId;
	private String subtourId;
	private String subtourName;
	private String sightId;
	private String sightName;
	private Date beginDate;
	private Date endDate;

	public String getTourId() {
		return tourId;
	}

	public void setTourId(String tourId) {
		this.tourId = tourId;
	}

	public String getSubtourId() {
		return subtourId;
	}

	public void setSubtourId(String subtourId) {
		this.subtourId = subtourId;
	}

	public String getSubtourName() {
		return subtourName;
	}

	public void setSubtourName(String subtourName) {
		this.subtourName = subtourName;
	}

	public String getSightName() {
		return sightName;
	}

	public void setSightName(String sightName) {
		this.sightName = sightName;
	}

	public Date getBeginDate() {
		return beginDate;
	}

	public void setBeginDate(Date beginDate) {
		this.beginDate = beginDate;
	}

	public Date getEndDate() {
		return endDate;
	}

	public void setEndDate(Date endDate) {
		this.endDate = endDate;
	}

	public String getSightId() {
		return sightId;
	}

	public void setSightId(String sightId) {
		this.sightId = sightId;
	}
}
