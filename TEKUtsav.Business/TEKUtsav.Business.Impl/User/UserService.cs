using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Business.User;
using DSUser = TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Ral.User;


namespace TEKUtsav.Business.User
{
    public class UserService : IUserService
    {
        private readonly IUserRestApi _userRestApi;
        public  UserService(IUserRestApi userRestApi)
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