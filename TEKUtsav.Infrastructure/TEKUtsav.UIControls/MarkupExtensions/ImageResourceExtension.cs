using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TEKUtsav.UIControls.MarkupExtensions
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        private static string ResourceBase = "TEKUtsav.UIControls.Resources.Images.";

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;

            switch (Source)
            {
                case "Settings":
                    {
                        return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.Settings_small.png");
                    }
                case "TEKUtsavLOGO":
                    {
                        return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.TEKUtsav.png");
                    }
				case "Chevron":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.chevron-right-gray.png");
					}
				case "PUListing":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.Freezing-lg.png");
					}
				case "Industry":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.industry.jpg");
					}
				case "Menuclose":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.close-x.png");
					}
				case "Greybg":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.grey_image.png");
					}
				case "downarrow":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.downarrow.png");
					}
				case "Pinkbg":
					{
						return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.pink_image.png");
					}
                default: return ImageSource.FromResource(ResourceBase + Source);
            }
        }
    }
}
