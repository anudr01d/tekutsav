using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.EventApi;

namespace TEKUtsav.Ral.Impl.EventRestApi
{
    public class EventRestApi : IEventRestApi
    {
        private readonly ICloudService _cloudService;
        private readonly IAzureClient _azureClient;

        public EventRestApi(ICloudService cloudService, IAzureClient azureClient)
        {
            if (cloudService == null) throw new ArgumentNullException("cloudservice");
            if (azureClient == null) throw new ArgumentNullException("azureclient");
            _cloudService = cloudService;
            _azureClient = azureClient;
        }

        public async Task<ICollection<Event>> GetEvents()
        {
            var azureclient = _azureClient.GetClient(Globals.EVENT, Globals.EVENT_KEY, string.Empty);
            var table = _cloudService.GetTable<Event>(azureclient);
            var list = await table.ReadAllItemsAsync();
            return list;
        }

        public async Task<EventVote> CaptureUserVote(EventVote eventvote)
        {
            var azureclient = _azureClient.GetClient(Globals.EVENT_VOTE, string.Empty, string.Empty);
            var table = _cloudService.GetTable<EventVote>(azureclient);
            var list = await table.CreateItemAsync(eventvote);
            return list;
        }

        public async Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID)
        {
            var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            var userVoteURL = Globals.CHECK_USER_VOTE + "/" + string.Format("{0}" + "/" + "{1}", eventTypeId, UDID) + "?ZUMO-API-VERSION=2.0.0";
            var userVote = await _cloudService.InvokeApiAsyncGet<int>(client, userVoteURL);
            return userVote;
        }

        public async Task<EventVotingSchedule> enableDiableVoting(EventVotingSchedule eventVoting)
        {
            var azureclient = _azureClient.GetClient(Globals.EVENT_VOTING_SCHEDULE, string.Empty, string.Empty);
            var table = _cloudService.GetTable<EventVotingSchedule>(azureclient);
            var list = await table.CreateItemAsync(eventVoting);
            return list;


        }

        public Task<List<EventWinner>> ComputeEventWinner(string eventTypeId)
        {
            //var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            //var winner = await _cloudService.InvokeApiAsyncGet<DS.EventWinner>(client, Globals.COMPUTE_WINNER_API, eventTypeId);
            return null;
        }

        public Task<int> CheckIfVotingIsOpen(string eventTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventType>> GetEventTypes()
        {
            var azureclient = _azureClient.GetClient(Globals.EVENT_TYPE, Globals.EVENT_VOTE_KEY, string.Empty);
            var table = _cloudService.GetTable<EventType>(azureclient);
            var list = await table.ReadAllItemsAsync();
            return list;
        }
    }
}
