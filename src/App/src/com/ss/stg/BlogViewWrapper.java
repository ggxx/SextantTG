package com.ss.stg;

import android.view.View;
import android.widget.TextView;

public class BlogViewWrapper {
	private View view;
	private String id;
	private TextView titleTextView;
	private TextView userTextView;
	private TextView timeTextView;

	public BlogViewWrapper(View view) {
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

	public TextView getUserTextView() {
		if (this.userTextView == null) {
			this.userTextView = (TextView) this.view.findViewById(R.id.blog_item_user);
		}
		return this.userTextView;
	}

	public TextView getTitleTextView() {
		if (this.titleTextView == null) {
			this.titleTextView = (TextView) this.view.findViewById(R.id.blog_item_title);
		}
		return this.titleTextView;
	}

	public TextView getTimeTextView() {
		if (this.timeTextView == null) {
			this.timeTextView = (TextView) this.view.findViewById(R.id.blog_item_time);
		}
		return this.timeTextView;
	}
}
