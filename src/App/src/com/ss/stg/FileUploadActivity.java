package com.ss.stg;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.app.ListActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.Window;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.TextView;
import android.widget.AdapterView.OnItemClickListener;

public class FileUploadActivity extends ListActivity {

	private List<String> items = null;
	private List<String> paths = null;
	private String rootPath = "/";
	// private String curPath = "/";
	private String curFile = "";

	private TextView pathTextView;
	private Button comfirmButton;
	private Button cancelButton;

	// private final static String TAG = "bb";

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		requestWindowFeature(Window.FEATURE_NO_TITLE);
		setContentView(R.layout.activity_filelist);
		pathTextView = (TextView) findViewById(R.id.mPath);
		comfirmButton = (Button) findViewById(R.id.buttonConfirm);
		comfirmButton.setOnClickListener(new OnClickListener() {
			public void onClick(View v) {

				if (curFile.equals("")) {
					return;
				}

				Intent data = new Intent();
				Bundle bundle = new Bundle();
				bundle.putString("file", curFile);
				data.putExtras(bundle);
				setResult(RESULT_OK, data);
				finish();
			}
		});
		cancelButton = (Button) findViewById(R.id.buttonCancle);
		cancelButton.setOnClickListener(new OnClickListener() {
			public void onClick(View v) {
				setResult(RESULT_CANCELED);
				finish();
			}
		});

		setFileDir(rootPath);

		getListView().setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
				                
				File file = new File(paths.get(position));
				if (file.isDirectory()) {
					// curPath = paths.get(position);
					setFileDir(paths.get(position));
				} else {
					setFile(paths.get(position));
				}
				
				
				((FileAdapter)FileUploadActivity.this.getListAdapter()).setSelectedPosition(position);  
				((FileAdapter)FileUploadActivity.this.getListAdapter()).notifyDataSetChanged();
			}
		});
	}

	private void setFileDir(String filePath) {
		curFile = "";
		pathTextView.setText(filePath);
		items = new ArrayList<String>();
		paths = new ArrayList<String>();
		File f = new File(filePath);
		File[] files = f.listFiles();
		if (!filePath.equals(rootPath)) {
			items.add("b1");
			paths.add(rootPath);
			items.add("b2");
			paths.add(f.getParent());
		}
		if (files != null) {
			for (int i = 0; i < files.length; i++) {
				File file = files[i];
				items.add(file.getName());
				paths.add(file.getPath());
			}
		}
		setListAdapter(new FileAdapter(this, items, paths));
	}

	private void setFile(String file) {
		pathTextView.setText(file);
		curFile = file;
	}
}
