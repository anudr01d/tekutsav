using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using Xamarin.Forms;

namespace TEKUtsav.Views.AppListingPage
{
    public partial class AppListingPage : TEKUtsavContentPage, ICanHideBackButton
    {
        public AppListingPage()
        {
            InitializeComponent();
			HideBackButton = true;
        }

		public bool HideBackButton { get; set; }
    }
}
