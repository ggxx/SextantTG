package com.ss.stg;

import java.lang.ref.WeakReference;
import java.util.HashMap;

import com.ss.stg.dto.CommentItem;
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
import android.widget.Toast;

public class CommentEditActivity extends Activity {

	private Toast toast = null;
	private Handler handler = null;

	@Override
	protected void onCreate(Bundle savedInstanceState) {

		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_comment_edit);

		final String targetId = getIntent().getStringExtra("targetid");
		final String userId = getIntent().getStringExtra("userid");

		Button okButton = (Button) findViewById(R.id.comment_edit_ok);
		Button cancelButton = (Button) findViewById(R.id.comment_edit_cancel);
		final EditText contentEditText = (EditText) findViewById(R.id.comment_edit_content);

		okButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				if (contentEditText.getText().toString().equals("")) {
					toast = Toast.makeText(CommentEditActivity.this, "留言内容不能为空", Toast.LENGTH_SHORT);
					toast.show();
					return;
				}

				CommentItem commentItem = new CommentItem();
				commentItem.setCommentId("");
				commentItem.setComment(contentEditText.getText().toString());
				commentItem.setCommentUserName("");
				commentItem.setTargetId(targetId);
				commentItem.setUserId(userId);

				handler = new STGHandler(CommentEditActivity.this);
				HashMap<String, Object> params = new HashMap<String, Object>();
				params.put(IWebService.PARAM__INSERT_TOUR_COMMENT, commentItem);
				WSThread thread = new WSThread(handler, IWebService.ID__INSERT_TOUR_COMMENT, params);
				thread.startWithProgressDialog(CommentEditActivity.this);
			}
		});

		cancelButton.setOnClickListener(new OnClickListener() {

			@Override
			public void onClick(View v) {
				setResult(RESULT_CANCELED);
				finish();
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
			switch (msg.what) {
			case IWebService.ID__INSERT_TOUR_COMMENT:
				if (msg.getData().getBoolean(IWebService.WS_RETURN)) {
					Toast toast = Toast.makeText(refActivity.get(), "操作成功", Toast.LENGTH_SHORT);
					toast.show();
					refActivity.get().setResult(RESULT_OK);
					refActivity.get().finish();
				} else {
					Toast toast = Toast.makeText(refActivity.get(), "操作失败", Toast.LENGTH_SHORT);
					toast.show();
				}
				break;
			}
		}
	}
}
