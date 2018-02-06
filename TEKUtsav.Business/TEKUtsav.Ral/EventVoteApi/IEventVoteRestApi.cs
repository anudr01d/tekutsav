using System.Collections.Generic;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.EventVoteApi
{
    public interface IEventVoteRestApi
    {
        Task<int> CaptureUserVote(DS.EventVote eventvote);         Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);         Task<List<DS.EventWinner>> ComputeEventWinner(string eventTypeId);
    }
}