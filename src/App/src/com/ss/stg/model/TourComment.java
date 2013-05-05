package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 旅行评论
 * 
 * @author ggxx
 * 
 */
public class TourComment implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8757779128456235304L;
	private String commentId;
	private String commentUserId;
	private Date creatingTime;
	private String tourId;
	private String comment;

	public TourComment() {
	}

	public String getCommentId() {
		return commentId;
	}

	public void setCommentId(String commentId) {
		this.commentId = commentId;
	}

	public String getCommentUserId() {
		return commentUserId;
	}

	public void setCommentUserId(String commentUserId) {
		this.commentUserId = commentUserId;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}

	public String getTourId() {
		return tourId;
	}

	public void setTourId(String tourId) {
		this.tourId = tourId;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}
}
