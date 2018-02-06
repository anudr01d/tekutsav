using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TEKUtsav.Models;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Ral.User
{
    public interface IUserRestApi
    {
        Task<DS.User> RegisterUser(DS.User workFlowItem);
    }
}
