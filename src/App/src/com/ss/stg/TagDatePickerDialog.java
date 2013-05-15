package com.ss.stg;

import android.app.DatePickerDialog;
import android.content.Context;

public class TagDatePickerDialog extends DatePickerDialog {

	public TagDatePickerDialog(Context context, OnDateSetListener callBack, int year, int monthOfYear, int dayOfMonth, Object tag) {
		super(context, callBack, year, monthOfYear, dayOfMonth);
		this.getDatePicker().setTag(tag);
	}

}
