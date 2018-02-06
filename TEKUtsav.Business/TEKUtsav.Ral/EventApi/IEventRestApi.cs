using System.Threading.Tasks;
using DO = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.EventApi
{
    public interface IEventRestApi
    {
        Task<DO.Event> GetEvents(string eventTypeId);
    }
}
