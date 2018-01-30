using System;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
	public class ExpandCell : ViewCell
	{
		public static BindableProperty IsExpandedProperty =
			BindableProperty.Create("IsExpanded", typeof(bool), typeof(ExpandCell), true,
			propertyChanged: (bindable, oldValue, newValue) =>
		{
			ExpandCell view = (ExpandCell)bindable;
			view.ForceUpdateSize();
		});

		public bool IsExpanded {
			get { return (bool)GetValue(IsExpandedProperty); }
			set { SetValue(IsExpandedProperty, value); }
		}

		public ExpandCell()
		{
		}
	}
}
