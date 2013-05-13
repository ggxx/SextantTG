package com.ss.stg;

import java.util.List;
import com.ss.stg.dto.PictureItem;
import android.content.Context;
import android.graphics.drawable.Drawable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

public class ImageAdapter extends ArrayAdapter<PictureItem> {

	LayoutInflater layoutInflater;
	private ImageViewWrapper imageViewWrapper = null;

	public ImageAdapter(Context context, List<PictureItem> list) {
		super(context, R.id.image_item_desc, list);
		this.layoutInflater = LayoutInflater.from(context);
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {

		PictureItem pictureItem = getItem(position);

		if (convertView == null) {
			convertView = this.layoutInflater.inflate(R.layout.layout_image_item, parent, false);
			imageViewWrapper = new ImageViewWrapper(convertView);
			convertView.setTag(imageViewWrapper);
		} else {
			imageViewWrapper = (ImageViewWrapper) convertView.getTag();
		}

		if (pictureItem != null) {
			imageViewWrapper.setId(pictureItem.getPictureId());
			imageViewWrapper.getTextView().setText(pictureItem.getDescription());
			//imageViewWrapper.getTextView().setCompoundDrawables(null, Drawable.createFromPath(pictureItem.getPath()), null, null);
			imageViewWrapper.getImageView().setImageBitmap(pictureItem.getBitmap());
			//imageViewWrapper.getImageView().setContentDescription(pictureItem.getDescription());
		}
		return convertView;
	}
}
