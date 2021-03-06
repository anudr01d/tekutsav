﻿using System;
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
using Acr.UserDialogs;

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
        private bool GetAdminId()
        {
            return (bool)Application.Current.Properties["IsAdmin"];
        }
        public List<NotificationListItem> Notifications
        {
            get
            {
                return _notifications;
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
                    title = title,
                    text = description
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

            await GetNotifications();

            this.SendPushClickCommand = new Command(async(e) =>
            {
                var item = (e as TEKUtsav.Models.NotificationListItem);
                sendPush(item.Title, item.Description);
                await _navigationService.DisplayAlert("Notification Sent!", "", "OK");
                var notificationEvents = Task.Run(() => _notificationBusinesservice.trackNotification(item.notificationId));

            });
			Task.Run(() => { });
		}

        private async Task GetNotifications()
        {
            UserDialogs.Instance.ShowLoading("Loading..", MaskType.Black);
            var notificationEvents = await _notificationBusinesservice.GetNotifications();
            if (notificationEvents != null)
            {
                var list = new List<NotificationListItem>();
                bool IsAdmin = GetAdminId();
                var SortedList = notificationEvents;
                if (IsAdmin == true)
                {
                    SortedList = notificationEvents.OrderBy(o => o.order).ToList();
                }
                else
                {
                    SortedList = notificationEvents.Where(x => x.NotificationTracks != null).ToList();
                    SortedList = SortedList.OrderByDescending(x => x.NotificationTracks.FirstOrDefault().UpdatedAt).ToList();
                }

                foreach (var ev in SortedList)
                {
                    var pushCount = "0";
                    if (ev.NotificationTracks != null)
                    {
                        pushCount = ev.NotificationTracks.FirstOrDefault().pushCount;
                    }
                    int count = Convert.ToInt32(pushCount);
                    bool pushEnabled = false;
                    if (count < 3 && IsAdmin == true)
                    {
                        pushEnabled = true;
                    }
                    if (IsAdmin == true)
                    {
                        list.Add(new NotificationListItem() { Title = ev.Title, FormattedDateTime = ev.NotificationSchedule.FirstOrDefault().StartDateTime, Description = ev.AdminDescription, pushEnabled = pushEnabled, notificationId = ev.NotificationSchedule.FirstOrDefault().NotificationId });
                    }
                    else
                    {
                        if (count > 0)
                        {

                            list.Add(new NotificationListItem() { Title = ev.Title, FormattedDateTime = ev.NotificationSchedule.FirstOrDefault().StartDateTime, Description = ev.AdminDescription, pushEnabled = pushEnabled, notificationId = ev.NotificationSchedule.FirstOrDefault().NotificationId });
                        }
                    }
                }

                Notifications = list;
            }
            UserDialogs.Instance.HideLoading();
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
