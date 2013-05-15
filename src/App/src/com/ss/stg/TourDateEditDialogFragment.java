package com.ss.stg;

import java.util.Calendar;

import android.app.Activity;
import android.app.DatePickerDialog.OnDateSetListener;
import android.app.Dialog;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;

public class TourDateEditDialogFragment extends DialogFragment {

	private OnDateSetListener mListener;

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnDateSetListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString() + " must implement OnDateSetListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	public TourDateEditDialogFragment() {
		super();
	}

	@Override
	public Dialog onCreateDialog(Bundle savedInstanceState) {
		Calendar c = Calendar.getInstance();
		int year = c.get(Calendar.YEAR);
		int cmonth = c.get(Calendar.MONTH);
		int cday = c.get(Calendar.DAY_OF_MONTH);
		if (getArguments() != null) {
			year = getArguments().getInt("Year", c.get(Calendar.YEAR));
			cmonth = getArguments().getInt("Month", c.get(Calendar.MONTH));
			cday = getArguments().getInt("Day", c.get(Calendar.DAY_OF_MONTH));
		}
		return new TagDatePickerDialog(getActivity(), mListener, year, cmonth, cday, this.getTag());// getArguments().getString("tag"));
	}
}
