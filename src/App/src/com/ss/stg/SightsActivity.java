package com.ss.stg;

import java.util.HashMap;

import com.ss.stg.dto.SightObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

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
		params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID, id);

		WSThread thread = new WSThread(handler, IWebService.ID__GET_SIGHT_BY_SIGHTID, params);
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

			if (msg.what == IWebService.ID__GET_SIGHT_BY_SIGHTID) {
				TextView tv = (TextView)findViewById(R.id.sights_1);
				SightObject sights = (SightObject)msg.getData().getSerializable(IWebService.WS_RETURN);
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
