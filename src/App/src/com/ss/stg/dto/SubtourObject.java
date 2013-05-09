package com.ss.stg.dto;

import java.util.ArrayList;
import java.util.List;

public class SubtourObject extends SubtourItem {

	public SubtourObject() {
		this.pictureList = new ArrayList<PictureItem>();
		this.blogList = new ArrayList<BlogItem>();
	}

	private List<PictureItem> pictureList;
	private List<BlogItem> blogList;

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
}
