using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.User
{
   
            public interface IUserService
            {
                 Task<DS.User> RegisterUser(DS.User user);
            }

}
