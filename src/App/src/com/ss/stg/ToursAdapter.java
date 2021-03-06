package com.ss.stg;

import java.util.List;

import com.ss.stg.R;
import com.ss.stg.dto.TourItem;
import com.ss.stg.ws2.DTOApi;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

public class ToursAdapter extends ArrayAdapter<TourItem> {

	private LayoutInflater layoutInflater = null;
	private TourViewWrapper tourViewWrapper = null;

	public ToursAdapter(Context context, List<TourItem> objects) {
		super(context, R.id.tour_item_name, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		TourItem tour = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_tour_item, parent, false);
			tourViewWrapper = new TourViewWrapper(convertView);
			convertView.setTag(tourViewWrapper);
		} else {
			tourViewWrapper = (TourViewWrapper) convertView.getTag();
		}

		tourViewWrapper.setId(tour.getTourId());
		tourViewWrapper.getNameTextView().setText(tour.getTourName());
		tourViewWrapper.getStatusImageView().setImageResource(R.drawable.fstar);
		tourViewWrapper.getDateTextView().setText(DTOApi.dateFormat.format(tour.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(tour.getEndDate()));

		return convertView;
	}

}
