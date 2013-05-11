package com.ss.stg;

import android.view.View;
import android.widget.TextView;

public class CommentViewWrapper {
	private View view;
	private String id;
	private TextView commentTextView;
	private TextView userTextView;
	private TextView timeTextView;

	public CommentViewWrapper(View view) {
		this.view = view;
	}

	public String getId() {
		return id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public View getView() {
		return view;
	}

	public TextView getUserTextView() {
		if (this.userTextView == null) {
			this.userTextView = (TextView) this.view.findViewById(R.id.comment_item_user);
		}
		return this.userTextView;
	}

	public TextView getCommentTextView() {
		if (this.commentTextView == null) {
			this.commentTextView = (TextView) this.view.findViewById(R.id.comment_item_comment);
		}
		return this.commentTextView;
	}

	public TextView getTimeTextView() {
		if (this.timeTextView == null) {
			this.timeTextView = (TextView) this.view.findViewById(R.id.comment_item_time);
		}
		return this.timeTextView;
	}
}
