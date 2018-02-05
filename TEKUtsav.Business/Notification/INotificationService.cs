using System;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.Notification
{
    public interface INotificationService
    {
        Task<DS.Notification> GetNotifications();
    }
}
