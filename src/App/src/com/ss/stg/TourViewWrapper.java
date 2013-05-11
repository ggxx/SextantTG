package com.ss.stg;

import com.ss.stg.R;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

public class TourViewWrapper {

	private View view;
	private String id;
	private ImageView statusImageView;
	private TextView nameTextView;
	private TextView dateTextView;

	public TourViewWrapper(View view) {
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

	public TextView getNameTextView() {
		if (this.nameTextView == null) {
			this.nameTextView = (TextView) this.view.findViewById(R.id.tour_item_name);
		}
		return this.nameTextView;
	}

	public TextView getDateTextView() {
		if (this.dateTextView == null) {
			this.dateTextView = (TextView) this.view.findViewById(R.id.tour_item_time);
		}
		return dateTextView;
	}

	public ImageView getStatusImageView() {
		if (this.statusImageView == null) {
			this.statusImageView = (ImageView) this.view.findViewById(R.id.tour_item_image);
		}
		return statusImageView;
	}
}
