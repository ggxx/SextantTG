package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 图片
 * 
 * @author ggxx
 * 
 */
public class Picture implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 275584327188000781L;
	private String pictureId;
	private String sightsId;
	private String tourId;
	private String subTourId;
	private String path;
	private String description;
	private String uploaderId;
	private Date creatingTime;

	public Picture() {
	}

	public String getPictureId() {
		return pictureId;
	}

	public void setPictureId(String pictureId) {
		this.pictureId = pictureId;
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

	public String getPath() {
		return path;
	}

	public void setPath(String path) {
		this.path = path;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public String getUploaderId() {
		return uploaderId;
	}

	public void setUploaderId(String uploaderId) {
		this.uploaderId = uploaderId;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}
}
