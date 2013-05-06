package com.ss.stg;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ListView;
import android.widget.SectionIndexer;

public class LettersSideBar extends View {
	private static final int TEXT_COLOR = 0xFFAAAAAA;
	private static final int BACKGROUND_COLOR = 0xAAF0F0F0;
	private static final int FOCUS_BACKGROUND_COLOR = 0xAACCEEEE;
	private static final char[] LETTERS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '#' };

	// private final int itemHeight = getMeasuredHeight() / 28;

	private SectionIndexer sectionIndexer = null;
	private ListView listView;

	public LettersSideBar(Context context) {
		super(context);
		init();
	}

	public LettersSideBar(Context context, AttributeSet attrs) {
		super(context, attrs);
		init();
	}

	public LettersSideBar(Context context, AttributeSet attrs, int defStyle) {
		super(context, attrs, defStyle);
		init();
	}

	private void init() {
		setBackgroundColor(LettersSideBar.BACKGROUND_COLOR);
	}

	public void setListView(ListView lv) {
		listView = lv;
		sectionIndexer = (SectionIndexer) lv.getAdapter();
	}

	@Override
	public boolean onTouchEvent(MotionEvent event) {
		super.onTouchEvent(event);
		int i = (int) event.getY();
		int idx = i / (getMeasuredHeight() / 28);

		if (idx >= LETTERS.length) {
			idx = LETTERS.length - 1;
		} else if (idx < 0) {
			idx = 0;
		}

		if (event.getAction() == MotionEvent.ACTION_DOWN || event.getAction() == MotionEvent.ACTION_MOVE) {
			this.setBackgroundColor(LettersSideBar.FOCUS_BACKGROUND_COLOR);

			if (sectionIndexer == null) {
				sectionIndexer = (SectionIndexer) listView.getAdapter();
			}
			int position = sectionIndexer.getPositionForSection(LETTERS[idx]);
			if (position == -1) {
				return true;
			}
			listView.setSelection(position);
		}

		if (event.getAction() == MotionEvent.ACTION_UP) {
			this.setBackgroundColor(LettersSideBar.BACKGROUND_COLOR);
		}

		return true;
	}

	protected void onDraw(Canvas canvas) {
		Paint paint = new Paint();
		paint.setColor(LettersSideBar.TEXT_COLOR);
		paint.setTextSize(getMeasuredHeight() / 28 - 4);
		paint.setTextAlign(Paint.Align.CENTER);
		float widthCenter = getMeasuredWidth() / 2;
		for (int i = 0; i < LETTERS.length; i++) {
			canvas.drawText(String.valueOf(LETTERS[i]), widthCenter, getMeasuredHeight() / 28 + (i * getMeasuredHeight() / 28), paint);
		}
		super.onDraw(canvas);
	}
}
