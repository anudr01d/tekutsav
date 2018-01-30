using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using TEKUtsav.Models;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;

namespace TEKUtsav.ViewModels.ScannerPage
{
	public class ScannerPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;

		private ICommand _moveToNextScreenCommand;
		public ICommand MoveToNextScreenCommand
		{
			get
			{
				return _moveToNextScreenCommand;
			}
			set
			{
				_moveToNextScreenCommand = value;
				OnPropertyChanged("MoveToNextScreenCommand");
			}
		}

		public ScannerPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_navigationService = navigationService;
			_settings = settings;
		}
		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.ScannerPage);
            this.MoveToNextScreenCommand = new Command((args) =>
		   {
				_navigationService.NavigateTo(TEKUtsavAppPage.ScanCompletedPage, args);
			});

			Task.Run(() => { });
		}


		public override Task OnViewDisappearing()
		{
			return Task.Run(() => { });
		}

		public override void Dispose()
		{
		}
	}
}
