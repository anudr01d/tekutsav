using System.Threading.Tasks;

namespace TEKUtsav.Ral.EventVoteScheduleApi
{
    public interface IEventVoteScheduleRestApi
    {
        Task<int> CheckIfVotingIsOpen(string eventTypeId);
    }
}
