package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 图片评论
 * 
 * @author ggxx
 * 
 */
public class PictureComment implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -1673424426235035335L;
	private String commentId;
	private String commentUserId;
	private Date creatingTime;
	private String pictureId;
	private String comment;

	public PictureComment() {
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

	public String getPictureId() {
		return pictureId;
	}

	public void setPictureId(String pictureId) {
		this.pictureId = pictureId;
	}

	public String getComment() {
		return comment;
	}

	public void setComment(String comment) {
		this.comment = comment;
	}

}
