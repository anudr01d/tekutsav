using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
	public partial class ImageWithTextContent : ContentView
	{
		public static readonly BindableProperty LabelTextProperty =
	  			BindableProperty.Create(
				"LabelText", typeof(string), typeof(ImageWithTextContent), null, propertyChanged: LabelTextChanged);

		public static readonly BindableProperty ImgSrcProperty =
	  			BindableProperty.Create(
				"ImgSrc", typeof(string), typeof(ImageWithTextContent), null, propertyChanged: ImageChanged);

		public ImageWithTextContent()
		{
			InitializeComponent();
		}

		static void LabelTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((ImageWithTextContent)bindable).OnLabelTextChanged((string)newValue);
		}

		void OnLabelTextChanged(string newValue)
		{
			labelElement.Text = newValue;
		}

		static void ImageChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((ImageWithTextContent)bindable).OnImageSourceChanged((string)newValue);
		}

		void OnImageSourceChanged(string newValue)
		{
			
			imageElement.Source = getFileFromString(newValue); 
		}

		ImageSource getFileFromString(string value) { 
		    if (value != null)
			{
				switch (value.ToString().ToLower())
				{
					case "TEKUtsavscan":
                        {
                            return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.TEKUtsavscan.png");
                        }
					default:
						{
							return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.defaultimage.png");
						}
				}
			}
			else
				return ImageSource.FromResource("TEKUtsav.UIControls.Resources.Images.chevron-right-blue.png");
		}
}
}
