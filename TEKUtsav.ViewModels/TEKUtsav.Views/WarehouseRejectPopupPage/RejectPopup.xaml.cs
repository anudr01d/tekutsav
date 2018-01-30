using System;
using System.Collections.Generic;
using TEKUtsav.ViewModels.RejectPopup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace TEKUtsav.Views.RejectPopupPage
{
	public partial class RejectPopupPage : PopupPage
	{
		RejectPopupPageViewModel vm;
		public RejectPopupPage()
		{
			InitializeComponent();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			vm = (RejectPopupPageViewModel)this.BindingContext;
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (vm != null)
			{
				vm.VerifyComments();
			}
		}
	}
}
