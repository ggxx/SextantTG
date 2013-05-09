package com.ss.stg.ws2;

import java.io.Serializable;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;

import com.ss.stg.dto.*;

public class WSThread extends Thread {
	private Handler handler = null;
	private IWebService ws = null;
	private HashMap<String, Object> params = null;
	private int methodId = 0;
	private ProgressDialog progressDialog = null;

	// 构造函数
	public WSThread(Handler handler, int methodId, HashMap<String, Object> params) {
		this.handler = handler;
		this.methodId = methodId;
		this.params = params;
		this.ws = new WebService();
	}

	public WSThread(Handler handler, int methodId) {
		this.handler = handler;
		this.methodId = methodId;
		this.ws = new WebService();
	}

	public void startWithProgressDialog(Context context) {
		progressDialog = ProgressDialog.show(context, "提示", "正在加载数据，请稍后......", true);
		this.start();
	}

	@Override
	public void run() {
		super.run();
		System.out.println("启动线程----->" + Thread.currentThread().getId());
		callWebService();

		// 取消进度对话框
		if (progressDialog != null) {
			progressDialog.dismiss();
		}
	}

	// //调用webService
	private void callWebService() {

		Object returnObject = null;

		try {
			if (this.methodId == IWebService.ID__HELLO_WORLD) {
				returnObject = ws.helloWorld();
			} else if (this.methodId == IWebService.ID__LOGIN) {
				String loginName = this.params.get(IWebService.PARAM__LOGIN__LOGIN_NAME).toString();
				String password = this.params.get(IWebService.PARAM__LOGIN__PASSWORD).toString();
				returnObject = ws.login(loginName, password);
			} else {

			}

			if (returnObject != null) {
				Message message = handler.obtainMessage();
				message.what = methodId;
				Bundle bundle = new Bundle();
				bundle.putSerializable(IWebService.WS_RETURN, (Serializable) returnObject);
				message.setData(bundle);
				handler.sendMessage(message);
			} else {
				System.out.println("return result--->null");
			}
		} catch (Exception e) {
			Message message = handler.obtainMessage();
			Bundle bundle = new Bundle();
			message.what = IWebService.ID__ERROR;
			bundle.putString(IWebService.WS_RETURN, e.getMessage());
			message.setData(bundle);
			handler.sendMessage(message);
		}
	}
}
