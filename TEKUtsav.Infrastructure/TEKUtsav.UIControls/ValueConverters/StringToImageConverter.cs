using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.ValueConverters
{
    public class StringToImageConverter : IValueConverter
    {
        private static string ResourceBase = "TEKUtsav.UIControls.Resources.Images.";

        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {

            if (value != null)
            {
                switch (value.ToString().ToLower())
                {
                    case "rejectedicon":
                        {
                            return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_unfinished.png");
                        }
						case "approvedicon":
                        {
                            return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_finished.png");
                        }
						case "default":
						{
							//return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_unfinished.png");
							//return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_finished.png");
							return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_tbd.png");
						}
                    default:
                        {
                            return ImageSource.FromResource(ResourceBase + value.ToString());
                        }
                }
            }
            else
                return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.po_tbd.png"); ;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
