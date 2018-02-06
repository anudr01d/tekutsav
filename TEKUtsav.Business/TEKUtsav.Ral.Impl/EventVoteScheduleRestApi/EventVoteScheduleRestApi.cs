using System;
using System.Threading.Tasks;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.EventVoteScheduleApi;

namespace TEKUtsav.Ral.Impl.EventVoteScheduleRestApi
{
    public class EventVoteScheduleRestApi : IEventVoteScheduleRestApi
    {
        private readonly ICloudService _cloudService;
        private readonly IAzureClient _azureClient;

        public EventVoteScheduleRestApi(ICloudService cloudService, IAzureClient azureClient)
        {
            if (cloudService == null) throw new ArgumentNullException("cloudservice");
            if (azureClient == null) throw new ArgumentNullException("azureclient");
            _cloudService = cloudService;
            _azureClient = azureClient;
        }

        public Task<int> CheckIfVotingIsOpen(string eventTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
