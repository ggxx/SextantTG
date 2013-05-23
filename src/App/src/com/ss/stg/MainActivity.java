package com.ss.stg;

import java.util.ArrayList;
import java.util.List;

import com.ss.stg.LoginFragment.OnLoginFragmentInteractionListener;
import com.ss.stg.LoginFragment.OnLogoutFragmentInteractionListener;
import com.ss.stg.SightsFragment.OnSightsFragmentInteractionListener;
import com.ss.stg.ToursFragment.OnTourFragmentInteractionListener;
import com.ss.stg.dto.CityItem;
import com.ss.stg.dto.CountryItem;
import com.ss.stg.dto.ProvinceItem;
import com.ss.stg.dto.SightItem;
import com.ss.stg.dto.UserObject;
import com.ss.stg.ws2.IWebService;
import com.ss.stg.ws2.WSThread;

import android.app.ActionBar;
import android.app.ActionBar.Tab;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;
import android.os.Message;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentPagerAdapter;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.support.v4.view.ViewPager;

import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

public class MainActivity extends FragmentActivity implements ActionBar.TabListener, OnTourFragmentInteractionListener, OnSightsFragmentInteractionListener, OnLoginFragmentInteractionListener,
		OnLogoutFragmentInteractionListener {

	private String loginUserId = "";

	public String getLoginUserId() {
		return this.loginUserId;
	}

	/**
	 * The {@link android.support.v4.view.PagerAdapter} that will provide
	 * fragments for each of the sections. We use a
	 * {@link android.support.v4.app.FragmentPagerAdapter} derivative, which
	 * will keep every loaded fragment in memory. If this becomes too memory
	 * intensive, it may be best to switch to a
	 * {@link android.support.v4.app.FragmentStatePagerAdapter}.
	 */
	SectionsPagerAdapter mSectionsPagerAdapter;

	/**
	 * The {@link ViewPager} that will host the section contents.
	 */
	ViewPager mViewPager;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		// Set up the action bar.
		final ActionBar actionBar = getActionBar();
		actionBar.setNavigationMode(ActionBar.NAVIGATION_MODE_TABS);

		// Create the adapter that will return a fragment for each of the three
		// primary sections of the app.
		List<Fragment> fragments = new ArrayList<Fragment>();
		Fragment loginFragment = new LoginFragment();
		Fragment sightsfFragment = new SightsFragment();
		Fragment toursfragment = new ToursFragment();
		fragments.add(loginFragment);
		fragments.add(sightsfFragment);
		fragments.add(toursfragment);
		mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager(), fragments);

		// Set up the ViewPager with the sections adapter.
		mViewPager = (ViewPager) findViewById(R.id.pager);
		mViewPager.setOffscreenPageLimit(2);
		mViewPager.setAdapter(mSectionsPagerAdapter);

		// When swiping between different sections, select the corresponding
		// tab. We can also use ActionBar.Tab#select() to do this if we have
		// a reference to the Tab.
		mViewPager.setOnPageChangeListener(new ViewPager.SimpleOnPageChangeListener() {
			@Override
			public void onPageSelected(int position) {
				actionBar.setSelectedNavigationItem(position);
			}
		});

		// For each of the sections in the app, add a tab to the action bar.
		actionBar.addTab(actionBar.newTab().setText(R.string.tab_login).setTabListener(this));
		actionBar.addTab(actionBar.newTab().setText(R.string.tab_sights).setTabListener(this));
		actionBar.addTab(actionBar.newTab().setText(R.string.tab_tours).setTabListener(this));
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.main, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		switch (item.getItemId()) {
		case R.id.menu_main_addtour:
			if (loginUserId != null && !loginUserId.equals("")) {
				Intent intent = new Intent(this, TourEditActivity.class);
				intent.putExtra("userid", loginUserId);
				startActivity(intent);
			} else {
				Toast toast = Toast.makeText(this, "请先登录", Toast.LENGTH_SHORT);
				toast.show();
			}
			break;

		case R.id.menu_main_settings:
			Intent intent = new Intent(this, ConfigActivity.class);
			startActivity(intent);
			break;
		}
		return false;
	}

	@Override
	public void onTabReselected(Tab tab, android.app.FragmentTransaction ft) {
	}

	@Override
	public void onTabSelected(Tab tab, android.app.FragmentTransaction ft) {
		System.out.println("tabPosition=" + tab.getPosition());
		mViewPager.setCurrentItem(tab.getPosition());
	}

	@Override
	public void onTabUnselected(Tab tab, android.app.FragmentTransaction ft) {
	}

	/**
	 * A {@link FragmentPagerAdapter} that returns a fragment corresponding to
	 * one of the sections/tabs/pages.
	 */
	public class SectionsPagerAdapter extends FragmentStatePagerAdapter {

		private List<Fragment> fragments = null;

		public SectionsPagerAdapter(FragmentManager fm, List<Fragment> fragments) {
			super(fm);
			this.fragments = fragments;
		}

		@Override
		public int getCount() {
			if (this.fragments == null) {
				return 0;
			}
			return this.fragments.size();
		}

		@Override
		public Fragment getItem(int position) {
			System.out.println("SectionsPagerAdapter_getItem:" + position);
			return this.fragments.get(position);
		}

		@Override
		public Object instantiateItem(ViewGroup container, int position) {
			System.out.println("SectionsPagerAdapter_instantiateItem:" + position);
			return super.instantiateItem(container, position);
		}

		@Override
		public int getItemPosition(Object object) {
			return POSITION_NONE;
		}
	}

	@Override
	public void onTourFragmentInteraction(String id) {
		Intent intent = new Intent(this, TourActivity.class);
		intent.putExtra("tourid", id);
		intent.putExtra("userid", loginUserId);
		startActivity(intent);
	}

	@Override
	public void onSightsFragmentInteraction(String id) {
		Intent intent = new Intent(this, SightsActivity.class);
		intent.putExtra("sightsid", id);
		intent.putExtra("userid", loginUserId);
		startActivity(intent);
	}

	@Override
	public void onLoginFragmentInteraction(String id) {
		Log.d("MyLog", "LoginButtonClick");
		if (id != null && !id.trim().equals("")) {
			this.loginUserId = id;

			// 刷新页面缓存
			List<Fragment> fragments = new ArrayList<Fragment>();
			Fragment loginFragment = new LoginFragment();
			Fragment sightsfFragment = new SightsFragment();
			Fragment toursfragment = new ToursFragment();
			fragments.add(loginFragment);
			fragments.add(sightsfFragment);
			fragments.add(toursfragment);
			mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager(), fragments);
			mViewPager = (ViewPager) findViewById(R.id.pager);
			mViewPager.setOffscreenPageLimit(2);
			mViewPager.setAdapter(mSectionsPagerAdapter);
		}
	}

	@Override
	public void onLogoutFragmentInteraction() {
		Log.d("MyLog", "LogoutButtonClick");
		this.loginUserId = "";

		// 刷新页面缓存
		List<Fragment> fragments = new ArrayList<Fragment>();
		Fragment loginFragment = new LoginFragment();
		Fragment sightsfFragment = new SightsFragment();
		Fragment toursfragment = new ToursFragment();
		fragments.add(loginFragment);
		fragments.add(sightsfFragment);
		fragments.add(toursfragment);
		mSectionsPagerAdapter = new SectionsPagerAdapter(getSupportFragmentManager(), fragments);
		mViewPager = (ViewPager) findViewById(R.id.pager);
		mViewPager.setOffscreenPageLimit(2);
		mViewPager.setAdapter(mSectionsPagerAdapter);
	}

}
