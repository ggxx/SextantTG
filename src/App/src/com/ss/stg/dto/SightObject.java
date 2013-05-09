package com.ss.stg.dto;

import java.util.ArrayList;
import java.util.List;

public class SightObject extends SightItem {

	public SightObject() {
		this.setPictureList(new ArrayList<PictureItem>());
		this.setCommentList(new ArrayList<CommentItem>());
		this.setBlogList(new ArrayList<BlogItem>());
	}

	private int myStar;
	private String description;
	private int price;
	private List<PictureItem> pictureList;
	private List<CommentItem> commentList;
	private List<BlogItem> blogList;

	public int getMyStar() {
		return myStar;
	}

	public void setMyStar(int myStar) {
		this.myStar = myStar;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getPrice() {
		return price;
	}

	public void setPrice(int price) {
		this.price = price;
	}

	public List<PictureItem> getPictureList() {
		return pictureList;
	}

	public void setPictureList(List<PictureItem> pictureList) {
		this.pictureList = pictureList;
	}

	public List<CommentItem> getCommentList() {
		return commentList;
	}

	public void setCommentList(List<CommentItem> commentList) {
		this.commentList = commentList;
	}

	public List<BlogItem> getBlogList() {
		return blogList;
	}

	public void setBlogList(List<BlogItem> blogList) {
		this.blogList = blogList;
	}

}
