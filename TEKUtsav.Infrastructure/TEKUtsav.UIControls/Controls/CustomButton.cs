using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TEKUtsav.UIControls.Controls
{
    public class CustomButton : Button
    {
       public static readonly BindableProperty IsBtnEnabledProperty =
			BindableProperty.Create<CustomButton, bool>(p => p.IsBtnEnabled, default(bool));

		public static readonly BindableProperty IsWhiteBtnProperty =
			BindableProperty.Create<CustomButton, bool>(p => p.IsWhiteBtn, default(bool));

		public bool IsBtnEnabled
		{
			get { return (bool)GetValue(IsBtnEnabledProperty); }
			set { SetValue(IsBtnEnabledProperty, value); }
		}

		public bool IsWhiteBtn
		{
			get { return (bool)GetValue(IsWhiteBtnProperty); }
			set { SetValue(IsWhiteBtnProperty, value); }
		}
    }
}
