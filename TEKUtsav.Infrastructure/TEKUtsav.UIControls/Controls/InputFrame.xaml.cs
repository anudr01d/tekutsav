using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
		[ContentProperty("FrameContent")]
		public partial class InputFrame : ContentView
		{
			public static readonly BindableProperty BgColorProperty =
	  			BindableProperty.Create(
				"BgColor", typeof(string), typeof(ContentView), null, propertyChanged: BgColorChanged);
		public static readonly BindableProperty BdColorProperty =
	  			BindableProperty.Create(
				"BdColor", typeof(string), typeof(ContentView), null, propertyChanged: BdColorChanged);

		public InputFrame()
			{
				InitializeComponent();
			}
			public string BgColor { get;set;}
			public View FrameContent
			{
				get { return frameContent.Content; }
				set { frameContent.Content = value; }
			}

		static void BgColorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((InputFrame)bindable).OnBgColorChanged((string)newValue);
		}
		static void BdColorChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((InputFrame)bindable).OnBdColorChanged((string)newValue);
		}
		void OnBgColorChanged(string value) {
			frameContent.BackgroundColor = Color.FromHex(value);
		}
		void OnBdColorChanged(string value)
		{
			frame.BackgroundColor = Color.FromHex(value);
		}
		}
}
