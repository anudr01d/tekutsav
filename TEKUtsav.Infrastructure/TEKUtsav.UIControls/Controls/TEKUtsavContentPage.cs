using System;
using TEKUtsav.UIControls.Styles;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
	public class TEKUtsavContentPage : ContentPage
	{
		public TEKUtsavContentPage()
		{
			TEKUtsavAppStyles styles = new TEKUtsavAppStyles();
			this.Resources = styles.Resources;
		}
	}
}
