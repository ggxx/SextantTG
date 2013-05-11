package com.ss.stg.dto;

import java.util.Date;

import android.graphics.Bitmap;

public class PictureItem extends DTO {

	public PictureItem() {
	}

	private String pictureId;
	private String path;
	private String description;
	private String uploaderName;
	private Date creatingTime;
	private Bitmap bitmap;

	public String getPictureId() {
		return pictureId;
	}

	public void setPictureId(String pictureId) {
		this.pictureId = pictureId;
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

	public String getUploaderName() {
		return uploaderName;
	}

	public void setUploaderName(String uploaderName) {
		this.uploaderName = uploaderName;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}

	public Bitmap getBitmap() {
		return bitmap;
	}

	public void setBitmap(Bitmap bitmap) {
		this.bitmap = bitmap;
	}
}
