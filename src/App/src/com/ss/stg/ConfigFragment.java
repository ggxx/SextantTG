package com.ss.stg;

import android.os.Bundle;
import android.preference.PreferenceFragment;

public class ConfigFragment extends PreferenceFragment {

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);

		getPreferenceManager().setSharedPreferencesName(AppConfig.CONFIG_NAME);
		addPreferencesFromResource(R.xml.appconfig);
	}
}
