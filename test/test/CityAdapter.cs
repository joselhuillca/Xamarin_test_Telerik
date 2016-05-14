using System;
using Android.Widget;
using Android.Views;
using Com.Telerik.Widget.List;
using Android.Support.V7.Widget;
using System.Collections;
using Android.Content;

namespace test
{
	public class CityAdapter : ListViewAdapter
	{
		private int width;
		private int height;

		public CityAdapter(IList items)
			:base(items) {
		}

		public void setDimens(int width, int height) {
			this.width = width;
			this.height = height;
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder (ViewGroup parent, int viewType)
		{
			LayoutInflater inflater = LayoutInflater.From(parent.Context);
			View view = inflater.Inflate(Resource.Layout.city_list_item, parent, false);
			//return new CityViewHolder(view);
			return new DestinationViewHolder(view);
		}

		public override void OnBindListViewHolder (ListViewHolder holder, int position)
		{
			/*CityViewHolder viewHolder = (CityViewHolder)holder;
			City city = (City)Items[position];
			viewHolder.nameView.Text = city.Name;
			viewHolder.countryView.Text = city.Country;*/
			City city = (City)Items[position];
			DestinationViewHolder viewHolder = (DestinationViewHolder)holder;
			viewHolder.nameView.Text = city.Name;
			viewHolder.countryView.Text = city.Country;
		}
		/*
		public class CityViewHolder : ListViewHolder {
			public TextView nameView;
			public TextView countryView;

			public CityViewHolder(View itemView)
				:base(itemView){

				nameView = (TextView)itemView.FindViewById(Resource.Id.nameView);
				countryView = (TextView)itemView.FindViewById(Resource.Id.countryView);
			}
		}*/

		//---------------------------------------------
		public class DestinationViewHolder : ListViewHolder {
			public TextView nameView;
			public TextView countryView;
			public ViewGroup destinationEnquiryLayout;
			public ImageView imgPortada;

			public View separator;
			public ViewGroup layout;
			public int position;

			private Context context;

			public DestinationViewHolder(View itemView) 
				:base(itemView)
			{
				this.context = itemView.Context;
				this.nameView = (TextView) itemView.FindViewById(Resource.Id.nameView);
				this.countryView = (TextView) itemView.FindViewById(Resource.Id.countryView);
				this.layout = (ViewGroup)itemView.FindViewById(Resource.Id.scrollingLayout);
				this.separator = itemView.FindViewById(Resource.Id.separator);

				this.imgPortada = (ImageView)itemView.FindViewById(Resource.Id.imgPoster);
				this.imgPortada.SetImageResource(Resource.Drawable.test_img);
			}
		}
	}
}

