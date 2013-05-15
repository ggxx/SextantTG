package com.ss.stg;

import java.util.Calendar;

import android.app.Activity;
import android.app.Dialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

public class SubtourEditDialogFragment extends DialogFragment {


	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
	}

	@Override
	public void onDetach() {
		super.onDetach();
	}

	public SubtourEditDialogFragment() {
		super();
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup view, Bundle savedInstanceState) {
		return inflater.inflate(R.layout.dialog_subtour_item, view);
	}

	@Override
	public Dialog onCreateDialog(Bundle savedInstanceState) {
		return super.onCreateDialog(savedInstanceState);
	}
}
