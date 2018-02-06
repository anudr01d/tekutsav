using System;
using System.Threading.Tasks;
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

        public Task<Event> GetEvents(string eventTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
