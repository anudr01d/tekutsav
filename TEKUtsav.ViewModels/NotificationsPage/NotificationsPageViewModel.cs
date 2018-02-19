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
        private List<NotificationListItem> _notifications;
        private ICommand _menuClickCommand, _registerClickedCommand;


        private ICommand _sendPushClickCommand;
        public ICommand SendPushClickCommand
        {
            get { return _sendPushClickCommand; }
            protected set
            {
                _sendPushClickCommand = value;
                OnPropertyChanged("SendPushClickCommand");
            }
        }
		public ICommand RegisterClickedCommand
		{
            get { return _registerClickedCommand; }
			protected set
			{
                _registerClickedCommand = value;
                OnPropertyChanged("RegisterClickedCommand");
			}
		}
        private string GetAdminId()
        {
            return Application.Current.Properties["IsAdmin"] as string;
        }
        public List<NotificationListItem> Notifications
        {
            get
            {
                var notificationEvents = Task.Run(() => _notificationBusinesservice.GetNotifications());
                if (notificationEvents != null)
                {
                    var list = new List<NotificationListItem>();

                    foreach (var ev in notificationEvents.Result)
                    {
                        var pushCount = "0";
                        if (ev.NotificationTracks != null) {
                             pushCount = ev.NotificationTracks.FirstOrDefault().pushCount;
                        }
                        int count = Convert.ToInt32(pushCount);
                        bool pushEnabled = false;
                        string isAdminString = GetAdminId();
                        bool IsAdmin = true;//Convert.ToBoolean(isAdminString);
                        if (count < 2 && IsAdmin == true) {
                            pushEnabled = true;
                        }
                       
                        if (IsAdmin == true)
                        {
                            list.Add(new NotificationListItem() { Title = ev.Title, FormattedDateTime = ev.NotificationSchedule.FirstOrDefault().StartTime.ToString(), Description = ev.AdminDescription, pushEnabled = pushEnabled });
 
                        }
                        else{
                            if (Convert.ToInt32(pushCount) > 0)
                            {
                                list.Add(new NotificationListItem() { Title = ev.Title, FormattedDateTime = ev.NotificationSchedule.FirstOrDefault().StartTime.ToString(), Description = ev.Description, pushEnabled = pushEnabled });
                            }

                        }
                       

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
        private void sendPush(string title, string description)
        {
            FireBasePush push = new FireBasePush(Globals.FIREBASE_SERVER_KEY);
            push.SendPush(new PushMessage
            {
                to = "/topics/news",
                notification = new PushMessageData
                {
                    title = title,
                    text = description,
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
            this.SendPushClickCommand = new Command(async(e) =>
            {
                var item = (e as TEKUtsav.Models.NotificationListItem);
                sendPush(item.Title, item.Description);
                await _navigationService.DisplayAlert("Notification Sent!", "", "OK");
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
