package com.ss.stg;

import java.util.List;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import com.ss.stg.dto.BlogItem;
import com.ss.stg.ws2.DTOApi;

public class BlogAdapter extends ArrayAdapter<BlogItem> {

	private LayoutInflater layoutInflater = null;
	private BlogViewWrapper viewWrapper = null;

	public BlogAdapter(Context context, List<BlogItem> objects) {
		super(context, R.id.comment_item_comment, objects);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		BlogItem blog = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_blog_item, parent, false);
			viewWrapper = new BlogViewWrapper(convertView);
			convertView.setTag(viewWrapper);
		} else {
			viewWrapper = (BlogViewWrapper) convertView.getTag();
		}

		if (blog != null) {
			viewWrapper.setId(blog.getBlogId());
			viewWrapper.getTitleTextView().setText(blog.getTitle());
			viewWrapper.getUserTextView().setText(blog.getAnthor());
			viewWrapper.getTimeTextView().setText(DTOApi.datetimeFormat.format(blog.getCreatingTime()));
		}
		return convertView;
	}
}
