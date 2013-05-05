package com.ss.stg.model;

import java.io.Serializable;
import java.util.Date;

/**
 * 用户收藏
 * 
 * @author ggxx
 * 
 */
public class Favorite implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 5171737099711624794L;
	private String userId;
	private String sightsId;
	private int visited;
	private int stars;
	private Date creatingTime;

	public Favorite() {
	}

	public String getUserId() {
		return userId;
	}

	public void setUserId(String userId) {
		this.userId = userId;
	}

	public String getSightsId() {
		return sightsId;
	}

	public void setSightsId(String sightsId) {
		this.sightsId = sightsId;
	}

	public int getVisited() {
		return visited;
	}

	public void setVisited(int visited) {
		this.visited = visited;
	}

	public int getStars() {
		return stars;
	}

	public void setStars(int stars) {
		this.stars = stars;
	}

	public Date getCreatingTime() {
		return creatingTime;
	}

	public void setCreatingTime(Date creatingTime) {
		this.creatingTime = creatingTime;
	}
}
