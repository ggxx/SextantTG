package com.ss.stg;

import java.util.HashMap;

import com.ss.stg.dto.UserObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

public class RegistActivity extends Activity {

	private Handler handler = null;
	private Button registButton = null;
	private EditText nameEditText = null;
	private EditText passwordEditText = null;
	private EditText emailEditText = null;
	private EditText passwordEditText2 = null;
	private Toast toast = null;

	public RegistActivity() {
		handler = new RegistHandler(this);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_regist);

		registButton = (Button) findViewById(R.id.ar_regist_button);
		nameEditText = (EditText) findViewById(R.id.ar_loginname_edit);
		passwordEditText = (EditText) findViewById(R.id.ar_password_edit);
		passwordEditText2 = (EditText) findViewById(R.id.ar_password_edit2);
		emailEditText = (EditText) findViewById(R.id.ar_email_edit);

		registButton.setOnClickListener(new RegistButton_Listener2());
	}

	private class RegistButton_Listener2 implements OnClickListener {

		@Override
		public void onClick(View v) {

			UserObject userObject = new UserObject();
			userObject.setUserId("");
			userObject.setLoginName(nameEditText.getText().toString());
			userObject.setStatus(0);
			userObject.setEmail(emailEditText.getText().toString());
			String password = passwordEditText.getText().toString();

			if (userObject.getLoginName().equals("") || userObject.getEmail().equals("") || password.equals("")) {
				toast = Toast.makeText(RegistActivity.this, "用户信息均不能为空", Toast.LENGTH_SHORT);
				toast.show();
				return;
			}
			if (!passwordEditText.getText().toString().equals(passwordEditText2.getText().toString())) {
				toast = Toast.makeText(RegistActivity.this, "输入的口令不一致", Toast.LENGTH_SHORT);
				toast.show();
				return;
			}

			HashMap<String, Object> params = new HashMap<String, Object>();
			params.put(IWebService.PARAM__REGIST__USER, userObject);
			params.put(IWebService.PARAM__REGIST__PASSWORD, password);
			WSThread thread = new WSThread(handler, IWebService.ID__REGIST, params);
			thread.startWithProgressDialog(RegistActivity.this);
		}
	}

	private class RegistHandler extends Handler {

		private Activity activity = null;

		private RegistHandler(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			switch (msg.what) {
			case IWebService.ID__REGIST:
				boolean result = msg.getData().getBoolean(IWebService.WS_RETURN);
				if (result) {
					Intent intent = new Intent();
					intent.putExtra("userid", "");
					RegistActivity.this.setResult(RESULT_OK, intent);
					RegistActivity.this.finish();
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
