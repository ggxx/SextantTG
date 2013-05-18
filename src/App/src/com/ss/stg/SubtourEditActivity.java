package com.ss.stg;

import java.lang.ref.WeakReference;
import java.text.MessageFormat;
import java.util.Calendar;
import java.util.HashMap;
import java.util.List;

import com.ss.stg.dto.SightItem;
import com.ss.stg.dto.SubtourObject;
import com.ss.stg.dto.TourObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.Dialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v4.app.DialogFragment;
import android.support.v4.app.FragmentActivity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

public class SubtourEditActivity extends FragmentActivity implements OnDateSetListener {

	private Toast toast = null;
	private Handler handler = null;
	private Button startDateButton = null;
	private Button endDateButton = null;
	private Spinner countrySpinner = null;
	private Spinner provinceSpinner = null;
	private Spinner citySpinner = null;
	private Spinner sightSpinner = null;
	private EditText nameEditText = null;
	private TextView nameTextView = null;
	private HashMap<String, String> countryMap = null;
	private HashMap<String, String> provinceMap = null;
	private HashMap<String, String> cityMap = null;
	private HashMap<String, String> sightMap = null;

	public SubtourEditActivity() {
		super();
		handler = new STGHandler(this);

		// WSThread thread = new WSThread(handler, IWebService.);
		// thread.start();
		// WSThread thread2 = new WSThread(handler,
		// IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID);
		// thread2.start();
		// WSThread thread3 = new WSThread(handler,
		// IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID);
		// thread3.start();
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.subtour_item_edit);

		startDateButton = (Button) findViewById(R.id.subtour_edit_start_date);
		endDateButton = (Button) findViewById(R.id.subtour_edit_end_date);
		nameEditText = (EditText) findViewById(R.id.subtour_edit_name);
		nameTextView = (TextView) findViewById(R.id.subtour_edit_name_r);
		countrySpinner = (Spinner) findViewById(R.id.subtour_edit_country);
		provinceSpinner = (Spinner) findViewById(R.id.subtour_edit_province);
		citySpinner = (Spinner) findViewById(R.id.subtour_edit_city);
		sightSpinner = (Spinner) findViewById(R.id.subtour_edit_sight);

		WSThread thread2 = new WSThread(handler, IWebService.ID__GET_SIGHTS);
		thread2.start();

		String tourId = null;
		String subtourId = null;
		Intent intent = getIntent();

		if (intent != null) {

			tourId = intent.getStringExtra("tourid");
			subtourId = intent.getStringExtra("subtourid");
			if (tourId != null && !tourId.equals("")) {

				HashMap<String, Object> params = new HashMap<String, Object>();
				WSThread thread = null;
				params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID, tourId);
				params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID, subtourId);
				thread = new WSThread(handler, IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID, params);
				thread.startWithProgressDialog(this);

				nameTextView.setVisibility(View.VISIBLE);
				nameEditText.setVisibility(View.GONE);
			} else {

			}
		}

		startDateButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				TourDateEditDialogFragment dialog = new TourDateEditDialogFragment();
				if (!startDateButton.getText().equals("")) {
					Bundle bundle = new Bundle();
					int[] tag = (int[]) startDateButton.getTag();
					bundle.putInt("Year", tag[0]);
					bundle.putInt("Month", tag[1]);
					bundle.putInt("Day", tag[2]);
					dialog.setArguments(bundle);
				}

				dialog.show(SubtourEditActivity.this.getSupportFragmentManager(), "start");
			}
		});

		endDateButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				TourDateEditDialogFragment dialog = new TourDateEditDialogFragment();
				if (!endDateButton.getText().equals("")) {
					Bundle bundle = new Bundle();
					int[] tag = (int[]) endDateButton.getTag();
					bundle.putInt("Year", tag[0]);
					bundle.putInt("Month", tag[1]);
					bundle.putInt("Day", tag[2]);
					dialog.setArguments(bundle);
				}

				dialog.show(SubtourEditActivity.this.getSupportFragmentManager(), "end");
			}
		});

	}

	private void setSartDateValue(int year, int monthOfYear, int dayOfMonth) {
		int[] tag = new int[] { year, monthOfYear, dayOfMonth };
		startDateButton.setTag(tag);
		startDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(year), monthOfYear + 1, dayOfMonth));
	}

	private void setEndDateValue(int year, int monthOfYear, int dayOfMonth) {
		int[] tag = new int[] { year, monthOfYear, dayOfMonth };
		endDateButton.setTag(tag);
		endDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(year), monthOfYear + 1, dayOfMonth));
	}

	@Override
	public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
		if (view.getTag().equals("start")) {
			setSartDateValue(year, monthOfYear, dayOfMonth);
		} else if (view.getTag().equals("end")) {
			setEndDateValue(year, monthOfYear, dayOfMonth);
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

				TextView nameTextView = (TextView) activity.findViewById(R.id.subtour_edit_name_r);
				nameTextView.setText(subtour.getSubtourName());

				EditText nameEditText = (EditText) activity.findViewById(R.id.subtour_edit_name);
				nameEditText.setText(subtour.getSubtourName());

				Calendar c = Calendar.getInstance();
				c.setTime(subtour.getBeginDate());
				int year = c.get(Calendar.YEAR);
				int month = c.get(Calendar.MONTH);
				int day = c.get(Calendar.DAY_OF_MONTH);
				int[] tag = new int[] { year, month, day };
				Button startDateButton = (Button) activity.findViewById(R.id.tour_edit_start_date);
				startDateButton.setTag(tag);
				startDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(tag[0]), tag[1] + 1, tag[2]));

				c.setTime(subtour.getEndDate());
				year = c.get(Calendar.YEAR);
				month = c.get(Calendar.MONTH);
				day = c.get(Calendar.DAY_OF_MONTH);
				int[] tag2 = new int[] { year, month, day };
				Button endDateButton = (Button) activity.findViewById(R.id.tour_edit_end_date);
				endDateButton.setTag(tag2);
				endDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(tag2[0]), tag2[1] + 1, tag2[2]));
			} else if (msg.what == IWebService.ID__GET_SIGHTS) {
				Spinner sightSpinner = (Spinner) activity.findViewById(R.id.subtour_edit_sight);
				List<SightItem> items = (List<SightItem>) msg.getData().getSerializable(IWebService.WS_RETURN);
				SightsAdapter adapter = new SightsAdapter(activity, items);
				sightSpinner.setAdapter(adapter);
			} else {
				showNetworkErrorDialog();
			}
		}

		private void showNetworkErrorDialog() {

			new AlertDialog.Builder(this.refActivity.get()).setTitle("error").setMessage("网络连接出错").setNeutralButton("返回", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dlg, int sumthin) {

				}
			}).show();

		}

	}
}
