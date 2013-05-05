package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 日志
 * 
 * @author ggxx
 * 
 */
public class Blog implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4204555102247271619L;
	private String blogId;
	private String userId;
	private String sightsId;
	private String tourId;
	private String subTourId;
	private String title;
	private String content;
	private Date creatingTime;

	public Blog() {
	}

	public String getBlogId() {
		return blogId;
	}

	public void setBlogId(String blogId) {
		this.blogId = blogId;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getSightsId() {
		return sightsId;
	}

	public void setSightsId(String sightsId) {
		this.sightsId = sightsId;
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

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}
}
