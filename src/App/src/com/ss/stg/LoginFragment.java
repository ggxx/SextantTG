package com.ss.stg;

import java.util.HashMap;

import com.ss.stg.dto.UserObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.support.v4.app.Fragment;
import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;

public class LoginFragment extends Fragment {

	private Handler handler = null;
	private OnLoginFragmentInteractionListener mListener;

	private Button loginButton = null;
	private EditText nameEditText = null;
	private EditText passwordEditText = null;

	public LoginFragment() {
		handler = new LoginHandler(getActivity());
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		if (getArguments() != null) {

		}

	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

		View view = inflater.inflate(R.layout.fragment_login, container, false);

		loginButton = (Button) view.findViewById(R.id.fl_login_button);
		nameEditText = (EditText) view.findViewById(R.id.fl_loginname_edit);
		passwordEditText = (EditText) view.findViewById(R.id.fl_password_edit);
		loginButton.setOnClickListener(new LoginButton_Listener(getActivity()));

		return view;
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnLoginFragmentInteractionListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString() + " must implement OnLoginFragmentInteractionListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	public interface OnLoginFragmentInteractionListener {
		public void onLoginFragmentInteraction(UserObject user);
	}

	private class LoginButton_Listener implements OnClickListener {

		private Activity activity;

		public LoginButton_Listener(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void onClick(View v) {
			HashMap<String, Object> params = new HashMap<String, Object>();
			params.put(IWebService.PARAM__LOGIN__LOGIN_NAME, nameEditText.getText().toString());
			params.put(IWebService.PARAM__LOGIN__PASSWORD, passwordEditText.getText().toString());
			WSThread thread = new WSThread(handler, IWebService.ID__LOGIN, params);
			thread.startWithProgressDialog(this.activity);
		}
	}

	private class LoginHandler extends Handler {

		private Activity activity = null;

		private LoginHandler(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			switch (msg.what) {
			case IWebService.ID__LOGIN:
				if (mListener != null) {
					UserObject user = (UserObject) msg.getData().getSerializable(IWebService.WS_RETURN);
					mListener.onLoginFragmentInteraction(user);
				}
				break;
			}

		}

		private void showNetworkErrorDialog() {

			new AlertDialog.Builder(this.activity).setTitle("error").setMessage("网络连接出错").setNeutralButton("返回", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dlg, int sumthin) {

				}
			}).show();

		}
	}
}
