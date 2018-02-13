using System;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.NotificationApi;
using TEKUtsav.Infrastructure.Constants;
using System.Collections.Generic;


namespace TEKUtsav.Ral.Impl.NotificationRestApi
{
    public class NotificationRestApi : INotificationRestApi
    {
        private readonly ICloudService _cloudService;
        private readonly IAzureClient _azureClient;

        public NotificationRestApi(ICloudService cloudService, IAzureClient azureClient)
        {
            if (cloudService == null) throw new ArgumentNullException("cloudservice");
            if (azureClient == null) throw new ArgumentNullException("azureclient");
            _cloudService = cloudService;
            _azureClient = azureClient;
        }

        public async Task<ICollection<Notification>> GetNotifications()
        {
            var azureclient = _azureClient.GetClient(Globals.NOTIFICATION,string.Empty, string.Empty);
            var table = _cloudService.GetTable<Notification>(azureclient);
            var list = await table.ReadAllItemsAsync();
            return list;
        }
    }
}
