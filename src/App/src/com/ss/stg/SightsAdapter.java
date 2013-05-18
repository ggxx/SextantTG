package com.ss.stg;

import java.util.List;

import android.content.Context;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.ss.stg.dto.SightItem;

public class SightsAdapter extends ArrayAdapter<SightItem> {

	private LayoutInflater layoutInflater = null;
	private SightsViewWrapper sightsViewWrapper = null;

	public SightsAdapter(Context context, List<SightItem> objects) {
		super(context, R.id.sight_item_name, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		SightItem sights = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_sights_item, parent, false);
			sightsViewWrapper = new SightsViewWrapper(convertView);
			convertView.setTag(sightsViewWrapper);
		} else {
			sightsViewWrapper = (SightsViewWrapper) convertView.getTag();
		}

		if (sights != null) {
			sightsViewWrapper.setId(sights.getSightId());
			sightsViewWrapper.getNameTextView().setText(sights.getSightName());
			sightsViewWrapper.getCityTextView().setText(sights.getCountryName() + "-" + sights.getProvinceName() + "-" + sights.getCityName());
			sightsViewWrapper.getStarsTextView().setText(String.valueOf(sights.getStars()));
			sightsViewWrapper.getVisitedImageView().setImageResource(sights.getHasVisited() ? R.drawable.tstar : R.drawable.fstar);
		}
		return convertView;
	}
}
