package com.ss.stg;

import java.lang.ref.WeakReference;
import java.text.MessageFormat;
import java.util.Calendar;
import java.util.HashMap;

import com.ss.stg.dto.TourObject;
import com.ss.stg.ws2.DTOApi;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.R.integer;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DatePickerDialog.OnDateSetListener;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.DataSetObserver;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v4.app.FragmentActivity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Gallery;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.SpinnerAdapter;
import android.widget.TextView;
import android.widget.Toast;

public class TourEditActivity extends FragmentActivity implements OnDateSetListener {

	private Toast toast = null;
	private Handler handler = null;
	private Button startDateButton = null;
	private Button endDateButton = null;
	private Spinner statuSpinner = null;
	private EditText nameEditText = null;
	private TextView nameTextView = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_tour_edit);

		startDateButton = (Button) findViewById(R.id.tour_edit_start_date);
		endDateButton = (Button) findViewById(R.id.tour_edit_end_date);
		statuSpinner = (Spinner) findViewById(R.id.tour_edit_status);
		nameEditText = (EditText) findViewById(R.id.tour_edit_name);
		nameTextView = (TextView) findViewById(R.id.tour_edit_name_r);

		String[] mItems = getResources().getStringArray(R.array.tour_status_dict);
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_spinner_item, mItems);
		statuSpinner.setAdapter(adapter);

		// boolean readonly = false;
		String tourId = null;
		Intent intent = getIntent();

		if (intent != null) {
			tourId = intent.getStringExtra("tourid");
			if (tourId != null && !tourId.equals("")) {
				// readonly = intent.getBooleanExtra("readonly", true);
				handler = new STGHandler(this);
				HashMap<String, Object> params = new HashMap<String, Object>();
				WSThread thread = null;
				params.put(IWebService.PARAM__GET_TOUR_BY_TOURID, tourId);
				thread = new WSThread(handler, IWebService.ID__GET_TOUR_BY_TOURID, params);
				thread.startWithProgressDialog(this);

				nameTextView.setVisibility(View.VISIBLE);
				nameEditText.setVisibility(View.GONE);
			}
		}

		startDateButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				TourDateEditDialogFragment dialog = new TourDateEditDialogFragment();
				if (!startDateButton.getText().equals("")) {
					Bundle bundle = new Bundle();
					int[] tag = (int[]) startDateButton.getTag();
					bundle.putInt("Year", tag[0]);
					bundle.putInt("Month", tag[1]);
					bundle.putInt("Day", tag[2]);
					dialog.setArguments(bundle);
				}

				dialog.show(TourEditActivity.this.getSupportFragmentManager(), "start");
			}
		});

		endDateButton.setOnClickListener(new View.OnClickListener() {

			@Override
			public void onClick(View v) {
				// TODO Auto-generated method stub
				TourDateEditDialogFragment dialog = new TourDateEditDialogFragment();
				if (!endDateButton.getText().equals("")) {
					Bundle bundle = new Bundle();
					int[] tag = (int[]) endDateButton.getTag();
					bundle.putInt("Year", tag[0]);
					bundle.putInt("Month", tag[1]);
					bundle.putInt("Day", tag[2]);
					dialog.setArguments(bundle);
				}

				dialog.show(TourEditActivity.this.getSupportFragmentManager(), "end");
			}
		});
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

			if (msg.what == IWebService.ID__GET_TOUR_BY_TOURID) {

				TourObject tour = (TourObject) msg.getData().getSerializable(IWebService.WS_RETURN);

				TextView nameTextView = (TextView) activity.findViewById(R.id.tour_edit_name_r);
				nameTextView.setText(tour.getTourName());

				EditText nameEditText = (EditText) activity.findViewById(R.id.tour_edit_name);
				nameEditText.setText(tour.getTourName());

				Calendar c = Calendar.getInstance();
				c.setTime(tour.getBeginDate());
				int year = c.get(Calendar.YEAR);
				int month = c.get(Calendar.MONTH);
				int day = c.get(Calendar.DAY_OF_MONTH);
				int[] tag = new int[] { year, month, day };
				Button startDateButton = (Button) activity.findViewById(R.id.tour_edit_start_date);
				startDateButton.setTag(tag);
				startDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(tag[0]), tag[1] + 1, tag[2]));

				c.setTime(tour.getEndDate());
				year = c.get(Calendar.YEAR);
				month = c.get(Calendar.MONTH);
				day = c.get(Calendar.DAY_OF_MONTH);
				int[] tag2 = new int[] { year, month, day };
				Button endDateButton = (Button) activity.findViewById(R.id.tour_edit_end_date);
				endDateButton.setTag(tag2);
				endDateButton.setText(MessageFormat.format("{0}-{1}-{2}", String.valueOf(tag2[0]), tag2[1] + 1, tag2[2]));

				Spinner statuSpinner = (Spinner) activity.findViewById(R.id.tour_edit_status);
				if (tour.getStatus().equals("未进行")) {
					statuSpinner.setSelection(0);
				} else if (tour.getStatus().equals("进行中")) {
					statuSpinner.setSelection(1);
				} else if (tour.getStatus().equals("已结束")) {
					statuSpinner.setSelection(2);
				}

				ListView subtourListView = (ListView) activity.findViewById(R.id.tour_edit_subtourlist);
				ViewGroup.LayoutParams params0 = subtourListView.getLayoutParams();
				params0.height = tour.getSubtourList().size() * 50;
				subtourListView.setLayoutParams(params0);
				SubtourAdapter subtourAdapter = new SubtourAdapter(activity, SubtourAdapter.EDITABLE, tour.getSubtourList());
				subtourListView.setAdapter(subtourAdapter);

				// TextView dateTextView = (TextView)
				// activity.findViewById(R.id.tour_view_date);
				// TextView statusTextView = (TextView)
				// activity.findViewById(R.id.tour_view_status);
				// TextView costTextView = (TextView)
				// activity.findViewById(R.id.tour_view_cost);
				// TextView subtourTextView = (TextView)
				// activity.findViewById(R.id.tour_view_subtours);
				// TextView blogTextView = (TextView)
				// activity.findViewById(R.id.tour_view_blogs);
				// TextView commTextView = (TextView)
				// activity.findViewById(R.id.tour_view_comments);
				// TextView picTextView = (TextView)
				// activity.findViewById(R.id.tour_view_pictures);
				// ListView subtourListView = (ListView)
				// activity.findViewById(R.id.tour_view_subtourlist);
				// ListView commentListView = (ListView)
				// activity.findViewById(R.id.tour_view_commentlist);
				// ListView blogListView = (ListView)
				// activity.findViewById(R.id.tour_view_bloglist);
				// Gallery gallery = (Gallery)
				// activity.findViewById(R.id.tour_view_gallery);
				//
				// nameTextView.setText(tour.getTourName());
				// dateTextView.setText(DTOApi.dateFormat.format(tour.getBeginDate())
				// + " ~ " + DTOApi.dateFormat.format(tour.getEndDate()));
				// statusTextView.setText(tour.getStatus());
				// costTextView.setText("￥ " + String.valueOf(tour.getCost()) +
				// "元");
				// subtourTextView.setText(MessageFormat.format("行程景点({0})",
				// tour.getSubtourList().size()));
				// commTextView.setText(MessageFormat.format("留言({0})",
				// tour.getCommentList().size()));
				// picTextView.setText(MessageFormat.format("图片({0})",
				// tour.getPictureList().size()));
				// blogTextView.setText(MessageFormat.format("日志({0})",
				// tour.getBlogList().size()));
				//
				// ViewGroup.LayoutParams params0 =
				// subtourListView.getLayoutParams();
				// params0.height = tour.getSubtourList().size() * 50;
				// subtourListView.setLayoutParams(params0);
				// SubtourAdapter subtourAdapter = new SubtourAdapter(activity,
				// tour.getSubtourList());
				// subtourListView.setAdapter(subtourAdapter);
				//
				// ViewGroup.LayoutParams params =
				// commentListView.getLayoutParams();
				// params.height = tour.getCommentList().size() * 60;
				// commentListView.setLayoutParams(params);
				// CommentAdapter commentAdapter = new CommentAdapter(activity,
				// tour.getCommentList());
				// commentListView.setAdapter(commentAdapter);
				//
				// ImageAdapter imageAdapter = new ImageAdapter(activity,
				// tour.getPictureList());
				// gallery.setAdapter(imageAdapter);
				//
				// ViewGroup.LayoutParams params2 =
				// blogListView.getLayoutParams();
				// params2.height = tour.getBlogList().size() * 60;
				// blogListView.setLayoutParams(params2);
				// BlogAdapter blogAdapter = new BlogAdapter(activity,
				// tour.getBlogList());
				// blogListView.setAdapter(blogAdapter);

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
}
