package com.ss.stg;

import com.ss.stg.ws.ISTGService;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Handler;
import android.os.Message;

public class UIHandler extends Handler {

	private Activity activity = null;

	public UIHandler(Activity activity) {
		this.activity = activity;
	}

	@Override
	public void handleMessage(Message msg) {

		super.handleMessage(msg);

		if (msg.what == ISTGService.ID__HELLOWORLD) {
			// TextView tip = (TextView) activity.findViewById(R.id.tip);
			// String val =
			// msg.getData().getSerializable(ISTGService.WS_RETURN).toString();
			// tip.setText(tip.getText().toString() + val);
		} else if (msg.what == ISTGService.ID__ERROR) {
			// TextView tip = (TextView) activity.findViewById(R.id.tip);
			// String val = msg.getData().getString(ISTGService.WS_RETURN);
			// tip.setText(tip.getText().toString() + val);
		} else if (msg.what == ISTGService.ID__INSERTUSER) {
			// TextView tip = (TextView) activity.findViewById(R.id.tip);
			// boolean val = msg.getData().getBoolean(ISTGService.WS_RETURN);
			// tip.setText(tip.getText().toString() + String.valueOf(val));
		} else if (msg.what == ISTGService.ID__GETUSERS) {
			// TextView tip = (TextView) activity.findViewById(R.id.tip);
			// List<User> users = (List<User>)
			// msg.getData().getSerializable(ISTGService.WS_RETURN);
			// tip.setText(tip.getText().toString() + users.size());
		}
		
	}

	private void showNetworkErrorDialog() {

		new AlertDialog.Builder(this.activity).setTitle("error").setMessage("网络连接出错").setNeutralButton("返回", new DialogInterface.OnClickListener() {
			public void onClick(DialogInterface dlg, int sumthin) {

			}
		}).show();

	}
}
