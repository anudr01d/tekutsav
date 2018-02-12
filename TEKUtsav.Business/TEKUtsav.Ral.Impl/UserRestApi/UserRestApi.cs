using System;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Ral.CloudUtils;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.User;

namespace TEKUtsav.Ral.Impl.User
{
    public class UserRestApi : IUserRestApi
    {
        private readonly ICloudService _cloudService;
        private readonly IAzureClient _azureClient;

        public UserRestApi(ICloudService cloudService, IAzureClient azureClient)
        {
            if (cloudService == null) throw new ArgumentNullException("cloudservice");
            if (azureClient == null) throw new ArgumentNullException("azureclient");
            _cloudService = cloudService;
            _azureClient = azureClient;
        }

        public async Task<DS.User> RegisterUser(DS.User userData)
        {
            var azureclient = _azureClient.GetClient(Globals.USER_API, string.Empty, string.Empty);
            var table = _cloudService.GetTable<DS.User>(azureclient);
            var list = await table.CreateItemAsync(userData);
            return list == null ? null : list;
        }

    }
}
