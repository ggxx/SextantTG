package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 子旅行
 * 
 * @author ggxx
 * 
 */
public class SubTour implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4411878684644222925L;
	private String tourId;
	private String subTourId;
	private String subTourName;
	private String sightsId;
	private Date beginDate;
	private Date endDate;
	private Date creatingTime;
	private String memos;

	public SubTour() {
	}

	public String getTourId() {
		return tourId;
	}

	public void setTourId(String tourId) {
		this.tourId = tourId;
	}

	public String getSubTourId() {
		return subTourId;
	}

	public void setSubTourId(String subTourId) {
		this.subTourId = subTourId;
	}

	public String getSubTourName() {
		return subTourName;
	}

	public void setSubTourName(String subTourName) {
		this.subTourName = subTourName;
	}

	public String getSightsId() {
		return sightsId;
	}

	public void setSightsId(String sightsId) {
		this.sightsId = sightsId;
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
