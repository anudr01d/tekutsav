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

namespace TEKUtsav.ViewModels.RejectPopup
{
	public class RejectPopupPageViewModel : ViewModelBase
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

		private ICommand _rejectCommand;
		public ICommand RejectCommand
		{
			get { return _rejectCommand; }
			protected set
			{
				_rejectCommand = value;
				OnPropertyChanged();
			}
		}

		private string _materialId;
		public string MaterialId
		{
			get
			{
				return _materialId;
			}
			set
			{
				_materialId = value;
				OnPropertyChanged("MaterialId");
			}
		}


		private string _rejectionComments = string.Empty;
		public string RejectionComments
		{
			get
			{
				return _rejectionComments;
			}
			set
			{
				_rejectionComments = value;
				OnPropertyChanged("RejectionComments");
			}
		}


		private bool _isRejectEnabled = true;
		public bool IsRejectEnabled
		{
			get
			{
				return _isRejectEnabled;
			}
			set
			{
				_isRejectEnabled = value;
				OnPropertyChanged("IsRejectEnabled");
				//if (this.RejectCommand != null) { ((Command)this.RejectCommand).ChangeCanExecute(); }
			}
		}

		private string _rejectColor = Globals.RED;
		public string RejectColor
		{
			get
			{
				return _rejectColor;
			}
			set
			{
				_rejectColor = value;
				OnPropertyChanged("RejectColor");
			}
		}

		public RejectPopupPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
        {
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_settings = settings;
			_navigationService = navigationService;
		}
		public override Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.RejectPopupPage);

			if (navigationParams != null)
			{
				this.MaterialId = navigationParams as string;
			}

			this.CancelCommand = new Command(() => {
				_navigationService.ClosePopup();
			});

			this.RejectCommand = new Command(() =>
			{ 
				//if (RejectionComments!=null && RejectionComments.Trim() != string.Empty)
				//{
					MessagingCenter.Send(new RejectionItem() { Comments = RejectionComments }, Globals.REJECTION_ITEM);
				//}
			 });

			//VerifyComments();

			return Task.Run(() => { });
		}


		public void VerifyComments()
		{
			if (!string.IsNullOrEmpty(this.RejectionComments.Trim()))
			{
				IsRejectEnabled = true;
				RejectColor = Globals.RED;
			}
			else
			{
				IsRejectEnabled = false;
				RejectColor = Globals.SUBMITDISABLED;
			}
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
