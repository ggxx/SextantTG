package com.ss.stg.ws2;

import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.UUID;

import android.util.Base64;
import android.util.Log;

public class UploadUtil {
	private static final String TAG = "UploadUtil";
	private static final int TIME_OUT = 10 * 1000; // 超时时间
	private static final String CHARSET = "utf-8"; // 设置编码

	public static String test(File file, String _url) {
		HttpURLConnection con;
		URL url;
		String httpUrl = _url;// "http://192.168.0.105/TUISONG/Service.asmx";
		InputStream in;
		byte[] buf = new byte[1024];

		try {
			in = new FileInputStream(file);
			url = new URL(httpUrl);
			con = (HttpURLConnection) url.openConnection();
			con.setConnectTimeout(20000);
			con.setReadTimeout(12000);
			con.setRequestMethod("POST");
			con.setDoOutput(true);
			con.setDoInput(true);

			OutputStream osw = con.getOutputStream();
			while (in.read(buf) != -1) {
				osw.write(buf);
			}
			osw.flush();
			osw.close();
			in.close();
			int code = con.getResponseCode();
			System.out.println("code:" + code);

		} catch (Exception e) {
			e.printStackTrace();
		}
		return "";
	}

	/**
	 * android上传文件到服务器
	 * 
	 * @param file
	 *            需要上传的文件
	 * @param RequestURL
	 *            请求的rul
	 * @return 返回响应的内容
	 */
	public static String uploadFile(File file, String RequestURL) {

		Log.d(TAG, file.getPath() + file.getName() + "~~~" + RequestURL);

		String result = null;
		String BOUNDARY = UUID.randomUUID().toString(); // 边界标识 随机生成
		String PREFIX = "--", LINE_END = "\r\n";
		String CONTENT_TYPE = "multipart/form-data"; // 内容类型

		try {

			Log.d(TAG, "start uploadFile Function");

			URL url = new URL(RequestURL);
			HttpURLConnection conn = (HttpURLConnection) url.openConnection();
			conn.setReadTimeout(TIME_OUT);
			conn.setConnectTimeout(TIME_OUT);
			conn.setDoInput(true); // 允许输入流
			conn.setDoOutput(true); // 允许输出流
			conn.setUseCaches(false); // 不允许使用缓存
			conn.setRequestMethod("POST"); // 请求方式
			conn.setRequestProperty("Charset", CHARSET); // 设置编码
			conn.setRequestProperty("connection", "keep-alive");
			conn.setRequestProperty("Content-Type", CONTENT_TYPE + ";boundary=" + BOUNDARY);

			Log.d(TAG, "10%");

			if (file != null) {

				Log.d(TAG, "20%");

				/**
				 * 当文件不为空，把文件包装并且上传
				 */
				DataOutputStream dos = new DataOutputStream(conn.getOutputStream());
				StringBuffer sb = new StringBuffer();
				sb.append(PREFIX);
				sb.append(BOUNDARY);
				sb.append(LINE_END);
				/**
				 * 这里重点注意： name里面的值为服务器端需要key 只有这个key 才可以得到对应的文件
				 * filename是文件的名字，包含后缀名的 比如:abc.png
				 */

				Log.d(TAG, "30%");

				sb.append("Content-Disposition: form-data; name=\"img\"; filename=\"" + file.getName() + "\"" + LINE_END);
				sb.append("Content-Type: application/octet-stream; charset=" + CHARSET + LINE_END);
				sb.append(LINE_END);
				dos.write(sb.toString().getBytes());
				InputStream is = new FileInputStream(file);

				Log.d(TAG, "40%");

				byte[] bytes = new byte[1024];
				int len = 0;
				while ((len = is.read(bytes)) != -1) {
					dos.write(bytes, 0, len);
				}

				Log.d(TAG, "50%");

				is.close();
				dos.write(LINE_END.getBytes());
				byte[] end_data = (PREFIX + BOUNDARY + PREFIX + LINE_END).getBytes();
				dos.write(end_data);
				dos.flush();

				Log.d(TAG, "60%");

				/**
				 * 获取响应码 200=成功 当响应成功，获取响应的流
				 */
				int res = conn.getResponseCode();
				Log.d(TAG, "response code:" + res);
				if (res == 200) {
					Log.d(TAG, "request success");
					InputStream input = conn.getInputStream();
					StringBuffer sb1 = new StringBuffer();
					int ss;
					while ((ss = input.read()) != -1) {
						sb1.append((char) ss);
					}
					result = sb1.toString();
					Log.d(TAG, "result : " + result);
				} else {
					Log.d(TAG, "request error");
				}
			} else {
				Log.d(TAG, "file is null!");
			}
		} catch (MalformedURLException e) {
			Log.d(TAG, "error" + e.getMessage());
			// e.printStackTrace();
		} catch (IOException e) {
			Log.d(TAG, "error" + e.getMessage());
			// e.printStackTrace();
		}
		return result;
	}

	public static String getBase64Code(String path) {
		try {
			File file = new File(path);
			FileInputStream inputFile = new FileInputStream(file);
			byte[] buffer = new byte[(int) file.length()];
			inputFile.read(buffer);
			inputFile.close();
			return ""+Base64.encodeToString(buffer, Base64.DEFAULT).length();
		} catch (Exception e) {
			return "";
		}
	}

}
