package com.ss.stg;

import android.app.Activity;
import android.content.SharedPreferences;

public class AppConfig {

	public static final String CONFIG_NAME = "COM__SS_STG_CONFIG";

	public static String SERVICE_IP = "10.0.2.2";
	public static String SERVICE_ASMX = "WS2.asmx";
	public static String SERVICE_PORT = "1153";

	public static void InitConfig(Activity activity) {
		SharedPreferences sharedPreferences = activity.getSharedPreferences(AppConfig.CONFIG_NAME, Activity.MODE_PRIVATE);
		SERVICE_IP = sharedPreferences.getString("service_ip", SERVICE_IP);
		SERVICE_ASMX = sharedPreferences.getString("service_port", SERVICE_ASMX);
		SERVICE_PORT = sharedPreferences.getString("service_asmx", SERVICE_PORT);
	}
}