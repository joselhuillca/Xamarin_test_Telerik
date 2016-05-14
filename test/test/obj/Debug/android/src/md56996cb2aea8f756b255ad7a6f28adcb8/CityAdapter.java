package md56996cb2aea8f756b255ad7a6f28adcb8;


public class CityAdapter
	extends com.telerik.widget.list.ListViewAdapter
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateViewHolder:(Landroid/view/ViewGroup;I)Lcom/telerik/widget/list/ListViewHolder;:GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"n_onBindViewHolder:(Lcom/telerik/widget/list/ListViewHolder;I)V:GetOnBindListViewHolder_Lcom_telerik_widget_list_ListViewHolder_IHandler\n" +
			"";
		mono.android.Runtime.register ("test.CityAdapter, test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CityAdapter.class, __md_methods);
	}


	public CityAdapter (java.util.List p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CityAdapter.class)
			mono.android.TypeManager.Activate ("test.CityAdapter, test, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.Collections.IList, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0 });
	}


	public com.telerik.widget.list.ListViewHolder onCreateViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateViewHolder (p0, p1);
	}

	private native com.telerik.widget.list.ListViewHolder n_onCreateViewHolder (android.view.ViewGroup p0, int p1);


	public void onBindViewHolder (com.telerik.widget.list.ListViewHolder p0, int p1)
	{
		n_onBindViewHolder (p0, p1);
	}

	private native void n_onBindViewHolder (com.telerik.widget.list.ListViewHolder p0, int p1);

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
