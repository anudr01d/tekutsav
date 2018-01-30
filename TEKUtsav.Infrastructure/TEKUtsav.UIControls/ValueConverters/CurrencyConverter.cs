using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.ValueConverters
{
	public class CurrencyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (Decimal.Parse(value.ToString()).ToString("N").Equals("0.00"))
				return "";
				return Decimal.Parse(value.ToString()).ToString("N");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string valueFromString = Regex.Replace(value.ToString(), @"\D", "");

			if (valueFromString.Length <= 0)
				return 0m;

			long valueLong;
			if (!long.TryParse(valueFromString, out valueLong))
				return 0m;

			if (valueLong <= 0)
				return 0m;

			return valueLong / 100m;
		}
	}
}
