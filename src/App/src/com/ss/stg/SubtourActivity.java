package com.ss.stg;

import java.lang.ref.WeakReference;
import java.util.HashMap;

import com.ss.stg.dto.SubtourItem;
import com.ss.stg.dto.SubtourObject;
import com.ss.stg.ws2.DTOApi;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.TextView;
import android.widget.Toast;

public class SubtourActivity extends Activity {

	private Handler handler = null;

	// private TextView nameTextView = null;
	// private TextView sightTextView = null;
	// private TextView dateTextView = null;
	private String tourId = null;
	private String subtourId = null;
	private String userId = null;
	private String sightId = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_subtour);

		// nameTextView = (TextView) findViewById(R.id.subtour_name);
		// sightTextView = (TextView) findViewById(R.id.subtour_sight);
		// dateTextView = (TextView) findViewById(R.id.subtour_date);

		tourId = getIntent().getStringExtra("tourid");
		subtourId = getIntent().getStringExtra("subtourid");
		userId = getIntent().getStringExtra("userid");
		sightId = getIntent().getStringExtra("sightid");

		handler = new STGHandler(this);
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID, tourId);
		params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID, subtourId);
		WSThread thread = new WSThread(handler, IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID, params);
		thread.startWithProgressDialog(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.subtour, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case R.id.menu_subtour_blog:
			tourId = getIntent().getStringExtra("tourid");
			subtourId = getIntent().getStringExtra("subtourid");
			userId = getIntent().getStringExtra("userid");
			sightId = getIntent().getStringExtra("sightid");

			Intent intent = new Intent(this, BlogEditActivity.class);
			intent.putExtra("tourid", tourId);
			intent.putExtra("subtourid", subtourId);
			intent.putExtra("sightid", sightId);
			intent.putExtra("userid", userId);
			startActivityForResult(intent, 1);
			break;

		case R.id.menu_subtour_picture:

			Toast toast = Toast.makeText(this, "暂未实现", Toast.LENGTH_SHORT);
			toast.show();

			if (1 == 2) {
				Intent intent2 = new Intent();
				intent2.setType("image/*");
				intent2.setAction(Intent.ACTION_GET_CONTENT);
				startActivityForResult(intent2, 2);
			}
			break;

		}
		return false;
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == 1 && resultCode == RESULT_OK) {

		}
	}

	private static class STGHandler extends Handler {

		private WeakReference<Activity> refActivity = null;

		private STGHandler(Activity activity) {
			this.refActivity = new WeakReference<Activity>(activity);
		}

		@Override
		public void handleMessage(Message msg) {

			Activity activity = refActivity.get();

			super.handleMessage(msg);

			if (msg.what == IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID) {
				SubtourObject subtour = (SubtourObject) msg.getData().getSerializable(IWebService.WS_RETURN);
				TextView nameTextView = (TextView) activity.findViewById(R.id.subtour_name);
				TextView sightTextView = (TextView) activity.findViewById(R.id.subtour_sight);
				TextView dateTextView = (TextView) activity.findViewById(R.id.subtour_date);

				nameTextView.setText(subtour.getSubtourName());
				sightTextView.setText(subtour.getSightName());
				dateTextView.setText(DTOApi.dateFormat.format(subtour.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(subtour.getEndDate()));
			}
		}
	}

}
