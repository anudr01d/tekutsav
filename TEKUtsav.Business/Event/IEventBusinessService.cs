using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;

namespace TEKUtsav.Business.EventService
{
    public interface IEventBusinessService
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<IEnumerable<EventType>> GetEventTypes();

        Task<EventVote> CaptureUserVote(EventVote vote);
        Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);
        Task<List<EventWinner>> ComputeEventWinner(string eventTypeId);
        Task<EventVotingSchedule> enableDiableVoting(EventVotingSchedule eventVoting);
    }
}
