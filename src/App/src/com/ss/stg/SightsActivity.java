package com.ss.stg;

import java.text.MessageFormat;
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
import android.view.ViewGroup;
import android.view.ViewGroup.MarginLayoutParams;
import android.widget.AbsListView;
import android.widget.Gallery;
import android.widget.ListView;
import android.widget.RatingBar;
import android.widget.Toast;
import android.widget.RatingBar.OnRatingBarChangeListener;
import android.widget.TextView;

public class SightsActivity extends Activity {

	private Toast toast = null;
	private Handler handler = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_sights);

		String sightsId = getIntent().getStringExtra("sightsid");
		String userId = getIntent().getStringExtra("userid");

		handler = new STGHandler(this);

		HashMap<String, Object> params = new HashMap<String, Object>();

		WSThread thread = null;
		if (userId != null && !userId.equals("")) {
			params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__SIGHTID, sightsId);
			params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__USERID, userId);
			thread = new WSThread(handler, IWebService.ID__GET_SIGHT_BY_SIGHTID_AND_USERID, params);
		} else {
			params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID, sightsId);
			thread = new WSThread(handler, IWebService.ID__GET_SIGHT_BY_SIGHTID, params);
		}
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

			if (msg.what == IWebService.ID__GET_SIGHT_BY_SIGHTID || msg.what == IWebService.ID__GET_SIGHT_BY_SIGHTID_AND_USERID) {
				SightObject sights = (SightObject) msg.getData().getSerializable(IWebService.WS_RETURN);
				TextView nameTextView = (TextView) findViewById(R.id.sights_view_name);
				TextView cityTextView = (TextView) findViewById(R.id.sights_view_city);
				TextView descTextView = (TextView) findViewById(R.id.sights_view_desc);
				TextView starTextView = (TextView) findViewById(R.id.sights_view_stars);
				TextView blogTextView = (TextView) findViewById(R.id.sights_view_blogs);
				// TextView mystarsTextView = (TextView)
				// findViewById(R.id.sights_view_mystars);
				RatingBar ratingBar = (RatingBar) findViewById(R.id.sights_view_ratingBar);
				TextView commTextView = (TextView) findViewById(R.id.sights_view_comments);
				ListView commentListView = (ListView) findViewById(R.id.sights_view_commentlist);
				ListView blogListView = (ListView) findViewById(R.id.sights_view_bloglist);
				TextView picTextView = (TextView) findViewById(R.id.sights_view_pictures);
				Gallery gallery = (Gallery) findViewById(R.id.sights_view_gallery);

				starTextView.setText(String.valueOf(sights.getStars()));
				nameTextView.setText(MessageFormat.format("{0}({1})", sights.getSightsName(), sights.getSightsLevel()));
				cityTextView.setText(MessageFormat.format("{0}-{1}-{2}", sights.getCountryName(), sights.getProvinceName(), sights.getCityName()));
				descTextView.setText(sights.getDescription());
				ratingBar.setRating(sights.getMyStar());
				ratingBar.setOnRatingBarChangeListener(new OnRatingBarChangeListener() {

					@Override
					public void onRatingChanged(RatingBar ratingBar, float rating, boolean fromUser) {
						// TODO Auto-generated method stub
						if (fromUser) {
							toast = Toast.makeText(SightsActivity.this, "评分成功" + rating, Toast.LENGTH_SHORT);
							toast.show();
						}
					}
				});
				// mystarsTextView.setText(String.valueOf(sights.getMyStar()));

				commTextView.setText(MessageFormat.format("留言({0})", sights.getCommentList().size()));

				ViewGroup.LayoutParams params = commentListView.getLayoutParams();
				params.height = sights.getCommentList().size() * 60;
				commentListView.setLayoutParams(params);

				CommentAdapter commentAdapter = new CommentAdapter(activity, sights.getCommentList());
				commentListView.setAdapter(commentAdapter);

				picTextView.setText(MessageFormat.format("图片({0})", sights.getPictureList().size()));
				ImageAdapter imageAdapter = new ImageAdapter(activity, sights.getPictureList());
				gallery.setAdapter(imageAdapter);

				blogTextView.setText(MessageFormat.format("日志({0})", sights.getBlogList().size()));
				ViewGroup.LayoutParams params2 = blogListView.getLayoutParams();
				params2.height = sights.getBlogList().size() * 60;
				blogListView.setLayoutParams(params2);

				BlogAdapter blogAdapter = new BlogAdapter(activity, sights.getBlogList());
				blogListView.setAdapter(blogAdapter);

				// gallery.setAdapter(imageAdapter);
				// gallery.setOnItemSelectedListener((SightsActivity) activity);
				// imageSwitcher = (ImageSwitcher)
				// findViewById(R.id.sights_view_imageswitcher);
				// 设置ImageSwitcher组件的工厂对象
				// imageSwitcher.setFactory((SightsActivity) activity);
				// 设置ImageSwitcher组件显示图像的动画效果
				// imageSwitcher.setInAnimation(AnimationUtils.loadAnimation(activity,
				// android.R.anim.fade_in));
				// imageSwitcher.setOutAnimation(AnimationUtils.loadAnimation(activity,
				// android.R.anim.fade_out));

				// int totalHeight = 0;
				// for (int i = 0; i < commentAdapter.getCount(); i++) {
				// View listItem = commentAdapter.getView(i, null,
				// commentListView);
				// listItem.measure(0, 0);
				// totalHeight += listItem.getMeasuredHeight();
				// }
				//
				// ViewGroup.LayoutParams params =
				// commentListView.getLayoutParams();
				//
				// params.height = totalHeight +
				// commentListView.getDividerHeight() *
				// (commentAdapter.getCount() - 1);
				// ((MarginLayoutParams) params).setMargins(10, 10, 10, 10);
				// commentListView.setLayoutParams(params);

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
