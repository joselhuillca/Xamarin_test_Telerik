
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Telerik.Widget.List;
using Android.Graphics;
using Com.Telerik.Android.Common;
using Android.Support.V4.App;
using Java.Lang;

namespace test
{
	public class Test_telerik : ExampleFragmentBase
	{
		private RadListView listView;
		private SlideLayoutManager slideLayoutManager;
		private CityAdapter adapter;
		private View rootView;
		private LRUCache<string, Bitmap> mMemoryCache;

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

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
			int maxMemory = (int) (Runtime.GetRuntime().MaxMemory() / 1024);

			// Use 1/8th of the available memory for this memory cache.
			int cacheSize = maxMemory / 8;


			RetainFragment aux = new RetainFragment();
			RetainFragment retainFragment = aux.findOrCreateRetainFragment (FragmentManager);
			mMemoryCache = retainFragment.mRetainedCache;
			if (mMemoryCache == null) {
				mMemoryCache = new LRUCache<string, Bitmap>(cacheSize);
				retainFragment.mRetainedCache = mMemoryCache;
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			if (rootView != null) {
				return rootView;
			}
			rootView = inflater.Inflate(Resource.Layout.fragment_list_view_slide, container, false);
			listView = (RadListView)rootView.FindViewById(Resource.Id.listView);

			slideLayoutManager = new SlideLayoutManager(Activity);

			adapter = new CityAdapter(GetListOfCities());
			updateListViewLayoutParams();
			listView.SetAdapter (adapter);

			listView.SetLayoutManager(slideLayoutManager);
			if (savedInstanceState != null) {
				int currentPosition = savedInstanceState.GetInt("currentPosition", 0);
				slideLayoutManager.ScrollToPosition(currentPosition);
			}

			return rootView;
		}


		private void updateListViewLayoutParams() {
			Display display = Activity.WindowManager.DefaultDisplay;
			Point size = new Point();
			display.GetSize(size);
			int width = size.X;

			int height = size.Y;
			//TypedValue tv = new TypedValue();
			TypedValue tv = new TypedValue();
			//if (getActivity().getTheme().resolveAttribute(android.support.v7.appcompat.R.attr.actionBarSize, tv, true))
			//{
			//int actionBarHeight = TypedValue.complexToDimensionPixelSize(tv.data,getResources().getDisplayMetrics());
			//height -= actionBarHeight;
			//}

			int offset;
			int cardHeight;
			int cardWidth;
			int maxWidth = 1067;
			int maxHeight = 5 * maxWidth / 4;

			int itemSpacing = (int) Util.GetDimen(TypedValue.DensityDefault,12);
			if (width > height) {
				cardHeight = height - 4 * itemSpacing;
				cardWidth = 4 * cardHeight / 5;
				offset = (width - cardWidth) / 2;
			} else {
				offset = width / 10;
				cardWidth = offset * 8;
				cardHeight = 5 * cardWidth / 4;
			}
			if(cardWidth > maxWidth) {
				cardWidth = maxWidth;
				cardHeight = maxHeight;
				offset = (width - cardWidth) / 2;
			}

			listView.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,cardHeight);
			adapter.setDimens(cardWidth, cardHeight);

			slideLayoutManager.PreviousItemPreview = offset;
			slideLayoutManager.NextItemPreview = offset;
			slideLayoutManager.ItemSpacing = itemSpacing;
		}


		public class RetainFragment : Fragment {
			private static string TAG = "RetainFragment";
			public LRUCache<string, Bitmap> mRetainedCache;

			public RetainFragment() {}

			public RetainFragment findOrCreateRetainFragment(FragmentManager fm) {
				RetainFragment fragment = (RetainFragment) fm.FindFragmentByTag(TAG);
				if (fragment == null) {
					fragment = new RetainFragment();
					fm.BeginTransaction().Add(fragment,TAG).Commit();
				}
				return fragment;
			}


			public override void OnCreate(Bundle savedInstanceState)
			{
				base.OnCreate(savedInstanceState);
				RetainInstance = true;
			}
		}

	}
}

