package com.ss.stg;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;

public class LogoutFragment extends Fragment {

	private Handler handler = null;
	private OnLogoutFragmentInteractionListener mListener;

	private Button logoutButton = null;

	public LogoutFragment() {
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		if (getArguments() != null) {

		}
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

		View view = inflater.inflate(R.layout.fragment_logout, container, false);

		logoutButton = (Button) view.findViewById(R.id.fl_logout_button);
		logoutButton.setOnClickListener(new LoginButton_Listener(getActivity()));

		return view;
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnLogoutFragmentInteractionListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString() + " must implement OnLoginFragmentInteractionListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	public interface OnLogoutFragmentInteractionListener {
		public void onLogoutFragmentInteraction();
	}

	private class LoginButton_Listener implements OnClickListener {

		private Activity activity;

		public LoginButton_Listener(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void onClick(View v) {
			if (mListener != null) {
				mListener.onLogoutFragmentInteraction();
			}
		}
	}
}
