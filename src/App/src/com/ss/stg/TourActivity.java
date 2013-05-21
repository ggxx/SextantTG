package com.ss.stg;

import java.io.File;
import java.text.MessageFormat;
import java.util.Date;
import java.util.HashMap;

import com.ss.stg.dto.BlogItem;
import com.ss.stg.dto.PictureItem;
import com.ss.stg.dto.SubtourItem;
import com.ss.stg.dto.TourObject;
import com.ss.stg.ws2.DTOApi;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.MediaScanner;
import com.ss.stg.ws2.UploadUtil;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.os.Handler;
import android.os.Message;
import android.provider.MediaStore;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.MarginLayoutParams;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Gallery;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class TourActivity extends Activity {

	private Toast toast = null;
	private Handler handler = null;
	private String TAG = "TourActivity";

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_tour);

		String tourId = getIntent().getStringExtra("tourid");

		handler = new STGHandler(this);

		HashMap<String, Object> params = new HashMap<String, Object>();

		WSThread thread = null;

		params.put(IWebService.PARAM__GET_TOUR_BY_TOURID, tourId);
		thread = new WSThread(handler, IWebService.ID__GET_TOUR_BY_TOURID, params);
		thread.startWithProgressDialog(this);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.tour, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case R.id.menu_tour_comment:
			Intent intent = new Intent(this, CommentEditActivity.class);
			intent.putExtra("targetid", getIntent().getStringExtra("tourid"));
			intent.putExtra("userid", getIntent().getStringExtra("userid"));
			startActivityForResult(intent, 1);
			break;
		}

		return false;
	}

	@Override
	protected void onActivityResult(int requestCode, int resultCode, Intent data) {
		if (requestCode == 1 && resultCode == RESULT_OK) {
			WSThread thread = null;
			HashMap<String, Object> params = new HashMap<String, Object>();
			params.put(IWebService.PARAM__GET_TOUR_BY_TOURID, getIntent().getStringExtra("tourid"));
			thread = new WSThread(handler, IWebService.ID__GET_TOUR_BY_TOURID, params);
			thread.startWithProgressDialog(this);
		}
	}

	private class STGHandler extends Handler {

		private Activity activity = null;

		private STGHandler(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			if (msg.what == IWebService.ID__GET_TOUR_BY_TOURID) {

				TourObject tour = (TourObject) msg.getData().getSerializable(IWebService.WS_RETURN);
				TextView nameTextView = (TextView) findViewById(R.id.tour_view_name);
				TextView dateTextView = (TextView) findViewById(R.id.tour_view_date);
				TextView statusTextView = (TextView) findViewById(R.id.tour_view_status);
				TextView costTextView = (TextView) findViewById(R.id.tour_view_cost);
				TextView subtourTextView = (TextView) findViewById(R.id.tour_view_subtours);
				TextView blogTextView = (TextView) findViewById(R.id.tour_view_blogs);
				TextView commTextView = (TextView) findViewById(R.id.tour_view_comments);
				TextView picTextView = (TextView) findViewById(R.id.tour_view_pictures);
				ListView subtourListView = (ListView) findViewById(R.id.tour_view_subtourlist);
				ListView commentListView = (ListView) findViewById(R.id.tour_view_commentlist);
				ListView blogListView = (ListView) findViewById(R.id.tour_view_bloglist);
				Gallery gallery = (Gallery) findViewById(R.id.tour_view_gallery);

				nameTextView.setText(tour.getTourName());
				dateTextView.setText(DTOApi.dateFormat.format(tour.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(tour.getEndDate()));
				statusTextView.setText(tour.getStatus());
				costTextView.setText("￥ " + String.valueOf(tour.getCost()) + "元");
				subtourTextView.setText(MessageFormat.format("行程景点({0})", tour.getSubtourList().size()));
				commTextView.setText(MessageFormat.format("留言({0})", tour.getCommentList().size()));
				picTextView.setText(MessageFormat.format("图片({0})", tour.getPictureList().size()));
				blogTextView.setText(MessageFormat.format("日志({0})", tour.getBlogList().size()));

				SubtourAdapter subtourAdapter = new SubtourAdapter(activity, SubtourAdapter.READONLY, tour.getSubtourList());
				subtourListView.setAdapter(subtourAdapter);
				setListViewHeightBasedOnChildren(subtourListView);

				CommentAdapter commentAdapter = new CommentAdapter(activity, tour.getCommentList());
				commentListView.setAdapter(commentAdapter);
				setListViewHeightBasedOnChildren(commentListView);

				ImageAdapter imageAdapter = new ImageAdapter(activity, tour.getPictureList());
				gallery.setAdapter(imageAdapter);

				BlogAdapter blogAdapter = new BlogAdapter(activity, tour.getBlogList());
				blogListView.setAdapter(blogAdapter);
				setListViewHeightBasedOnChildren(blogListView);

				subtourListView.setOnItemClickListener(new ListView.OnItemClickListener() {
					@Override
					public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
						SubtourItem item = (SubtourItem) parent.getItemAtPosition(position);
						Intent intent = new Intent(TourActivity.this, SubtourActivity.class);
						intent.putExtra("tourid", item.getTourId());
						intent.putExtra("subtourid", item.getSubtourId());
						intent.putExtra("sightid", item.getSightId());
						intent.putExtra("userid", getIntent().getStringExtra("userid"));
						startActivity(intent);
					}
				});

				blogListView.setOnItemClickListener(new ListView.OnItemClickListener() {
					@Override
					public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
						BlogItem item = (BlogItem) parent.getItemAtPosition(position);
						Intent intent = new Intent(TourActivity.this, BlogActivity.class);
						intent.putExtra("blogid", item.getBlogId());
						startActivity(intent);
					}
				});

			} else {
				showNetworkErrorDialog();
			}
		}

		public void setListViewHeightBasedOnChildren(ListView listView) {
			ListAdapter listAdapter = listView.getAdapter();
			if (listAdapter == null) {
				return;
			}

			int totalHeight = 0;
			for (int i = 0; i < listAdapter.getCount(); i++) {
				View listItem = listAdapter.getView(i, null, listView);
				listItem.measure(0, 0);
				totalHeight += listItem.getMeasuredHeight() + 4;
			}

			ViewGroup.LayoutParams params = listView.getLayoutParams();
			params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
			((MarginLayoutParams) params).setMargins(4, 4, 4, 4);
			listView.setLayoutParams(params);
		}

		private void showNetworkErrorDialog() {

			new AlertDialog.Builder(this.activity).setTitle("error").setMessage("网络连接出错").setNeutralButton("返回", new DialogInterface.OnClickListener() {
				public void onClick(DialogInterface dlg, int sumthin) {

				}
			}).show();

		}
	}
}
