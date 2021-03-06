package com.ss.stg.ws2;

import java.text.MessageFormat;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map.Entry;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import com.ss.stg.AppConfig;
import com.ss.stg.dto.*;

public class WebService implements IWebService {

	public WebService() {

	}

	private static final String WS_NAMESPACE = "http://github.com/ggxx/SextantTG/";
	// private static final String WS_URL =
	// "http://192.168.137.1:19867/WS2.asmx";

	private static final String WS_URL = MessageFormat.format("http://{0}:{1}/{2}", AppConfig.SERVICE_IP, AppConfig.SERVICE_PORT, AppConfig.SERVICE_ASMX);

	private String getMethodName(int methodId) {
		if (methodId == IWebService.ID__HELLO_WORLD) {
			return IWebService.METHOD__HELLO_WORLD;
		} else if (methodId == IWebService.ID__LOGIN) {
			return IWebService.METHOD__LOGIN;
		} else if (methodId == IWebService.ID__GET_BLOG_BY_BLOGID) {
			return IWebService.METHOD__GET_BLOG_BY_BLOGID;
		} else if (methodId == IWebService.ID__GET_PICTURE_BY_PICTUREID) {
			return IWebService.METHOD__GET_PICTURE_BY_PICTUREID;
		} else if (methodId == IWebService.ID__GET_SIGHT_BY_SIGHTID) {
			return IWebService.METHOD__GET_SIGHT_BY_SIGHTID;
		} else if (methodId == IWebService.ID__GET_SIGHT_BY_SIGHTID_AND_USERID) {
			return IWebService.METHOD__GET_SIGHT_BY_SIGHTID_AND_USERID;
		} else if (methodId == IWebService.ID__GET_SIGHTS) {
			return IWebService.METHOD__GET_SIGHTS;
		} else if (methodId == IWebService.ID__GET_SIGHTS_BY_USERID) {
			return IWebService.METHOD__GET_SIGHTS_BY_USERID;
		} else if (methodId == IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID) {
			return IWebService.METHOD__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID;
		} else if (methodId == IWebService.ID__GET_TOUR_BY_TOURID) {
			return IWebService.METHOD__GET_TOUR_BY_TOURID;
		} else if (methodId == IWebService.ID__GET_TOURS_BY_USERID) {
			return IWebService.METHOD__GET_TOURS_BY_USERID;
		} else if (methodId == IWebService.ID__REGIST) {
			return IWebService.METHOD__REGIST;
		} else if (methodId == IWebService.ID__GET_COUNTRIES) {
			return IWebService.METHOD__GET_COUNTRIES;
		} else if (methodId == IWebService.ID__GET_PROVINCES) {
			return IWebService.METHOD__GET_PROVINCES;
		} else if (methodId == IWebService.ID__GET_CITIES) {
			return IWebService.METHOD__GET_CITIES;
		} else if (methodId == IWebService.ID__SAVE_TOUR) {
			return IWebService.METHOD__SAVE_TOUR;
		} else if (methodId == IWebService.ID__UPLOAD_PICTURE) {
			return IWebService.METHOD__UPLOAD_PICTURE;
		} else if (methodId == IWebService.ID__INSERT_TOUR_COMMENT) {
			return IWebService.METHOD__INSERT_TOUR_COMMENT;
		} else if (methodId == IWebService.ID__INSERT_BLOG) {
			return IWebService.METHOD__INSERT_BLOG;
		} else {
			return "";
		}
	}

	private SoapObject GetSoapResponse(int methodId, HashMap<String, Object> params) {
		try {
			String methodName = getMethodName(methodId);
			if (methodName.equals("")) {
				return null;
			}
			String soapAction = WS_NAMESPACE + methodName;
			SoapObject request = new SoapObject(WS_NAMESPACE, methodName);

			if (params != null) {
				Iterator<Entry<String, Object>> iter = params.entrySet().iterator();
				while (iter.hasNext()) {
					Entry<String, Object> entry = iter.next();
					request.addProperty(entry.getKey(), entry.getValue());
					System.out.println("访问WebService参数---->" + entry.getKey() + " : " + entry.getValue());
				}
			}

			SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
			envelope.dotNet = true;
			envelope.setOutputSoapObject(request);
			HttpTransportSE androidHttpTransport = new HttpTransportSE(WS_URL);

			System.out.println("访问WebService---->" + WS_URL + "?" + methodName);

			androidHttpTransport.call(soapAction, envelope); // 调用web service
			SoapObject response = (SoapObject) envelope.getResponse();

			if (response != null) {
				System.out.println("WebService返回---->" + response.toString());

				response = (SoapObject) response.getProperty(0);
				String msg = response.getPropertySafelyAsString("Message");
				if (!msg.equals("") && !msg.equals("anyType{}")) {
					System.out.println("WebService内部业务发生错误---->" + msg);
					return null;
				}
				return (SoapObject) response.getProperty(1);
			} else {
				System.out.println("WebService返回空值");
				return null;
			}
		} catch (Exception ex) {
			System.out.println("访问WebService错误---->" + ex.getMessage());
			return null;
		}
	}

	@Override
	public String helloWorld() {

		SoapObject response = GetSoapResponse(IWebService.ID__HELLO_WORLD, null);
		if (response != null) {
			return DTOApi.parseString(response);
		} else {
			return null;
		}
	}

