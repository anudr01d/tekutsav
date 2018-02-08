using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSUser = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.User;

namespace TEKUtsav.Business.User.Impl
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUserRestApi _userRestApi;
        public  UserBusinessService(IUserRestApi userRestApi)
        {
            if (userRestApi == null) throw new ArgumentNullException("userStore");
            _userRestApi = userRestApi;
        }

        public async Task<DSUser.User> RegisterUser(DSUser.User user)
        {
            return await _userRestApi.RegisterUser(user);
        }
       
    }
}