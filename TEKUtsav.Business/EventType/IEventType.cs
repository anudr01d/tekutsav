using DO = TEKUtsav.Mobile.Service.Domain.DataObjects;
using System.Threading.Tasks;

namespace TEKUtsav.Business.EventType
{

    public interface IEventTypeService
        {
            Task<DO.EventType> GetEventTypes();
        }


}
