using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.NotificationApi
{
    public interface INotificationRestApi
    {
        Task<DS.Notification> GetNotifications();
    }
}
