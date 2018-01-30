using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.ValueConverters
{
	public class IntUnitConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString() != string.Empty)
			{
				return int.Parse(value.ToString()).ToString("G");
			}
			else
				return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var tempString = value.ToString();
			if (tempString != string.Empty)
			{
					int valueint;
				if (!int.TryParse(tempString, out valueint))
					return 0;
				else
					return valueint;
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
