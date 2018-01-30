using System;
using System.Globalization;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.MarkupExtensions
{
	public class Inverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null) {
				return !(bool)value;
			}
			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}
