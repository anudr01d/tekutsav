using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.ValueConverters
{
	public class DecUnitConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value.ToString() != string.Empty)
			{
				string[] strList = value.ToString().Split((char[])null);
				if (strList != null && strList.Length != 0 && strList.Length > 1)
					return Decimal.Parse(strList[0]).ToString("G") + " " + strList[1];
				else
					return string.Empty;
			}
			else
				return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var tempString = value.ToString();
			if (tempString != string.Empty)
			{
				string[] strList = tempString.Split((char[])null);
				if (strList != null && strList.Length != 0 && strList.Length > 1)
				{
					/*if (strList[0] == "0")
						return 0;
					
					string[] ret = strList[0].Split('.');
					if (ret.Length==1)
					{
						if (strList[0].EndsWith(".", StringComparison.CurrentCulture))
						{
							return strList[0] + "." + 0m;
						}
					}*/

					Decimal xyz;
					if(!Decimal.TryParse(strList[0], out xyz))
					   return 0m + " " + strList[1];

					return xyz + " " + strList[1];
				}
				else
				{
					return string.Empty;
				}
			}
			else
			{
				return string.Empty;
			}
		}
	}
}
