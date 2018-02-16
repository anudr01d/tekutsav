using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;
using TEKUtsav.Ral.EventApi;

namespace TEKUtsav.Business.EventService.Impl
{
    public class EventBusinessService : IEventBusinessService
    {
		private readonly IEventRestApi _eventRestApi;
        public EventBusinessService(IEventRestApi eventRestApi)
		 {
            if (eventRestApi == null) throw new ArgumentNullException("eventRestApi");
            _eventRestApi = eventRestApi;
         }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRestApi.GetEvents();
        }

        public async Task<EventVote> CaptureUserVote(EventVote vote)
        {
            return await _eventRestApi.CaptureUserVote(vote);
        }

        public async Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID)
        {
            return await _eventRestApi.CheckIfUserHasVoted(eventTypeId, UDID);
        }

        public async Task<List<EventWinner>> ComputeEventWinner(string eventTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<EventVotingSchedule> enableDiableVoting(EventVotingSchedule eventVoting)
        {
            return await _eventRestApi.enableDiableVoting(eventVoting);
        }

        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            return await _eventRestApi.GetEventTypes();
        }
    }
}
