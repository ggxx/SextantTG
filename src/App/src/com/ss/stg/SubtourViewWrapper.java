package com.ss.stg;

import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

public class SubtourViewWrapper {

	private View view;
	private String id;
	private ImageView imageView;
	private TextView sightTextView;
	private TextView dateTextView;
	private Button deleteButton;

	public SubtourViewWrapper(View view) {
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

	public TextView getSightTextView() {
		if (this.sightTextView == null) {
			this.sightTextView = (TextView) this.view.findViewById(R.id.subtour_item_sight);
		}
		return this.sightTextView;
	}

	public TextView getDateTextView() {
		if (this.dateTextView == null) {
			this.dateTextView = (TextView) this.view.findViewById(R.id.subtour_item_time);
		}
		return dateTextView;
	}

	public ImageView getImageView() {
		if (this.imageView == null) {
			this.imageView = (ImageView) this.view.findViewById(R.id.subtour_item_image);
		}
		return imageView;
	}

	public Button getDeleteButton() {
		if (this.deleteButton == null) {
			this.deleteButton = (Button) this.view.findViewById(R.id.subtour_item_delete);
		}
		return this.deleteButton;
	}
}
