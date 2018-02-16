using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using Xamarin.Forms;
using TEKUtsav.ViewModels.AdminSettingsPage;

namespace TEKUtsav.Views.AdminSettingsPage
{
	public partial class AdminSettingsPage : TEKUtsavContentPage
    {
        AdminSettingsPageViewModel vm;

        void Handle_Toggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            vm.Handle_Toggled(sender,e);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            vm = (AdminSettingsPageViewModel)this.BindingContext;
        }

        public AdminSettingsPage()
        {
            InitializeComponent();

        }

	}
}
