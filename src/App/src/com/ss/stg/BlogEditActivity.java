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
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

public class BlogEditActivity extends Activity {

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_blog_edit);

		final String tourId = getIntent().getStringExtra("tourid");
		final String subtourId = getIntent().getStringExtra("subtourid");
		final String sightId = getIntent().getStringExtra("sightid");
		final String userId = getIntent().getStringExtra("userid");

		final EditText titleEditText = (EditText) findViewById(R.id.blog_edit_title);
		final EditText contentEditText = (EditText) findViewById(R.id.blog_edit_content);
		final Button okButton = (Button) findViewById(R.id.blog_edit_ok);
		final Button cancelButton = (Button) findViewById(R.id.blog_edit_cancel);

		okButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				if (titleEditText.getText().toString().equals("") || contentEditText.getText().toString().equals("")) {
					Toast toast = Toast.makeText(BlogEditActivity.this, "题目和正文均不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}

				BlogObject blog = new BlogObject();
				blog.setAnthor(userId);
				blog.setBlogId("");
				blog.setContent(contentEditText.getText().toString());
				blog.setSightName("");
				blog.setSubtourName("");
				blog.setTitle(titleEditText.getText().toString());
				blog.setTourName("");
				blog.setSubtourId(subtourId);
				blog.setTourId(tourId);
				blog.setUserId(userId);
				blog.setSightId(sightId);

				Handler handler = new STGHandler(BlogEditActivity.this);
				HashMap<String, Object> params = new HashMap<String, Object>();
				params.put(IWebService.PARAM__INSERT_BLOG, blog);
				WSThread thread = new WSThread(handler, IWebService.ID__INSERT_BLOG, params);
				thread.startWithProgressDialog(BlogEditActivity.this);
			}
		});

		cancelButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				BlogEditActivity.this.setResult(RESULT_CANCELED);
				BlogEditActivity.this.finish();
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

			if (msg.what == IWebService.ID__INSERT_BLOG) {

				if (msg.getData().getBoolean(IWebService.WS_RETURN)) {
					Toast toast = Toast.makeText(activity, "保存完毕", Toast.LENGTH_SHORT);
					toast.show();
					activity.setResult(RESULT_OK);
					activity.finish();
				} else {
					Toast toast = Toast.makeText(activity, "保存失败", Toast.LENGTH_SHORT);
					toast.show();
				}
			}
		}
	}
}
