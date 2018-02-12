using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.EventApi
{
    public interface IEventRestApi
    {
        Task<ICollection<Event>> GetEvents();
        Task<int> CaptureUserVote(EventVote eventvotes);
        Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);
        Task<List<EventWinner>> ComputeEventWinner(string eventTypeId);
    }
}
