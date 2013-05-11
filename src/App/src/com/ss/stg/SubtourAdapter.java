package com.ss.stg;

import java.util.List;

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

	public SubtourAdapter(Context context, List<SubtourItem> objects) {
		super(context, R.id.subtour_item_sight, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		SubtourItem item = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_subtour_item, parent, false);
			viewWrapper = new SubtourViewWrapper(convertView);
			convertView.setTag(viewWrapper);
		} else {
			viewWrapper = (SubtourViewWrapper) convertView.getTag();
		}

		if (item != null) {
			viewWrapper.setId(item.getSubtourId());
			viewWrapper.getSightTextView().setText(item.getSightsName());
			viewWrapper.getDateTextView().setText(DTOApi.dateFormat.format(item.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(item.getEndDate()));
		}
		return convertView;
	}
}
