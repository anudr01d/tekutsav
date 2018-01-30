using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TEKUtsav.Mobile.UIControls.Controls
{
	//[ContentProperty("CardContent")]
	public partial class CardView : ContentView
	{
		public static readonly BindableProperty HeaderTitleProperty =
	  	BindableProperty.Create(
				"HeaderTitle", typeof(string), typeof(CardView), null , propertyChanged: HeaderTitleChanged);
		public static readonly BindableProperty TotalAmountProperty =
	  	BindableProperty.Create(
				"TotalAmount", typeof(string), typeof(CardView), null, propertyChanged: TotalAmountChanged);
		public static readonly BindableProperty LRegionProperty =
	  	BindableProperty.Create(
				"LRegion", typeof(string), typeof(CardView), null, propertyChanged: LRegionChanged);

		public static readonly BindableProperty RRegionProperty =
	  	BindableProperty.Create(
				"RRegion", typeof(string), typeof(CardView), null, propertyChanged: RRegionChanged);

		public static readonly BindableProperty LRegionAmountProperty =
	  	BindableProperty.Create(
				"LRegionAmount", typeof(string), typeof(CardView), null, propertyChanged: LRegionAmountChanged);

		public static readonly BindableProperty RRegionAmountProperty =
	  	BindableProperty.Create(
				"RRegionAmount", typeof(string), typeof(CardView), null, propertyChanged: RRegionAmountChanged);

		static void HeaderTitleChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnHeaderTitleChanged((string)newValue);
		}

		static void TotalAmountChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnTotalAmountChanged((string)newValue);
		}

		static void LRegionChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnLRegionChanged((string)newValue);		
		}

		static void RRegionChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnRRegionChanged((string)newValue);
		}

		static void LRegionAmountChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnLRegionAmountChanged((string)newValue);
		}

		static void RRegionAmountChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((CardView)bindable).OnRRegionAmountChanged((string)newValue);
		}

		void OnTotalAmountChanged(string newValue)
		{
			totalAmount.Text = newValue;
		}

		void OnHeaderTitleChanged(string newValue)
		{
			headerTitle.Text = newValue;
		}

		void OnLRegionChanged(string newValue)
		{
			lRegion.Text = newValue;
		}
		void OnRRegionChanged(string newValue)
		{
			rRegion.Text = newValue;
		}
		void OnLRegionAmountChanged(string newValue)
		{
			lRegionAmount.Text = newValue;
		}
		void OnRRegionAmountChanged(string newValue)
		{
			rRegionAmount.Text = newValue;
		}

		public CardView()
		{
			InitializeComponent();
		}
		public string HeaderTitle
		{
			get { return (string)GetValue(HeaderTitleProperty); }
			set { SetValue(HeaderTitleProperty, value); }
		}
		public View CardContent
		{
			get { return cardContent.Content; }
			set { cardContent.Content = value; }
		}
	}
}
