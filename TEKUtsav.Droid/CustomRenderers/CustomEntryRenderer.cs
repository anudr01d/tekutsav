using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TEKUtsav.Droid;
using Android.Content.Res;
using TEKUtsav.Droid;
using TEKUtsav.UIControls.Controls;
using TEKUtsav.Infrastructure.Constants;

[assembly: ExportRenderer(typeof(TEKUtsavEntry), typeof(CustomEntryRenderer))]
namespace TEKUtsav.Droid
{
	public class CustomEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);
			//Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
			Android.Graphics.Typeface tf = global::Android.Graphics.Typeface.CreateFromAsset(Context.Assets, "HelveticaNeueMed.ttf");
			Control?.SetTypeface(tf, Android.Graphics.TypefaceStyle.Normal);
			Control?.SetTextSize(Android.Util.ComplexUnitType.Sp, 16);
			Control.SetHintTextColor(ColorStateList.ValueOf(global::Android.Graphics.Color.ParseColor(Globals.TEXT_GRAY)));
		}

	}
}