	@Override
	public UserObject login(String loginName, String password) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__LOGIN__LOGIN_NAME, loginName);
		params.put(IWebService.PARAM__LOGIN__PASSWORD, password);

		SoapObject response = GetSoapResponse(IWebService.ID__LOGIN, params);
		if (response != null) {
			return DTOApi.parseUserObject(response);
		} else {
			return null;
		}
	}

	@Override
	public boolean regist(UserObject user, String password) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__REGIST__USER, DTOApi.convertToString(user));
		params.put(IWebService.PARAM__REGIST__PASSWORD, password);

		SoapObject response = GetSoapResponse(IWebService.ID__REGIST, params);
		if (response != null) {
			return DTOApi.parseBoolean(response);
		} else {
			return false;
		}
	}

	@Override
	public List<SightItem> getSights() {
		SoapObject response = GetSoapResponse(IWebService.ID__GET_SIGHTS, null);
		if (response != null) {
			return DTOApi.parseSightItems(response);
		} else {
			return null;
		}
	}

	@Override
	public List<SightItem> getSightsByUserId(String userId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_SIGHTS_BY_USERID, userId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_SIGHTS_BY_USERID, params);
		if (response != null) {
			return DTOApi.parseSightItems(response);
		} else {
			return null;
		}
	}

	@Override
	public List<TourItem> getToursByUserId(String userId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_TOURS_BY_USERID, userId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_TOURS_BY_USERID, params);
		if (response != null) {
			return DTOApi.parseTourItems(response);
		} else {
			return null;
		}
	}

	@Override
	public SightObject getSightBySightId(String sightId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID, sightId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_SIGHT_BY_SIGHTID, params);
		if (response != null) {
			return DTOApi.parseSightObject(response);
		} else {
			return null;
		}
	}

	@Override
	public SightObject getSightBySightIdAndUserId(String sightId, String userId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__SIGHTID, sightId);
		params.put(IWebService.PARAM__GET_SIGHT_BY_SIGHTID_AND_USERID__USERID, userId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_SIGHT_BY_SIGHTID_AND_USERID, params);
		if (response != null) {
			return DTOApi.parseSightObject(response);
		} else {
			return null;
		}
	}

	@Override
	public PictureObject getPictureByPictureId(String pictureId) {
		// TODO Auto-generated method stub
		return null;
	}

	@Override
	public BlogObject getBlogByBlogId(String blogId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_BLOG_BY_BLOGID, blogId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_BLOG_BY_BLOGID, params);
		if (response != null) {
			return DTOApi.parseBlogObject(response);
		} else {
			return null;
		}
	}

	@Override
	public TourObject getTourByTourId(String tourId) {

		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_TOUR_BY_TOURID, tourId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_TOUR_BY_TOURID, params);
		if (response != null) {
			return DTOApi.parseTourObject(response);
		} else {
			return null;
		}
	}

	@Override
	public SubtourObject getSubtourByTourIdAndSubtourId(String tourId, String subtourId) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__TOURID, tourId);
		params.put(IWebService.PARAM__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID__SUBTOURID, subtourId);

		SoapObject response = GetSoapResponse(IWebService.ID__GET_SUBTOUR_BY_TOURID_AND_SUBTOURID, params);
		if (response != null) {
			return DTOApi.parseSubtourObject(response);
		} else {
			return null;
		}
	}

	@Override
	public List<CountryItem> getCountries() {
		SoapObject response = GetSoapResponse(IWebService.ID__GET_COUNTRIES, null);
		if (response != null) {
			return DTOApi.parseCountryItems(response);
		} else {
			return null;
		}
	}

	@Override
	public List<ProvinceItem> getProvinces() {
		SoapObject response = GetSoapResponse(IWebService.ID__GET_PROVINCES, null);
		if (response != null) {
			return DTOApi.parseProvinceItems(response);
		} else {
			return null;
		}
	}

	@Override
	public List<CityItem> getCities() {
		SoapObject response = GetSoapResponse(IWebService.ID__GET_CITIES, null);
		if (response != null) {
			return DTOApi.parseCityItems(response);
		} else {
			return null;
		}
	}

	@Override
	public boolean saveTour(TourObject tour, List<SubtourItem> subtourItems, List<SubtourItem> removedSubtourItems) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__SAVE_TOUR__TOUR, DTOApi.convertToString(tour));
		params.put(IWebService.PARAM__SAVE_TOUR__SUBTOURS, DTOApi.convertToString(subtourItems));
		params.put(IWebService.PARAM__SAVE_TOUR__REMOVED_SUBTOURS, DTOApi.convertToString(removedSubtourItems));

		SoapObject response = GetSoapResponse(IWebService.ID__SAVE_TOUR, params);
		if (response != null) {
			return DTOApi.parseBoolean(response);
		} else {
			return false;
		}
	}

	@Override
	public boolean uploadPicture(PictureItem picture, String base64code) {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean insertTourComment(CommentItem comment) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__INSERT_TOUR_COMMENT, DTOApi.convertToString(comment));

		SoapObject response = GetSoapResponse(IWebService.ID__INSERT_TOUR_COMMENT, params);
		if (response != null) {
			return DTOApi.parseBoolean(response);
		} else {
			return false;
		}
	}

	@Override
	public boolean insertBlog(BlogObject blog) {
		HashMap<String, Object> params = new HashMap<String, Object>();
		params.put(IWebService.PARAM__INSERT_BLOG, DTOApi.convertToString(blog));

		SoapObject response = GetSoapResponse(IWebService.ID__INSERT_BLOG, params);
		if (response != null) {
			return DTOApi.parseBoolean(response);
		} else {
			return false;
		}
	}

}
