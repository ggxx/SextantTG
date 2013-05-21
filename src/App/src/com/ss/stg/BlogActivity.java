package com.ss.stg;

import java.lang.ref.WeakReference;
import java.util.HashMap;

import com.ss.stg.dto.BlogObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.util.Log;
import android.widget.TextView;

public class BlogActivity extends Activity {

	private final static String TAG = "BlogActivity";
	private Handler handler = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_blog);

		final String blogId = getIntent().getStringExtra("blogid");
		handler = new STGHandler(this);
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_BLOG_BY_BLOGID, blogId);
		WSThread thread = new WSThread(handler, IWebService.ID__GET_BLOG_BY_BLOGID, params);
		thread.startWithProgressDialog(this);
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

			if (msg.what == IWebService.ID__GET_BLOG_BY_BLOGID) {

				BlogObject blog = (BlogObject) msg.getData().getSerializable(IWebService.WS_RETURN);
				
				Log.d(TAG, blog.getBlogId());
				
				TextView titleTextView = (TextView) activity.findViewById(R.id.blog_title);
				TextView contentTextView = (TextView) activity.findViewById(R.id.blog_content);

				titleTextView.setText(blog.getTitle());
				contentTextView.setText(blog.getContent());
			}
		}
	}
}
