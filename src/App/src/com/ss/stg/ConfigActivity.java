package com.ss.stg;

import android.app.Activity;
import android.app.FragmentManager;
import android.app.FragmentTransaction;
import android.os.Bundle;

public class ConfigActivity extends Activity {

	/** Called when the activity is first created. */
	@Override
	public void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);

		// �������ý�
		FragmentManager fragmentManager = getFragmentManager();
		FragmentTransaction trans = fragmentManager.beginTransaction();
		ConfigFragment configFragment = new ConfigFragment();
		trans.replace(android.R.id.content, configFragment);
		// trans.setTransition(FragmentTransaction.TRANSIT_FRAGMENT_FADE);
		// trans.addToBackStack(null);
		trans.commit();

	}
}
