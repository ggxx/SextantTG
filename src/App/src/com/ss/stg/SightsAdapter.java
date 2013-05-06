package com.ss.stg;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.ss.stg.model.Sights;

public class SightsAdapter extends ArrayAdapter<Sights> {

	private LayoutInflater layoutInflater = null;
	private SightsViewWrapper sightsViewWrapper = null;

	public SightsAdapter(Context context, List<Sights> objects) {
		super(context, R.id.sights_item_name, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		Sights sights = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_sights_item, parent, false);
			sightsViewWrapper = new SightsViewWrapper(convertView);
			convertView.setTag(sightsViewWrapper);
		} else {
			sightsViewWrapper = (SightsViewWrapper) convertView.getTag();
		}

		if (sights != null) {
			sightsViewWrapper.getNameTextView().setText(sights.getSightsName());
			sightsViewWrapper.getDateTextView().setText(sights.getSightsId());
		}
		return convertView;
	}
}
