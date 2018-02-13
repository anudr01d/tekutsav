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
using TEKUtsav.Business.Notification;
using TEKUtsav.Models.FireBase;



namespace TEKUtsav.ViewModels.NotificationsPage
{
	public class NotificationsPageViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;
        private readonly INotificationBusinessService _notificationBusinesservice;

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
                //var notificationEvents = await _notificationBusinesservice.GetNotifications();
                var notificationEvents = Task.Run(() => _notificationBusinesservice.GetNotifications());
                if (notificationEvents != null)
                {
                    var list = new List<Notification>();

                    foreach (var ev in notificationEvents.Result)
                    {
                        list.Add(new Notification() { Title = ev.Title, FormattedDateTime = "24 Feb | 10.00", Description = ev.Description });

                    }
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
        private void sendPush()
        {
            FireBasePush push = new FireBasePush(Globals.FIREBASE_SERVER_KEY);
            push.SendPush(new PushMessage
            {
                to = "/topics/news",
                notification = new PushMessageData
                {
                    title = "Dance",
                    text = "Event Started",
                    click_action = "click_action"
                },
                data = new
                {
                    example = "this is a example"
                }
            });
        }
        public void ProcessEvents(IEnumerable<Notification> events)
        {
            var list = new List<Notification>();

            foreach (var ev in events)
            {
                list.Add(new Notification() { Title = "Lunch", FormattedDateTime = "24 Feb | 10.00", Description = "Some description" });

            }
        }
        public NotificationsPageViewModel(INavigationService navigationService, ISettings settings, INotificationBusinessService notificationBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
            if (notificationBusinessService == null) throw new ArgumentNullException("notificationBusinessService");
			if (settings == null) throw new ArgumentNullException("settings");
            _notificationBusinesservice = notificationBusinessService;
			_navigationService = navigationService;
			_settings = settings;
		}
       
		public override async Task OnViewAppearing(object navigationParams = null)
		{
            this.SetCurrentPage(TEKUtsavAppPage.NotificationsPage);

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
