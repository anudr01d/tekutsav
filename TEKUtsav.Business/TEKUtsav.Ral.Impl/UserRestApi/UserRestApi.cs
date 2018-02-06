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
            var client = _azureClient.GetClient(string.Empty, string.Empty, string.Empty);
            var userFlow = await _cloudService.InvokeApiAsyncPost<DS.User, DS.User>(client, Globals.USER_API, userData);
            return userFlow;
        }

    }
}
