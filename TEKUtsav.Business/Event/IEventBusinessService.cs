using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;

namespace TEKUtsav.Business.EventService
{
    public interface IEventBusinessService
    {
        Task<IEnumerable<Event>> GetEvents();
        Task<EventVote> CaptureUserVote(EventVote vote);
        Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);
        Task<List<EventWinner>> ComputeEventWinner(string eventTypeId);
        Task<EventVotingSchedule> enableDiableVoting(EventVotingSchedule eventVoting);         Task<IEnumerable<Event>> GetEventType();

    }
}
