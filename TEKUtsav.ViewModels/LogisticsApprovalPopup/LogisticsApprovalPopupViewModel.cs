using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using System.Diagnostics;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using TEKUtsav.ViewModels.BaseViewModel;
using TEKUtsav.Infrastructure.Navigation;
using TEKUtsav.Infrastructure.Settings;
using TEKUtsav.Models;
using TEKUtsav.Infrastructure.Constants;

namespace TEKUtsav.ViewModels.LogisticsApprovalPopup
{
	public class LogisticsApprovalPopupViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private ICommand _menuClickCommand;
		private ICommand _cancelCommand;
		private ICommand _saveCommand;
		private bool _isInputSaved, _isCancelPopup;
		private int _height;

		public ICommand CancelCommand
		{
			get { return _cancelCommand; }
			protected set
			{
				_cancelCommand = value;
				OnPropertyChanged();
			}
		}

		private ICommand _approveCommand;
		public ICommand ApproveCommand
		{
			get { return _approveCommand; }
			protected set
			{
				_approveCommand = value;
				OnPropertyChanged();
			}
		}

		private string _approvalComments;
		public string ApprovalComments
		{
			get
			{
				return _approvalComments;
			}
			set
			{
				_approvalComments = value;
				OnPropertyChanged("ApprovalComments");
			}
		}

		public LogisticsApprovalPopupViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_settings = settings;
			_navigationService = navigationService;
		}
		public override Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.RejectPopupPage);

			this.CancelCommand = new Command(() => {
				_navigationService.ClosePopup();
			});

			this.ApproveCommand = new Command(() =>
			 {
				MessagingCenter.Send(new RejectionItem() { Comments = ApprovalComments }, Globals.REJECTION_ITEM);
				_navigationService.ClosePopup();
			 });

			return Task.Run(() => { });
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
