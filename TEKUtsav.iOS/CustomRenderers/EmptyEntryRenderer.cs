﻿using System;
using CoreGraphics;
using Foundation;
using TEKUtsav.iOS;
using TEKUtsav.iOS;
using TEKUtsav.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EmptyEntry), typeof(EmptyEntryRenderer))]
namespace TEKUtsav.iOS
{
	public class EmptyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			if (e.NewElement != null)
			{
				Control.BorderStyle = UIKit.UITextBorderStyle.None;
				Control.TextColor = UIColor.Clear.FromHex(0x033462);
				Control.Font = UIFont.FromName("HelveticaNeue-Medium", 14);
				Control.SetValueForKeyPath(UIColor.Clear.FromHex(0x818181), new NSString("_placeholderLabel.textColor"));
			}
		}
	}
}
