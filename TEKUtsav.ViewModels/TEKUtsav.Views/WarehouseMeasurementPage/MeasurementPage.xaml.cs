using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.UIControls.Controls;
using TEKUtsav.ViewModels.MeasurementPage;
using Xamarin.Forms;

namespace TEKUtsav.Views.MeasurementPage
{
	public partial class MeasurementPage : TEKUtsavContentPage
    {
		MeasurementPageViewModel vm;
		public MeasurementPage()
        {
            InitializeComponent();
        }

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			vm = (MeasurementPageViewModel)this.BindingContext;
		}

		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (vm != null)
			{
				vm.VerifyWorkflow(string.Empty);
			}
		}
	}
}
