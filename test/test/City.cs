using System;
using Android.Widget;

namespace test
{
	public class City : Java.Lang.Object {
		public String Name { get; set; }
		public String Country { get; set; }
		public String imgPortada{ get; set; }

		public City(String name, String country) {
			this.Name = name;
			this.Country = country;
		}

		public override string ToString () {
			return string.Format ("{0} ({1})", Name, Country);
		}
	}
}

