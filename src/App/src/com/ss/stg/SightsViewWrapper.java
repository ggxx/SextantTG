package com.ss.stg;

import android.view.View;
import android.widget.CheckBox;
import android.widget.ImageView;
import android.widget.TextView;

public class SightsViewWrapper {

	private View view;
	private String id;
	private ImageView visitedImageView;
	private TextView nameTextView;
	private TextView cityTextView;
	private TextView starsTextView;

	public SightsViewWrapper(View view) {
		this.view = view;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public View getView() {
		return view;
	}

	public ImageView getVisitedImageView() {
		if (this.visitedImageView == null) {
			this.visitedImageView = (ImageView) this.view.findViewById(R.id.sight_item_image);
		}
		return this.visitedImageView;
	}

	public TextView getNameTextView() {
		if (this.nameTextView == null) {
			this.nameTextView = (TextView) this.view.findViewById(R.id.sight_item_name);
		}
		return this.nameTextView;
	}

	public TextView getCityTextView() {
		if (this.cityTextView == null) {
			this.cityTextView = (TextView) this.view.findViewById(R.id.sight_item_city);
		}
		return cityTextView;
	}

	public TextView getStarsTextView() {
		if (this.starsTextView == null) {
			this.starsTextView = (TextView) this.view.findViewById(R.id.sight_item_stars);
		}
		return starsTextView;
	}
}
