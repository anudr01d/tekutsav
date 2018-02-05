using System;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.Event
{
    public interface IEventService
    {
        Task<DS.Event> GetEvents(string eventTypeId);
    }
}
