package com.ss.stg;

import android.app.Dialog;
import android.os.Bundle;
import android.support.v4.app.DialogFragment;

public class MainDialog extends DialogFragment {

	public static MainDialog newInstance(int title) {
		MainDialog frag = new MainDialog();
		Bundle args = new Bundle();
		args.putInt("title", title);
		frag.setArguments(args);
		return frag;
	}

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
	}

//	@Override
//	public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
//		View v = inflater.inflate(R.layout.fragment_dialog, container, false);
//		View tv = v.findViewById(R.id.text);
//		((TextView) tv).setText("Dialog #" + mNum + ": using style " + getNameForNum(mNum));
//
//		// Watch for button clicks.
//		Button button = (Button) v.findViewById(R.id.show);
//		button.setOnClickListener(new OnClickListener() {
//			public void onClick(View v) {
//				// When button is clicked, call up to owning activity.
//				((FragmentDialog) getActivity()).showDialog();
//			}
//		});
//
//		return v;
//	}
//
//	@Override
//	public Dialog onCreateDialog(Bundle savedInstanceState) {
//		int title = getArguments().getInt("title");
//
//		return new AlertDialog.Builder(getActivity()).setIcon(R.drawable.alert_dialog_icon).setTitle(title).setPositiveButton(R.string.alert_dialog_ok, new DialogInterface.OnClickListener() {
//			public void onClick(DialogInterface dialog, int whichButton) {
//				((FragmentAlertDialog) getActivity()).doPositiveClick();
//			}
//		}).setNegativeButton(R.string.alert_dialog_cancel, new DialogInterface.OnClickListener() {
//			public void onClick(DialogInterface dialog, int whichButton) {
//				((FragmentAlertDialog) getActivity()).doNegativeClick();
//			}
//		}).create();
//	}

}
