package com.ss.stg;

import java.lang.ref.WeakReference;
import java.text.MessageFormat;
import java.util.HashMap;

import com.ss.stg.dto.TourObject;
import com.ss.stg.ws2.DTOApi;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.view.ViewGroup;
import android.widget.Gallery;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

public class TourEditActivity extends Activity {

	private Toast toast = null;
	private Handler handler = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_tour_edit);

		String tourId = getIntent().getStringExtra("tourid");

		handler = new STGHandler(this);

		HashMap<String, Object> params = new HashMap<String, Object>();

		WSThread thread = null;

		params.put(IWebService.PARAM__GET_TOUR_BY_TOURID, tourId);
		thread = new WSThread(handler, IWebService.ID__GET_TOUR_BY_TOURID, params);
		thread.startWithProgressDialog(this);
	}

	private static class STGHandler extends Handler {

		private WeakReference<Activity> refActivity = null;

		//private Activity activity = null;

		private STGHandler(Activity activity) {
			this.refActivity = new WeakReference<Activity>(activity);
			//this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			Activity activity = refActivity.get();
			
			super.handleMessage(msg);

			if (msg.what == IWebService.ID__GET_TOUR_BY_TOURID) {

				TourObject tour = (TourObject) msg.getData().getSerializable(IWebService.WS_RETURN);
				TextView nameTextView = (TextView) activity.findViewById(R.id.tour_view_name);
				TextView dateTextView = (TextView) activity.findViewById(R.id.tour_view_date);
				TextView statusTextView = (TextView) activity.findViewById(R.id.tour_view_status);
				TextView costTextView = (TextView) activity.findViewById(R.id.tour_view_cost);
				TextView subtourTextView = (TextView) activity.findViewById(R.id.tour_view_subtours);
				TextView blogTextView = (TextView) activity.findViewById(R.id.tour_view_blogs);
				TextView commTextView = (TextView) activity.findViewById(R.id.tour_view_comments);
				TextView picTextView = (TextView) activity.findViewById(R.id.tour_view_pictures);
				ListView subtourListView = (ListView) activity.findViewById(R.id.tour_view_subtourlist);
				ListView commentListView = (ListView) activity.findViewById(R.id.tour_view_commentlist);
				ListView blogListView = (ListView) activity.findViewById(R.id.tour_view_bloglist);
				Gallery gallery = (Gallery) activity.findViewById(R.id.tour_view_gallery);

				nameTextView.setText(tour.getTourName());
				dateTextView.setText(DTOApi.dateFormat.format(tour.getBeginDate()) + " ~ " + DTOApi.dateFormat.format(tour.getEndDate()));
				statusTextView.setText(tour.getStatus());
				costTextView.setText("￥ " + String.valueOf(tour.getCost()) + "元");
				subtourTextView.setText(MessageFormat.format("行程景点({0})", tour.getSubtourList().size()));
				commTextView.setText(MessageFormat.format("留言({0})", tour.getCommentList().size()));
				picTextView.setText(MessageFormat.format("图片({0})", tour.getPictureList().size()));
				blogTextView.setText(MessageFormat.format("日志({0})", tour.getBlogList().size()));

				ViewGroup.LayoutParams params0 = subtourListView.getLayoutParams();
				params0.height = tour.getSubtourList().size() * 50;
				subtourListView.setLayoutParams(params0);
				SubtourAdapter subtourAdapter = new SubtourAdapter(activity, tour.getSubtourList());
				subtourListView.setAdapter(subtourAdapter);

				ViewGroup.LayoutParams params = commentListView.getLayoutParams();
				params.height = tour.getCommentList().size() * 60;
				commentListView.setLayoutParams(params);
				CommentAdapter commentAdapter = new CommentAdapter(activity, tour.getCommentList());
				commentListView.setAdapter(commentAdapter);

				ImageAdapter imageAdapter = new ImageAdapter(activity, tour.getPictureList());
				gallery.setAdapter(imageAdapter);

				ViewGroup.LayoutParams params2 = blogListView.getLayoutParams();
				params2.height = tour.getBlogList().size() * 60;
				blogListView.setLayoutParams(params2);
				BlogAdapter blogAdapter = new BlogAdapter(activity, tour.getBlogList());
				blogListView.setAdapter(blogAdapter);

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
