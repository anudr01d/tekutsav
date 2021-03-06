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
using Acr.UserDialogs;

namespace TEKUtsav.ViewModels.EventSchedulePage
{
	public class EventSchedulePageViewModel : ViewModelBase
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
                return _notifications;
            }
            set
            {
                _notifications = value;
                OnPropertyChanged("Notifications");
            }
        }
        public EventSchedulePageViewModel(INavigationService navigationService, ISettings settings, INotificationBusinessService notificationBusinessService) : base(navigationService, settings)
		{
			if (navigationService == null) throw new ArgumentNullException("navigationService");
			if (settings == null) throw new ArgumentNullException("settings");
            if (notificationBusinessService == null) throw new ArgumentNullException("notificationBusinessService");
			_navigationService = navigationService;
			_settings = settings;
            _notificationBusinesservice = notificationBusinessService;
		}

		public override async Task OnViewAppearing(object navigationParams = null)
		{
            this.SetCurrentPage(TEKUtsavAppPage.EventSchedulePage);

            await FetchNotifications();
           	
			Task.Run(() => { });
		}

        private async Task FetchNotifications()
        {
            UserDialogs.Instance.ShowLoading("Loading..", MaskType.Black);
            var notificationEvents = await _notificationBusinesservice.GetNotifications();

            if (notificationEvents != null)
            {
                var list = new List<Notification>();

                foreach (var ev in notificationEvents)
                {
                    bool isRegularUser = ev.IsRegularUserVisible;
                    if (isRegularUser == true)
                    {
                        list.Add(new Notification() { Title = ev.Title, FormattedDateTime = ev.NotificationSchedule.FirstOrDefault().StartDateTime, Description = ev.Description });
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
