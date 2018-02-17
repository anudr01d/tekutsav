using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.EventApi
{
    public interface IEventRestApi
    {
        Task<ICollection<Event>> GetEvents();
        Task<IEnumerable<EventType>> GetEventTypes();
        Task<ICollection<Event>> GetEventType();

        Task<EventVote> CaptureUserVote(EventVote eventvotes);
        Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);
        Task<List<EventWinner>> ComputeEventWinner(string eventTypeId);
        Task<EventVotingSchedule> enableDiableVoting(EventVotingSchedule eventVoting);
    }
}
