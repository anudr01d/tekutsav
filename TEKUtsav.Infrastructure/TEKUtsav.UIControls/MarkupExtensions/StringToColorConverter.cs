using System;
using System.Globalization;
using Xamarin.Forms;
namespace TEKUtsav.UIControls.MarkupExtensions
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
			if (value != null)
			{
				string valueAsString = value.ToString();
				switch (valueAsString)
				{
					case (""):
						{
							return Color.Default;
						}
					case ("Accent"):
						{
							return Color.Accent;
						}
					default:
						{
							return Color.FromHex(value.ToString());
						}
				}
			}
			else 
			{
				return Color.Black;
			}
				
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
