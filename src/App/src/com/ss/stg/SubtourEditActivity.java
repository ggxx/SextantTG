package com.ss.stg;

import java.lang.ref.WeakReference;
import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import com.ss.stg.dto.CityItem;
import com.ss.stg.dto.CountryItem;
import com.ss.stg.dto.ProvinceItem;
import com.ss.stg.dto.SightItem;
import com.ss.stg.dto.SubtourItem;
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
import android.text.AndroidCharacter;
import android.view.LayoutInflater;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
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
	//private Handler handler = null;
	private Button okButton = null;
	private Button cancelButton = null;
	private Button startDateButton = null;
	private Button endDateButton = null;
	private Spinner countrySpinner = null;
	private Spinner provinceSpinner = null;
	private Spinner citySpinner = null;
	private Spinner sightSpinner = null;
	private EditText nameEditText = null;
	private TextView nameTextView = null;
	private TextView sightTextView = null;
	private TextView countryTipTextView = null;
	private TextView provinceTipTextView = null;
	private TextView cityTipTextView = null;
	private TextView sightTipTextView = null;

	private int pos = 0;

	private class OnCountrySelectedListener implements OnItemSelectedListener {

		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
			onCountryChange(arg2);
		}

		@Override
		public void onNothingSelected(AdapterView<?> arg0) {
			onCountryChange(-1);
		}
	}

	private class OnProvinceSelectedListener implements OnItemSelectedListener {

		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
			onProvineChange(arg2);
		}

		@Override
		public void onNothingSelected(AdapterView<?> arg0) {
			onProvineChange(-1);
		}
	}

	private class OnCitySelectedListener implements OnItemSelectedListener {

		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
			onCityChange(arg2);
		}

		@Override
		public void onNothingSelected(AdapterView<?> arg0) {
			onCityChange(-1);
		}
	}

	private class OnSightSelectedListener implements OnItemSelectedListener {

		@Override
		public void onItemSelected(AdapterView<?> arg0, View arg1, int arg2, long arg3) {
			onSightChange(arg2);
		}

		@Override
		public void onNothingSelected(AdapterView<?> arg0) {
			onSightChange(-1);
		}
	}

	public void onCountryChange(int position) {
		if (position >= 0) {
			System.out.println("onCountryChange" + position);
			String countryId = ((CountryItem) countrySpinner.getSelectedItem()).getCountryId();
			List<ProvinceItem> provinceItems = AppCache.getProvinceByCountry(countryId);
			if (provinceItems != null) {
				ArrayAdapter<ProvinceItem> provinceAdapter = new ArrayAdapter<ProvinceItem>(this, android.R.layout.simple_spinner_item, provinceItems);
				provinceSpinner.setAdapter(provinceAdapter);
			}
		} else {
			ArrayAdapter<ProvinceItem> provinceAdapter = new ArrayAdapter<ProvinceItem>(this, android.R.layout.simple_spinner_item, new ArrayList<ProvinceItem>());
			provinceSpinner.setAdapter(provinceAdapter);
		}
	}

	public void onProvineChange(int position) {
		if (position >= 0) {
			System.out.println("onProvineChange" + position);
			String provinceId = ((ProvinceItem) provinceSpinner.getSelectedItem()).getProvinceId();
			List<CityItem> cityItems = AppCache.getCityByProvince(provinceId);
			if (cityItems != null) {
				ArrayAdapter<CityItem> cityAdapter = new ArrayAdapter<CityItem>(this, android.R.layout.simple_spinner_item, cityItems);
				citySpinner.setAdapter(cityAdapter);
			}
		} else {
			ArrayAdapter<CityItem> cityAdapter = new ArrayAdapter<CityItem>(this, android.R.layout.simple_spinner_item, new ArrayList<CityItem>());
			citySpinner.setAdapter(cityAdapter);
		}
	}

	public void onCityChange(int position) {
		if (position >= 0) {
			System.out.println("onCityChange" + position);
			String cityId = ((CityItem) citySpinner.getSelectedItem()).getCityId();
			List<SightItem> sightItems = AppCache.getSightByCity(cityId);
			if (sightItems != null) {
				ArrayAdapter<SightItem> sightAdapter = new ArrayAdapter<SightItem>(this, android.R.layout.simple_spinner_item, sightItems);
				sightSpinner.setAdapter(sightAdapter);
			}
		} else {
			ArrayAdapter<SightItem> sightAdapter = new ArrayAdapter<SightItem>(this, android.R.layout.simple_spinner_item, new ArrayList<SightItem>());
			sightSpinner.setAdapter(sightAdapter);
		}
	}

	public void onSightChange(int position) {
		if (position >= 0) {
			String sightName = ((SightItem) sightSpinner.getSelectedItem()).getSightName();
			sightTextView.setText(sightName);
		} else {
			sightTextView.setText("");
		}
	}

	public SubtourEditActivity() {
		super();
		//handler = new STGHandler(this);
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_subtour_edit);

		okButton = (Button) findViewById(R.id.subtour_edit_ok);
		cancelButton = (Button) findViewById(R.id.subtour_edit_cancel);
		startDateButton = (Button) findViewById(R.id.subtour_edit_start_date);
		endDateButton = (Button) findViewById(R.id.subtour_edit_end_date);
		nameEditText = (EditText) findViewById(R.id.subtour_edit_name);
		nameTextView = (TextView) findViewById(R.id.subtour_edit_name_r);
		countrySpinner = (Spinner) findViewById(R.id.subtour_edit_country);
		provinceSpinner = (Spinner) findViewById(R.id.subtour_edit_province);
		citySpinner = (Spinner) findViewById(R.id.subtour_edit_city);
		sightSpinner = (Spinner) findViewById(R.id.subtour_edit_sight);
		sightTextView = (TextView) findViewById(R.id.subtour_edit_sight_r);
		countryTipTextView = (TextView) findViewById(R.id.subtour_edit_country_tv);
		provinceTipTextView = (TextView) findViewById(R.id.subtour_edit_province_tv);
		cityTipTextView = (TextView) findViewById(R.id.subtour_edit_city_tv);
		sightTipTextView = (TextView) findViewById(R.id.subtour_edit_sight_tv);

		String tourId = null;
		String subtourId = null;
		final Intent intent = getIntent();
		pos = intent.getIntExtra("pos", 0);
		final SubtourItem subtourItem = (SubtourItem) intent.getSerializableExtra("subtour");

		if (subtourItem != null) {
			tourId = subtourItem.getTourId();
			subtourId = subtourItem.getSubtourId();

			//HashMap<String, Object> params = new HashMap<String, Object>();
			//WSThread thread = null;
			//params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID, tourId);
			//params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID, subtourId);
			//thread = new WSThread(handler, IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID, params);
			//thread.startWithProgressDialog(this);

			nameTextView.setVisibility(View.VISIBLE);
			sightTextView.setVisibility(View.VISIBLE);

			countrySpinner.setVisibility(View.GONE);
			provinceSpinner.setVisibility(View.GONE);
			citySpinner.setVisibility(View.GONE);
			sightSpinner.setVisibility(View.GONE);
			countryTipTextView.setVisibility(View.GONE);
			provinceTipTextView.setVisibility(View.GONE);
			cityTipTextView.setVisibility(View.GONE);
			sightTipTextView.setVisibility(View.GONE);
			nameEditText.setVisibility(View.GONE);

			nameTextView.setText(subtourItem.getSubtourName());
			nameEditText.setText(subtourItem.getSubtourName());
			sightTextView.setText(subtourItem.getSightName());

			Calendar s = Calendar.getInstance();
			s.setTime(subtourItem.getBeginDate());
			setSartDateValue(s.get(Calendar.YEAR), s.get(Calendar.MONTH), s.get(Calendar.DAY_OF_MONTH));
			s.setTime(subtourItem.getEndDate());
			setEndDateValue(s.get(Calendar.YEAR), s.get(Calendar.MONTH), s.get(Calendar.DAY_OF_MONTH));
		} else {
			countrySpinner.setOnItemSelectedListener(new OnCountrySelectedListener());
			provinceSpinner.setOnItemSelectedListener(new OnProvinceSelectedListener());
			citySpinner.setOnItemSelectedListener(new OnCitySelectedListener());
			sightSpinner.setOnItemSelectedListener(new OnSightSelectedListener());

			ArrayAdapter<CountryItem> countryAdapter = new ArrayAdapter<CountryItem>(this, android.R.layout.simple_spinner_item, AppCache.getCountryItems());
			countrySpinner.setAdapter(countryAdapter);
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

		okButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				System.out.println("行程名称(" + nameEditText.getText().toString() + ")");
				if (nameEditText.getText().toString().equals("")) {
					toast = Toast.makeText(SubtourEditActivity.this, "行程名称不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}
				if (sightTextView.getText().toString().equals("")) {
					toast = Toast.makeText(SubtourEditActivity.this, "景点不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}
				if (startDateButton.getText().toString().equals("")) {
					toast = Toast.makeText(SubtourEditActivity.this, "出发日期不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}
				if (endDateButton.getText().toString().equals("")) {
					toast = Toast.makeText(SubtourEditActivity.this, "结束日期不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}

				int[] s = (int[]) startDateButton.getTag();
				int[] e = (int[]) endDateButton.getTag();
				String name = nameEditText.getText().toString();
				String id = subtourItem != null ? subtourItem.getTourId() : "";
				String subId = subtourItem != null ? subtourItem.getSubtourId() : "";
				String sight = sightTextView.getText().toString();

				Calendar calendar = Calendar.getInstance();
				calendar.set(Calendar.YEAR, s[0]);
				calendar.set(Calendar.MONTH, s[1]);
				calendar.set(Calendar.DAY_OF_MONTH, s[2]);
				Date start = calendar.getTime();
				calendar.set(Calendar.YEAR, e[0]);
				calendar.set(Calendar.MONTH, e[1]);
				calendar.set(Calendar.DAY_OF_MONTH, e[2]);
				Date end = calendar.getTime();

				SubtourItem subtour = new SubtourItem();
				subtour.setBeginDate(start);
				subtour.setEndDate(end);
				subtour.setSightName(sight);
				subtour.setSubtourId(subId);
				subtour.setSubtourName(name);
				subtour.setTourId(id);

				Intent intent = new Intent();
				intent.putExtra("pos", pos);
				intent.putExtra("subtour", subtour);
				setResult(RESULT_OK, intent);
				finish();
			}
		});

		cancelButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				setResult(RESULT_CANCELED);
				finish();
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

/*	private static class STGHandler extends Handler {

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

	}*/
}
