using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace TEKUtsav.Views.SingleSelectionPage
{
    public partial class SingleSelectionPage : PopupPage
    {
        public SingleSelectionPage()
        {
            InitializeComponent();
        }

        private void OnClose(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}
