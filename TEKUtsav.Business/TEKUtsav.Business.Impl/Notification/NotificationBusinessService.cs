using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;
using TEKUtsav.Ral.NotificationApi;
using System.Collections.Generic;



namespace TEKUtsav.Business.Notification.Impl
{
    public class NotificationBusinessService : INotificationBusinessService
    {
        private readonly INotificationRestApi _notificationRestApi;
        public NotificationBusinessService(INotificationRestApi notificationRestApi)
        {
            if (notificationRestApi == null) throw new ArgumentNullException("notificationRestApi");
            _notificationRestApi = notificationRestApi;
        }

        public async Task<IEnumerable<DS.Notification>> GetNotifications()
        {
            return await _notificationRestApi.GetNotifications();
        }
    }
}
