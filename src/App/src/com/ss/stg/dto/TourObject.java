package com.ss.stg.dto;

import java.util.ArrayList;
import java.util.List;

public class TourObject extends TourItem {

	public TourObject(){
		this.subtourList = new ArrayList<SubtourItem>();
		this.pictureList = new ArrayList<PictureItem>();
		this.blogList = new ArrayList<BlogItem>();
		this.commentList = new ArrayList<CommentItem>();
	}
	
	private int cost;
	private List<SubtourItem> subtourList;
	private List<PictureItem> pictureList;
	private List<BlogItem> blogList;
	private List<CommentItem> commentList;

	public int getCost() {
		return cost;
	}

	public void setCost(int cost) {
		this.cost = cost;
	}

	public List<SubtourItem> getSubtourList() {
		return subtourList;
	}

	public void setSubtourList(List<SubtourItem> subtourList) {
		this.subtourList = subtourList;
	}

	public List<PictureItem> getPictureList() {
		return pictureList;
	}

	public void setPictureList(List<PictureItem> pictureList) {
		this.pictureList = pictureList;
	}

	public List<BlogItem> getBlogList() {
		return blogList;
	}

	public void setBlogList(List<BlogItem> blogList) {
		this.blogList = blogList;
	}

	public List<CommentItem> getCommentList() {
		return commentList;
	}

	public void setCommentList(List<CommentItem> commentList) {
		this.commentList = commentList;
	}
}
