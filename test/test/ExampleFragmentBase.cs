
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
using Android.Net;
using Java.Lang;
using Android.Support.V4.App;

namespace test
{
	public class ExampleFragmentBase : Fragment
	{
		private ExampleLoadedListener listener;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			if (savedInstanceState == null) {
				if (this.usesInternet()) {
					//ConnectivityManager connectivityManager = (ConnectivityManager) this.getActivity().getSystemService(Service.CONNECTIVITY_SERVICE);
					ConnectivityManager connectivityManager = (ConnectivityManager)this.Activity.GetSystemService(Android.App.Service.ConnectivityService);
					//NetworkInfo ni = connectivityManager.getActiveNetworkInfo();
					NetworkInfo ni = connectivityManager.ActiveNetworkInfo;

					///if (ni == null || !ni.isConnectedOrConnecting()) {
					//Toast toast = Toast.makeText(this.getActivity(), R.string.internet_connectivity_prompt, Toast.LENGTH_SHORT);
					//toast.setGravity(Gravity.center, 0, 0);
					//toast.setDuration(Toast.LENGTH_LONG);
					//toast.show();
					//}
					if (ni == null || !ni.IsConnectedOrConnecting) {
						//message no hay internet
					}
				}
			}
		}

		public ExampleSourceModel getSourceCodeModel() {
			return new ExampleSourceModel (this.getClassHierarchyNames());
		}

		public string getEQATECCategory() {
			return "";
		}

		public override void OnResume() {
			base.OnResume();
			if (this.listener != null) {
				//this.listener.onExampleLoaded(this.getView());
				this.listener.onExampleLoaded(this.View);
			}
		}

		public void setOnExampleLoadedListener(ExampleLoadedListener listener) {
			if (listener != null && this.listener != null) {
				throw new Java.Lang.IllegalArgumentException("Listener already set!");
			}
			this.listener = listener;
		}

		protected bool usesInternet() {
			return false;
		}

		private List<string> getClassHierarchyNames() {
			List<string> classes = new List<string>();

			//for (Class c = this.getClass(); c != null; c = c.getSuperclass()) {
			//if (c.getSimpleName().equals(ExampleFragmentBase.class.getSimpleName())) {
			//	break;
			//}

			//classes.Add(c.getSimpleName());
			//}

			for (Class c = this.Class; c != null; c = c.Superclass) {
				if (c.SimpleName.Equals (this.Class.SimpleName)) {
					break;
				}
				classes.Add (c.SimpleName);
			}

			return classes;
		}

		public interface ExampleLoadedListener {
			void onExampleLoaded(View root);
		}
	}
}

