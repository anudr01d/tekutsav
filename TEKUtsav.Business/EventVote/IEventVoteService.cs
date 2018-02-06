using System;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;
using System.Collections.Generic;

namespace TEKUtsav.Business.EventVote
{
   
        public interface IEventVoteService
        {
        Task<int> CaptureUserVote(DS.EventVote eventvote);
        Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID);
        Task<List<DS.EventWinner>> ComputeEventWinner(string eventTypeId);
        }
   
}
