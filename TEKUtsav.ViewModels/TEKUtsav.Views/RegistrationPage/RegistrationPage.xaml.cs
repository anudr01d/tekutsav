using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using TEKUtsav.ViewModels.RegistrationPage;
using Xamarin.Forms;

namespace TEKUtsav.Views.RegistrationPage
{
    public partial class RegistrationPage : ContentPage
    {
        RegistrationPageViewModel vm;
        public RegistrationPage()
        {
            InitializeComponent();
        }

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
            vm = (RegistrationPageViewModel)this.BindingContext;
		}

	}
}
