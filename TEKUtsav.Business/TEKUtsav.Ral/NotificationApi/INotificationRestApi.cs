using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using System.Collections.Generic;

namespace TEKUtsav.Ral.NotificationApi
{
    public interface INotificationRestApi
    {
        Task<ICollection<Notification>> GetNotifications();
        Task<int> trackNotification(string notificationId);

    }
}
