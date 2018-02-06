using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.User
{
    public interface IUserService
    {
        bool RegisterUser(DS.User user);
    }

}