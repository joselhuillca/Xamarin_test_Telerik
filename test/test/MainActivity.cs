using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Com.Telerik.Widget.List;
using System.Collections.Generic;
using Android.Graphics;

namespace test
{
	[Activity (Label = "test", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		private RadListView listView;
		private SlideLayoutManager slideLayoutManager;
		private CityAdapter adapter;
		private View rootView;

		private List<City> GetListOfCities() {
			List<City> cities = new List<City> ();
			cities.Add (new City ("London", "United Kingdom"));
			cities.Add (new City ("Berlin", "Germany"));
			cities.Add (new City ("Madrid", "Spain"));
			cities.Add (new City ("Rome", "Italy"));
			cities.Add (new City ("Paris", "France"));
			cities.Add (new City ("Hamburg", "Germany"));
			cities.Add (new City ("Barcelona", "Spain"));
			cities.Add (new City ("Munich", "Germany"));
			cities.Add (new City ("Milan", "Italy"));
			cities.Add (new City ("Cologne", "Germany"));
			return cities;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			listView = FindViewById<RadListView> (Resource.Id.listView);

			ListViewAdapter listViewAdapter = new ListViewAdapter (GetListOfCities ());
			listView.SetAdapter (listViewAdapter);

			adapter = new CityAdapter (GetListOfCities ());
			listView.SetAdapter (adapter);
		}
	
	
	}
}


