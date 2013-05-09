package com.ss.stg.dto;

import java.util.ArrayList;
import java.util.List;

public class PictureObject extends PictureItem {

	public PictureObject(){
		this.commentList = new ArrayList<CommentItem>();
	}
	
	private String sightsName;

	private String tourName;

	private String subTourName;

	private List<CommentItem> commentList;

	public String getSightsName() {
		return sightsName;
	}

	public void setSightsName(String sightsName) {
		this.sightsName = sightsName;
	}

	public String getTourName() {
		return tourName;
	}

	public void setTourName(String tourName) {
		this.tourName = tourName;
	}

	public String getSubTourName() {
		return subTourName;
	}

	public void setSubTourName(String subTourName) {
		this.subTourName = subTourName;
	}

	public List<CommentItem> getCommentList() {
		return commentList;
	}

	public void setCommentList(List<CommentItem> commentList) {
		this.commentList = commentList;
	}

}
