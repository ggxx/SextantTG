package com.ss.stg;

import android.view.View;
import android.widget.TextView;

public class SightsViewWrapper {

	private View view;
	private String id;
	private TextView nameTextView;
	private TextView dateTextView;

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

	public TextView getNameTextView() {
		if (this.nameTextView == null) {
			this.nameTextView = (TextView) this.view.findViewById(R.id.sights_item_name);
		}
		return this.nameTextView;
	}

	public TextView getDateTextView() {
		if (this.dateTextView == null) {
			this.dateTextView = (TextView) this.view.findViewById(R.id.sights_item_date);
		}
		return dateTextView;
	}
}
