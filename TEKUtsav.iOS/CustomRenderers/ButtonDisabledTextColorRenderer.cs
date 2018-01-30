﻿using System;
using TEKUtsav.iOS;
using TEKUtsav.UIControls.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomButton), typeof(ButtonDisabledTextColorRenderer))]
namespace TEKUtsav.iOS
{
	public class ButtonDisabledTextColorRenderer : ButtonRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			var btn = e.NewElement as CustomButton;
			base.OnElementChanged(e);
			if (btn != null)
			{
				if (!btn.IsWhiteBtn)
				{
					if (Control != null)
					{
						Control.SetTitleColor(UIColor.White, UIControlState.Disabled);
					}
				}
				else
				{
					if (Control != null)
					{
						Control.SetTitleColor(UIColor.Clear.FromHex(0x95989A), UIControlState.Disabled);
					}
				}
			}
		}
	}
}
