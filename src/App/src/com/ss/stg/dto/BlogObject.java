package com.ss.stg.dto;

import java.util.ArrayList;
import java.util.List;

public class BlogObject extends BlogItem {

	public BlogObject() {
		this.setCommentList(new ArrayList<CommentItem>());
	}

	public List<CommentItem> getCommentList() {
		return commentList;
	}

	public void setCommentList(List<CommentItem> commentList) {
		this.commentList = commentList;
	}

	private List<CommentItem> commentList;

}
