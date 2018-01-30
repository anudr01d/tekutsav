using System;
using Xamarin.Forms;
using TEKUtsav.UIControls.Styles;

namespace TEKUtsav.UIControls.Controls
{
	public class TEKUtsavLabel : Label
	{
		public static readonly BindableProperty FontTypeProperty =
	  BindableProperty.Create(
			"FontType", typeof(string), typeof(TEKUtsavLabel), "Light", propertyChanged: OnFontTypeChanged);

		public TEKUtsavLabel()
		{
			var huntsmanLabelStyle = new TEKUtsavLabelStyle();
			this.Resources = huntsmanLabelStyle.Resources;
			this.Style = (Style)Resources["TEKUtsavLabelStyle"];
		}

		public string FontType
		{
			get { return (string)GetValue(FontTypeProperty); }
			set { SetValue(FontTypeProperty, value); }
		}
		static void OnFontTypeChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((TEKUtsavLabel)bindable).OnFontTypeChanged((string)newValue);
		}
		void OnFontTypeChanged(string newValue)
		{
			if (newValue.Equals("Regular"))
			{
				Device.OnPlatform(iOS: () => this.FontAttributes = FontAttributes.Bold);
				this.Style = (Style)Resources["TEKUtsavLabelMediumStyle"];
 			}
			if (newValue.Equals("Medium"))
			{
				this.FontAttributes = FontAttributes.None;
				this.Style = (Style)Resources["TEKUtsavLabelMediumStyle"];
			}
		}
	}
}
