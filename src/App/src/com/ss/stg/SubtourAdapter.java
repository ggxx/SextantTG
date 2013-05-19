package com.ss.stg;

import java.util.ArrayList;
import java.util.List;

import android.R.integer;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.ss.stg.dto.SubtourItem;
import com.ss.stg.ws2.DTOApi;

public class SubtourAdapter extends ArrayAdapter<SubtourItem> {

	private LayoutInflater layoutInflater = null;
	private SubtourViewWrapper viewWrapper = null;
	private int viewType = 1;
	private List<SubtourItem> removedList = null;
	private List<SubtourItem> list = null;

	public static final int READONLY = 1;
	public static final int EDITABLE = 2;

	public List<SubtourItem> getRemovedList() {
		return this.removedList;
	}

	public List<SubtourItem> getList() {
		List<SubtourItem> list = new ArrayList<SubtourItem>();
		for (int i = 0; i < this.getCount(); i++) {
			list.add(this.getItem(i));
		}
		return list;
	}

	public SubtourAdapter(Context context, int viewType, List<SubtourItem> objects) {
		super(context, R.id.subtour_item_sight, objects);
		this.layoutInflater = LayoutInflater.from(context);
		this.viewType = viewType;
		this.removedList = new ArrayList<SubtourItem>();
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		final int pos = position;
		SubtourItem item = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_subtour_item, parent, false);
			viewWrapper = new SubtourViewWrapper(convertView);
			convertView.setTag(viewWrapper);
		} else {
			viewWrapper = (SubtourViewWrapper) convertView.getTag();
		}

		if (item != null) {

			if (this.viewType == EDITABLE) {
				viewWrapper.getDeleteButton().setVisibility(View.VISIBLE);
				viewWrapper.getDeleteButton().setOnClickListener(new View.OnClickListener() {

					@Override
					public void onClick(View v) {
						SubtourItem item2 = getItem(pos);
						SubtourAdapter.this.removedList.add(item2);
						SubtourAdapter.this.remove(item2);
					}
				});

				viewWrapper.getEditButton().setVisibility(View.VISIBLE);
				viewWrapper.getEditButton().setOnClickListener(new View.OnClickListener() {

					@Override
					public void onClick(View v) {
						Intent intent = new Intent(getContext(), SubtourEditActivity.class);
						intent.putExtra("pos", pos);
						intent.putExtra("subtour", getItem(pos));
						((Activity) getContext()).startActivityForResult(intent, TourEditActivity.REQ_EDIT_SUBTOUR);
					}
				});
			} else {
				viewWrapper.getDeleteButton().setVisibility(View.GONE);
				viewWrapper.getEditButton().setVisibility(View.GONE);
			}

			viewWrapper.setId(item.getSubtourId());
			viewWrapper.getSightTextView().setText(item.getSightName());
			viewWrapper.getDateTextView().setText(DTOApi.dateFormat.format(item.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(item.getEndDate()));
		}
		return convertView;
	}
}
