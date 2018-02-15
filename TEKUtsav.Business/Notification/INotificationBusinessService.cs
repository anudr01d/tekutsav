using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;
using System.Collections.Generic;
using TEKUtsav.Models;


namespace TEKUtsav.Business.Notification
{
    public interface INotificationBusinessService
    {
        Task<IEnumerable<DS.Notification>> GetNotifications();

    }
}
