package com.ss.stg;

import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

public class ImageViewWrapper {

	private View view;
	private String id;
	private TextView textView;
	private ImageView imageView;

	public ImageViewWrapper(View view) {
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

	public TextView getTextView() {
		if (this.textView == null) {
			this.textView = (TextView) this.view.findViewById(R.id.image_item_desc);
		}
		return this.textView;
	}

	public ImageView getImageView() {
		if (this.imageView == null) {
			this.imageView = (ImageView) this.view.findViewById(R.id.image_item_imageView);
		}
		return this.imageView;
	}
}
