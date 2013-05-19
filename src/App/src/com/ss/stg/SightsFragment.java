package com.ss.stg;

import java.util.HashMap;
import java.util.List;

import com.ss.stg.dto.SightItem;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.AdapterView.OnItemLongClickListener;

public class SightsFragment extends Fragment implements AbsListView.OnItemClickListener, OnItemLongClickListener {

	private Handler handler = null;

	private OnSightsFragmentInteractionListener mListener;

	/**
	 * The fragment's ListView/GridView.
	 */
	private ListView mListView;

	/**
	 * The Adapter which will be used to populate the ListView/GridView with
	 * Views.
	 */
	private SightsAdapter mAdapter;

	/**
	 * Mandatory empty constructor for the fragment manager to instantiate the
	 * fragment (e.g. upon screen orientation changes).
	 */
	public SightsFragment() {
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		Log.d("MyLog", "SightsFragment_onCreate");

		super.onCreate(savedInstanceState);

		if (getArguments() != null) {
		}

		handler = new SightsHandler(getActivity());
		String userId = ((MainActivity) getActivity()).getLoginUserId();
		if (userId.equals("")) {
			WSThread thread = new WSThread(handler, IWebService.ID__GET_SIGHTS);
			thread.startWithProgressDialog(getActivity());
		} else {
			HashMap<String, Object> params = new HashMap<String, Object>();
			params.put(IWebService.PARAM__GET_SIGHTS_BY_USERID, userId);
			WSThread thread = new WSThread(handler, IWebService.ID__GET_SIGHTS_BY_USERID, params);
			thread.startWithProgressDialog(getActivity());
		}
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
		Log.d("MyLog", "SightsFragment_onCreateView");

		View view = inflater.inflate(R.layout.fragment_sights_list, container, false);

		// Set the adapter
		mListView = (ListView) view.findViewById(R.id.sights_list);

		// TextView tv = new TextView(getActivity());
		// tv.setText("Empty!");
		// mListView.setEmptyView(tv);

		// mListView.setAdapter(mAdapter);

		// Set OnItemClickListener so we can be notified on item clicks
		mListView.setOnItemClickListener(this);
		mListView.setOnItemLongClickListener(this);

		return view;
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnSightsFragmentInteractionListener) activity;
		} catch (ClassCastException e) {
			throw new ClassCastException(activity.toString() + " must implement OnTourFragmentInteractionListener");
		}
	}

	@Override
	public void onDetach() {
		super.onDetach();
		mListener = null;
	}

	@Override
	public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
		if (null != mListener) {
			// Notify the active callbacks interface (the activity, if the
			// fragment is attached to one) that an item has been selected.

			String id2 = mAdapter.getItem(position).getSightId();
			mListener.onSightsFragmentInteraction(id2);
		}
	}

	@Override
	public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {

		if (null != mListener) {
			final int pos = position;
			// final Context context = this.layoutInflater.getContext();
			final CharSequence[] items = { "浏览" };// , "编辑", "删除" };
			AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
			builder.setTitle("操作列表");
			builder.setItems(items, new DialogInterface.OnClickListener() {
				@Override
				public void onClick(DialogInterface dialog, int which) {
					switch (which) {

					// 浏览
					case 0:
						String id2 = mAdapter.getItem(pos).getSightId();
						mListener.onSightsFragmentInteraction(id2);
						break;

					// 编辑
					case 1:

						break;

					// 删除
					case 2:

						break;
					}
				}
			});
			AlertDialog alertDialog = builder.create();
			alertDialog.setView(null, 0, 0, 0, 0);
			alertDialog.show();
		}
		return false;
	}

	/**
	 * The default content for this Fragment has a TextView that is shown when
	 * the list is empty. If you would like to change the text, call this method
	 * to supply the text it should use.
	 */
	// public void setEmptyText(CharSequence emptyText) {
	// View emptyView = mListView.getEmptyView();
	//
	// if (emptyText instanceof TextView) {
	// ((TextView) emptyView).setText(emptyText);
	// }
	// }

	/**
	 * This interface must be implemented by activities that contain this
	 * fragment to allow an interaction in this fragment to be communicated to
	 * the activity and potentially other fragments contained in that activity.
	 * <p>
	 * See the Android Training lesson <a href=
	 * "https://developer.android.com/training/basics/fragments/communicating.html"
	 * >Communicating with Other Fragments</a> for more information.
	 */
	public interface OnSightsFragmentInteractionListener {
		public void onSightsFragmentInteraction(String id);
	}

	private class SightsHandler extends Handler {

		private Activity activity = null;

		private SightsHandler(Activity activity) {
			this.activity = activity;
		}

		@Override
		public void handleMessage(Message msg) {

			super.handleMessage(msg);

			if (msg.what == IWebService.ID__GET_SIGHTS || msg.what == IWebService.ID__GET_SIGHTS_BY_USERID) {
				List<SightItem> list = (List<SightItem>) msg.getData().getSerializable(IWebService.WS_RETURN);
				mAdapter = new SightsAdapter(activity, list);
				mListView.setAdapter(mAdapter);
				
				// Static Cache
				AppCache.setSightItems(list);
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
