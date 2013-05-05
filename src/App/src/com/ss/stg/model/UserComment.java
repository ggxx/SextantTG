package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 用户评论
 * 
 * @author ggxx
 * 
 */
public class UserComment implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -6567897828869070515L;
	private String commentId;
	private String commentUserId;
	private Date creatingTime;
	private String userId;
	private String comment;

	public UserComment() {
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

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}
}
