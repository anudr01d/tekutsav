using System;
using System.Threading.Tasks;
using DSUser = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.EventVoteApi;
using System.Collections.Generic;

namespace TEKUtsav.Business.EventVote
{
    public class EventVoteService : IEventVoteService
    {
        private readonly IEventVoteRestApi _eventvoteRestApi;
        public EventVoteService(IEventVoteRestApi eventvoteRestApi)
        {
            if (eventvoteRestApi == null) throw new ArgumentNullException("eventVoteStore");
            _eventvoteRestApi = eventvoteRestApi;
        }

        //public async Task<int> CaptureUserVote(DSUser.EventVote eventvote)
        //{
        //    return await _eventvoteRestApi.CaptureUserVote(eventvote);
        //}

        public async Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID)
        {
            return await _eventvoteRestApi.CheckIfUserHasVoted(eventTypeId,UDID);
        }

        public async Task<List<DSUser.EventWinner>> ComputeEventWinner(string eventTypeId)
        {
            return await _eventvoteRestApi.ComputeEventWinner(eventTypeId);

        }


    }
}