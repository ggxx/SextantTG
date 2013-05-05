package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 景点评论
 * 
 * @author ggxx
 * 
 */
public class SightsComment implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 6731491559805816115L;
	private String commentId;
	private String commentUserId;
	private Date creatingTime;
	private String sightsId;
	private String comment;

	public SightsComment() {
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

	public String getSightsId() {
		return sightsId;
	}

	public void setSightsId(String sightsId) {
		this.sightsId = sightsId;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}
}
