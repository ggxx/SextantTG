package com.ss.stg.dto;

import java.util.Date;

public class BlogItem extends DTO {

	public BlogItem() {
	}

	private String blogId;
	private String anthor;
	private String title;
	private String sightName;
	private String tourName;
	private String subtourName;
	private String content;
	private Date creatingTime;
	private String userId;
	private String tourId;
	private String subtourId;
	private String sightId;

	public String getBlogId() {
		return blogId;
	}

	public void setBlogId(String blogId) {
		this.blogId = blogId;
	}

	public String getAnthor() {
		return anthor;
	}

	public void setAnthor(String anthor) {
		this.anthor = anthor;
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public String getSightName() {
		return sightName;
	}

	public void setSightName(String sightName) {
		this.sightName = sightName;
	}

	public String getTourName() {
		return tourName;
	}

	public void setTourName(String tourName) {
		this.tourName = tourName;
	}

	public String getSubtourName() {
		return subtourName;
	}

	public void setSubtourName(String subtourName) {
		this.subtourName = subtourName;
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

	public String getSightId() {
		return sightId;
	}

	public void setSightId(String sightId) {
		this.sightId = sightId;
	}

	public String getSubtourId() {
		return subtourId;
	}

	public void setSubtourId(String subtourId) {
		this.subtourId = subtourId;
	}

	public String getTourId() {
		return tourId;
	}

	public void setTourId(String tourId) {
		this.tourId = tourId;
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}
}
