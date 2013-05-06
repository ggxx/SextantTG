package com.ss.stg;

import java.util.HashMap;

import com.ss.stg.model.Sights;
import com.ss.stg.ws.ISTGService;
import com.ss.stg.ws.WebServiceThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.widget.TextView;

public class SightsActivity extends Activity {
	
	private Handler handler = null;
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.layout_view_sights);
		
		String id =getIntent().getStringExtra("id");
		
		handler = new STGHandler(this);

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(ISTGService.PARAM__GETSIGHTSBYSIGHTSID, id);

		WebServiceThread thread = new WebServiceThread(handler, ISTGService.ID__GETSIGHTSBYSIGHTSID, params);
		thread.startWithProgressDialog(this);
	
	}
	
	private class STGHandler extends Handler {
		
		private Activity activity = null;

		private STGHandler(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			if (msg.what == ISTGService.ID__GETSIGHTSBYSIGHTSID) {
				TextView tv = (TextView)findViewById(R.id.sights_1);
				Sights sights = (Sights)msg.getData().getSerializable(ISTGService.WS_RETURN);
				tv.setText(sights.getSightsName());
			} else {
				showNetworkErrorDialog();
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
