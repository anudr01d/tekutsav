using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;

namespace TEKUtsav.Business.EventService
{
    public interface IEventBusinessService
    {
        Task<IEnumerable<Event>> GetEvents();
    }
}
