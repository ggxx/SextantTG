package com.ss.stg;

import java.util.HashMap;
import java.util.List;

import com.ss.stg.dto.CityItem;
import com.ss.stg.dto.CountryItem;
import com.ss.stg.dto.ProvinceItem;
import com.ss.stg.dto.UserObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.Fragment;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class LoginFragment extends Fragment {

	private Handler handler = null;
	private OnLoginFragmentInteractionListener mListener;
	private OnLogoutFragmentInteractionListener mListener2;

	private TextView tipTextView = null;
	private Button loginButton = null;
	private Button logoutButton = null;
	private Button registButton = null;
	private EditText nameEditText = null;
	private EditText passwordEditText = null;
	private Toast toast = null;

	public LoginFragment() {
		handler = new LoginHandler(getActivity());
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		Log.d("MyLog", "LoginFragment_onCreate");
		super.onCreate(savedInstanceState);
		if (getArguments() != null) {
		}

		setHasOptionsMenu(true);

		Handler handler = new Handler() {
			@Override
			public void handleMessage(Message msg) {
				super.handleMessage(msg);
				switch (msg.what) {
				case IWebService.ID__GET_COUNTRIES:
					Log.d("ws_handler", "ID__GET_COUNTRIES");
					AppCache.setCountryItems((List<CountryItem>) msg.getData().getSerializable(IWebService.WS_RETURN));
					break;
				case IWebService.ID__GET_PROVINCES:
					Log.d("ws_handler", "ID__GET_PROVINCES");
					AppCache.setProvinceItems((List<ProvinceItem>) msg.getData().getSerializable(IWebService.WS_RETURN));
					break;
				case IWebService.ID__GET_CITIES:
					Log.d("ws_handler", "ID__GET_CITIES");
					AppCache.setCityItems((List<CityItem>) msg.getData().getSerializable(IWebService.WS_RETURN));
					break;
				// case IWebService.ID__GET_SIGHTS:
				// Log.d("ws_handler", "ID__GET_SIGHTS");
				// AppCache.setSightItems((List<SightItem>)
				// msg.getData().getSerializable(IWebService.WS_RETURN));
				// break;
				}
			}
		};
		if (AppCache.getCountryItems() == null) {
			WSThread thread = new WSThread(handler, IWebService.ID__GET_COUNTRIES);
			thread.startWithProgressDialog(getActivity());
		}
		if (AppCache.getProvinceItems() == null) {
			WSThread thread2 = new WSThread(handler, IWebService.ID__GET_PROVINCES);
			thread2.startWithProgressDialog(getActivity());
		}
		if (AppCache.getCityItems() == null) {
			WSThread thread3 = new WSThread(handler, IWebService.ID__GET_CITIES);
			thread3.startWithProgressDialog(getActivity());
		}
		// WSThread thread4 = new WSThread(handler, IWebService.ID__GET_SIGHTS);
		// thread4.startWithProgressDialog(this);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
		Log.d("MyLog", "LoginFragment_onCreateView");

		View view = inflater.inflate(R.layout.fragment_login, container, false);

		tipTextView = (TextView) view.findViewById(R.id.fl_tip_text);
		loginButton = (Button) view.findViewById(R.id.fl_login_button);
		logoutButton = (Button) view.findViewById(R.id.fl_logout_button);
		registButton = (Button) view.findViewById(R.id.fl_regist_button);
		nameEditText = (EditText) view.findViewById(R.id.fl_loginname_edit);
		passwordEditText = (EditText) view.findViewById(R.id.fl_password_edit);
		loginButton.setOnClickListener(new LoginButton_Listener(getActivity()));
		logoutButton.setOnClickListener(new LogoutButton_Listener());
		registButton.setOnClickListener(new RegistButton_Listener());

		if (((MainActivity) getActivity()).getLoginUserId().equals("")) {
			nameEditText.setVisibility(View.VISIBLE);
			passwordEditText.setVisibility(View.VISIBLE);
			loginButton.setVisibility(View.VISIBLE);
			registButton.setVisibility(View.VISIBLE);
			logoutButton.setVisibility(View.GONE);
			tipTextView.setVisibility(View.GONE);
		} else {
			nameEditText.setVisibility(View.GONE);
			passwordEditText.setVisibility(View.GONE);
			loginButton.setVisibility(View.GONE);
			registButton.setVisibility(View.GONE);
			logoutButton.setVisibility(View.VISIBLE);
			tipTextView.setVisibility(View.VISIBLE);
		}

		return view;
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnLoginFragmentInteractionListener) activity;
			mListener2 = (OnLogoutFragmentInteractionListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString() + " must implement OnLoginFragmentInteractionListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
		mListener2 = null;
	}

	@Override
	public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
		// inflater.inflate(R.menu.main, menu);
	}

	public interface OnLoginFragmentInteractionListener {
		public void onLoginFragmentInteraction(String id);
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

			String loginName = nameEditText.getText().toString();
			String password = passwordEditText.getText().toString();
			if (loginName.equals("") || password.equals("")) {
				toast = Toast.makeText(activity, "用户名和口令均不能为空", Toast.LENGTH_SHORT);
				toast.show();
				return;
			}

			HashMap<String, Object> params = new HashMap<String, Object>();
			params.put(IWebService.PARAM__LOGIN__LOGIN_NAME, loginName);
			params.put(IWebService.PARAM__LOGIN__PASSWORD, password);
			WSThread thread = new WSThread(handler, IWebService.ID__LOGIN, params);
			thread.startWithProgressDialog(this.activity);
		}
	}

	private class LogoutButton_Listener implements OnClickListener {

		@Override
		public void onClick(View v) {
			nameEditText.setText("");
			passwordEditText.setText("");
			nameEditText.setVisibility(View.VISIBLE);
			passwordEditText.setVisibility(View.VISIBLE);
			loginButton.setVisibility(View.VISIBLE);
			registButton.setVisibility(View.VISIBLE);
			logoutButton.setVisibility(View.GONE);
			tipTextView.setVisibility(View.GONE);
			mListener2.onLogoutFragmentInteraction();
		}
	}

	private class RegistButton_Listener implements OnClickListener {

		@Override
		public void onClick(View v) {
			Intent intent = new Intent(getActivity(), RegistActivity.class);
			startActivityForResult(intent, 1);
		}
	}

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (resultCode == Activity.RESULT_OK) {
			toast = Toast.makeText(this.getActivity(), "用户注册成功", Toast.LENGTH_SHORT);
			toast.show();

			// String userId = data.getStringExtra("userid");
			// nameEditText.setVisibility(View.GONE);
			// passwordEditText.setVisibility(View.GONE);
			// loginButton.setVisibility(View.GONE);
			// registButton.setVisibility(View.GONE);
			// logoutButton.setVisibility(View.VISIBLE);
			// mListener.onLoginFragmentInteraction(userId);
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
					if (user != null) {
						nameEditText.setVisibility(View.GONE);
						passwordEditText.setVisibility(View.GONE);
						loginButton.setVisibility(View.GONE);
						registButton.setVisibility(View.GONE);
						logoutButton.setVisibility(View.VISIBLE);
						tipTextView.setVisibility(View.VISIBLE);
						mListener.onLoginFragmentInteraction(user.getUserId());
					}
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
