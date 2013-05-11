package com.ss.stg;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.ss.stg.dto.CommentItem;
import com.ss.stg.ws2.DTOApi;

public class CommentAdapter extends ArrayAdapter<CommentItem> {
	private LayoutInflater layoutInflater = null;
	private CommentViewWrapper commentViewWrapper = null;

	public CommentAdapter(Context context, List<CommentItem> objects) {
		super(context, R.id.comment_item_comment, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		CommentItem comment = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_comment_item, parent, false);
			commentViewWrapper = new CommentViewWrapper(convertView);
			convertView.setTag(commentViewWrapper);
		} else {
			commentViewWrapper = (CommentViewWrapper) convertView.getTag();
		}

		if (comment != null) {
			commentViewWrapper.setId(comment.getCommentId());
			commentViewWrapper.getCommentTextView().setText(comment.getComment());
			commentViewWrapper.getUserTextView().setText(comment.getCommentUserName());
			commentViewWrapper.getTimeTextView().setText(DTOApi.datetimeFormat.format(comment.getCreatingTime()));
		}
		return convertView;
	}
}
