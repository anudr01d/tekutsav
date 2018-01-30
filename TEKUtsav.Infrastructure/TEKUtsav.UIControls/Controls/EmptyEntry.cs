using System;
using Xamarin.Forms;
using TEKUtsav.UIControls.Styles;

namespace TEKUtsav.UIControls.Controls
{
	public class EmptyEntry : Entry
	{
		public EmptyEntry()
		{
			var TEKUtsavLabelStyle = new TEKUtsavEntryStyle();
			this.Resources = TEKUtsavLabelStyle.Resources;
			this.Style = (Style)Resources["TEKUtsavEntryStyle"];
		}
	}
}
