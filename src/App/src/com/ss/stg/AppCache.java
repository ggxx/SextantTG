package com.ss.stg;

import java.util.ArrayList;
import java.util.List;

import android.widget.ArrayAdapter;

import com.ss.stg.dto.CountryItem;
import com.ss.stg.dto.ProvinceItem;
import com.ss.stg.dto.CityItem;
import com.ss.stg.dto.SightItem;

public class AppCache {
	private static List<CountryItem> countryItems;
	private static List<ProvinceItem> provinceItems;
	private static List<CityItem> cityItems;
	private static List<SightItem> sightItems;

	public static List<CountryItem> getCountryItems() {
		return countryItems;
	}

	public static void setCountryItems(List<CountryItem> countryItems) {
		AppCache.countryItems = countryItems;
	}

	public static List<ProvinceItem> getProvinceItems() {
		return provinceItems;
	}

	public static void setProvinceItems(List<ProvinceItem> provinceItems) {
		AppCache.provinceItems = provinceItems;
	}

	public static List<CityItem> getCityItems() {
		return cityItems;
	}

	public static void setCityItems(List<CityItem> cityItems) {
		AppCache.cityItems = cityItems;
	}

	public static List<SightItem> getSightItems() {
		return sightItems;
	}

	public static void setSightItems(List<SightItem> sightItems) {
		AppCache.sightItems = sightItems;
	}

	public static List<ProvinceItem> getProvinceByCountry(String countryId) {
		if (provinceItems != null) {
			List<ProvinceItem> items = new ArrayList<ProvinceItem>();
			for (ProvinceItem item : provinceItems) {
				if (item.getCountryId().equals(countryId)) {
					items.add(item);
				}
			}
			return items;
		}
		return null;
	}

	public static List<CityItem> getCityByProvince(String provinceId) {
		if (cityItems != null) {
			List<CityItem> items = new ArrayList<CityItem>();
			for (CityItem item : cityItems) {
				if (item.getProvinceId().equals(provinceId)) {
					items.add(item);
				}
			}
			return items;
		}
		return null;
	}

	public static List<SightItem> getSightByCity(String cityId) {
		if (sightItems != null) {
			List<SightItem> items = new ArrayList<SightItem>();
			for (SightItem item : sightItems) {
				if (item.getCityId().equals(cityId)) {
					items.add(item);
				}
			}
			return items;
		}
		return null;
	}
	
	

}
