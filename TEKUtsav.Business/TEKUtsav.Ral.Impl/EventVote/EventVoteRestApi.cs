using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Models;
using TEKUtsav.Ral;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.CloutUtils.Impl;
using Microsoft.WindowsAzure.MobileServices;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.EventVote;

namespace TEKUtsav.Ral.Impl.EventVote
{
    public class EventVoteRestApi : IEventVoteRestApi
    {
        private readonly ICloudService _cloudService;
        private readonly IAzureClient _azureClient;

        public EventVoteRestApi(ICloudService cloudService, IAzureClient azureClient)
        {
            if (cloudService == null) throw new ArgumentNullException("cloudservice");
            if (azureClient == null) throw new ArgumentNullException("azureclient");
            _cloudService = cloudService;
            _azureClient = azureClient;
        }
        public async Task<int> CaptureUserVote(DS.EventVote eventvotes)
        {
            var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            var poFlow = await _cloudService.InvokeApiAsyncPostData<DS.EventVote,int>(client, Globals.MEASUREMENTS_API, eventvotes);
            return poFlow;
        }
        public Task<int> CheckIfUserHasVoted(string eventTypeId, string UDID)
        {
            var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            //var userVote = await _cloudService.InvokeApiAsyncGetData<int>(client, Globals.EVENT_VOTE_API,eventTypeId,UDID);
            return null;
        }
        public Task<List<DS.EventWinner>> ComputeEventWinner(string eventTypeId)
        {
            var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            //var winner = await _cloudService.InvokeApiAsyncGet<DS.EventWinner>(client, Globals.COMPUTE_WINNER_API, eventTypeId);
            return null;
        }

    }
}
