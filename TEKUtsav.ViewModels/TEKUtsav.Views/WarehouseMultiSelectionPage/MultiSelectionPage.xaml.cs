using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace TEKUtsav.Views.MultiSelectionPage
{
    public partial class MultiSelectionPage : PopupPage
    {
		//IPopupNavigation _popupNavigation;
        public MultiSelectionPage()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
			PopupNavigation.PopAsync();
			//_popupNavigation.PopAsync();
        }
    }
}
