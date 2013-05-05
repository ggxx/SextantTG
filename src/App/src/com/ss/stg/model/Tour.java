package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 旅行
 * 
 * @author ggxx
 * 
 */
public class Tour implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7235312371778254249L;
	private String tourId;
	private String tourName;
	private String userId;
	private Date beginDate;
	private Date endDate;
	private int cost;
	private int status;
	private Date creatingTime;
	private String memos;

	public Tour() {
	}

	public String getTourId() {
		return tourId;
	}

	public void setTourId(String tourId) {
		this.tourId = tourId;
	}

	public String getTourName() {
		return tourName;
	}

	public void setTourName(String tourName) {
		this.tourName = tourName;
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

	public int getCost() {
		return cost;
	}

	public void setCost(int cost) {
		this.cost = cost;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
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
