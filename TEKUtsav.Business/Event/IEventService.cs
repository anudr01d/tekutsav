﻿using System.Threading.Tasks;
using DO = TEKUtsav.Mobile.Service.Domain.DataObjects;

namespace TEKUtsav.Business.Event
{
    public interface IEventService
    {
        Task<DO.Event> GetEvents(string eventTypeId);
    }
}
