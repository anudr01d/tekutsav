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
using TEKUtsav.Models.Entities;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Infrastructure;
using TEKUtsav.Business.Measurements;

namespace TEKUtsav.ViewModels.ContactDetailsPage
{
	public class ContactDetailsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
		private readonly ISettings _settings;
		private bool clicked = false;
        private List<Notification> _notifications;
		private ICommand _menuClickCommand, _registerClickedCommand;

		public ICommand RegisterClickedCommand
		{
            get { return _registerClickedCommand; }
			protected set
			{
                _registerClickedCommand = value;
                OnPropertyChanged("RegisterClickedCommand");
			}
		}

        public List<Notification> Notifications
        {
            get
            {
                if (_notifications == null)
                {
                    var list = new List<Notification>();
                    list.Add(new Notification() { Title = "Pre-event", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    list.Add(new Notification() { Title = "Lunch", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    list.Add(new Notification() { Title = "High Tea", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    list.Add(new Notification() { Title = "Main event", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    list.Add(new Notification() { Title = "Voting", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    list.Add(new Notification() { Title = "Dance Floor", FormattedDateTime = "24 Feb | 10.00", Description="Some description"});
                    return list;
                }
                else
                {
                    return _notifications;
                }
            }
            set
            {
                _notifications = value;
                OnPropertyChanged("Notifications");
            }
        }

        public ContactDetailsPageViewModel(INavigationService navigationService, ISettings settings) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
			_navigationService = navigationService;
			_settings = settings;
		}

		public override async Task OnViewAppearing(object navigationParams = null)
		{
			this.SetCurrentPage(TEKUtsavAppPage.ContactDetailsPage);
           	
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
