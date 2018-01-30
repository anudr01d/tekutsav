using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.ValueConverters
{
	public class DecimalUnitConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString() != string.Empty)
				return Decimal.Parse(value.ToString()).ToString("G");
			else
				return 0;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var tempString = value.ToString();
			if (!string.IsNullOrEmpty(tempString))
			{
					Decimal xyz;
					if(!Decimal.TryParse(tempString, out xyz))
					   return 0;
				return xyz;
			}
			else
			{
				return 0;
			}

			/*string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

			if (valueFromString.Length <= 0)
				return 0m;

			long valueLong;
			if (!long.TryParse(valueFromString, out valueLong))
				return 0m;

			if (valueLong <= 0)
				return 0m;

			return valueLong / 100m;*/
		}
	}
}
