using System;
using Xamarin.Forms;
using TEKUtsav.UIControls.Styles;

namespace TEKUtsav.UIControls.Controls
{
	public class TEKUtsavEntry : Entry
	{
			public static readonly BindableProperty FontTypeProperty =
			BindableProperty.Create(
				"FontType", typeof(string), typeof(TEKUtsavEntry), "Light", propertyChanged: OnFontTypeChanged);

		public TEKUtsavEntry()
		{
			var huntsmanLabelStyle = new TEKUtsavEntryStyle();
			this.Resources = huntsmanLabelStyle.Resources;
			this.Style = (Style)Resources["TEKUtsavEntryStyle"];
		}

		public string FontType
		{
			get { return (string)GetValue(FontTypeProperty); }
			set { SetValue(FontTypeProperty, value); }
		}

		static void OnFontTypeChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((TEKUtsavEntry)bindable).OnFontTypeChanged((string)newValue);
		}

		void OnFontTypeChanged(string newValue)
		{
			if (newValue.Equals("Regular"))
			{
				Device.OnPlatform(iOS: () => this.FontAttributes = FontAttributes.Bold);
				this.Style = (Style)Resources["TEKUtsavEntryMediumStyle"];
			}
			if (newValue.Equals("Medium"))
			{
				this.FontAttributes = FontAttributes.None;
				this.Style = (Style)Resources["TEKUtsavEntryMediumStyle"];
			}
		}
	}
}
