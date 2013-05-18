package com.ss.stg;

import java.util.ArrayList;
import java.util.List;

import android.R.integer;
import android.content.Context;
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

	public static final int READONLY = 1;
	public static final int EDITABLE = 2;

	public List<SubtourItem> getRemovedList() {
		return this.removedList;
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
						// TODO Auto-generated method stub
						SubtourItem item2 = getItem(pos);
						SubtourAdapter.this.removedList.add(item2);
						SubtourAdapter.this.remove(item2);
					}
				});

				viewWrapper.getEditButton().setVisibility(View.VISIBLE);
				viewWrapper.getEditButton().setOnClickListener(new View.OnClickListener() {

					@Override
					public void onClick(View v) {
						// TODO Auto-generated method stub
						// SubtourEditDialogFragment fragment = new
						// SubtourEditDialogFragment();
						// fragment.show( manager, tag)
					}
				});
			} else {
				viewWrapper.getDeleteButton().setVisibility(View.GONE);
				viewWrapper.getEditButton().setVisibility(View.GONE);
			}

			viewWrapper.setId(item.getSubtourId());
			viewWrapper.getSightTextView().setText(item.getSightsName());
			viewWrapper.getDateTextView().setText(DTOApi.dateFormat.format(item.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(item.getEndDate()));
		}
		return convertView;
	}
}
