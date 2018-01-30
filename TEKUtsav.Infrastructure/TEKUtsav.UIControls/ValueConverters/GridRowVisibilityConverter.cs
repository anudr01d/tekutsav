using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUtsav.UIControls.ValueConverters
{
	public class GridRowVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (Equals(value, null))
				return new GridLength(0);

			var status = value.ToString().ToLower();

			switch (status)
			{
				case ("active"):
					{
						return new GridLength(1, GridUnitType.Auto);
					}
				default:
					{
						return new GridLength(0);
					}
			}
		}
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException("Only one way bindings are supported with this converter");
		}
	}
}
