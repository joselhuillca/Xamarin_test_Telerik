package md56996cb2aea8f756b255ad7a6f28adcb8;


public class CityAdapter_DestinationViewHolder
	extends com.telerik.widget.list.ListViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("test.CityAdapter/DestinationViewHolder, test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CityAdapter_DestinationViewHolder.class, __md_methods);
	}


	public CityAdapter_DestinationViewHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CityAdapter_DestinationViewHolder.class)
			mono.android.TypeManager.Activate ("test.CityAdapter/DestinationViewHolder, test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
