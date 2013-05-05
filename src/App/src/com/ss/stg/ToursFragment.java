package com.ss.stg;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AbsListView;
import android.widget.AdapterView;
import android.widget.ListView;

import com.ss.stg.R;
import com.ss.stg.model.Tour;

/**
 * A fragment representing a list of Items.
 * <p />
 * Large screen devices (such as tablets) are supported by replacing the
 * ListView with a GridView.
 * <p />
 * Activities containing this fragment MUST implement the {@link Callbacks}
 * interface.
 */
public class ToursFragment extends Fragment implements AbsListView.OnItemClickListener {

	private OnTourFragmentInteractionListener mListener;

	/**
	 * The fragment's ListView/GridView.
	 */
	private ListView mListView;

	/**
	 * The Adapter which will be used to populate the ListView/GridView with
	 * Views.
	 */
	private ToursAdapter mAdapter;

	/**
	 * Mandatory empty constructor for the fragment manager to instantiate the
	 * fragment (e.g. upon screen orientation changes).
	 */
	public ToursFragment() {
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);

		if (getArguments() != null) {
		}

		// TODO: Change Adapter to display your content
		List<Tour> list = new ArrayList<Tour>();
		Tour t1 = new Tour();
		t1.setTourId("111");
		t1.setTourName("123123");
		list.add(t1);
		Tour t2 = new Tour();
		t2.setTourId("122");
		t2.setTourName("2222222");
		list.add(t2);
		Tour t3 = new Tour();
		t3.setTourId("333");
		t3.setTourName("3333333");
		list.add(t3);

		mAdapter = new ToursAdapter(getActivity(), list);
	}

	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
		View view = inflater.inflate(R.layout.fragment_tours_list, container, false);

		// Set the adapter
		mListView = (ListView) view.findViewById(R.id.tours_list);
		mListView.setAdapter(mAdapter);

		// Set OnItemClickListener so we can be notified on item clicks
		mListView.setOnItemClickListener(this);

		return view;
	}

	@Override
	public void onAttach(Activity activity) {
		super.onAttach(activity);
		try {
			mListener = (OnTourFragmentInteractionListener) activity;
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

			String id2 = mAdapter.getItem(position).getTourId();

			mListener.onTourFragmentInteraction(id2);
		}
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
	public interface OnTourFragmentInteractionListener {
		// TODO: Update argument type and name
		public void onTourFragmentInteraction(String id);
	}

}
