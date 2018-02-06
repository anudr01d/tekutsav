using System.Threading.Tasks;
using DO = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.EventTypeApi
{
    public interface IEventTypeRestApi
    {
        Task<DO.EventType> GetEventTypes();
    }
}
