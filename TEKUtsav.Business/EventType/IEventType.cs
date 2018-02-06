using System;
using DS = TEKUtsav.Mobile.Service.Domain.DataObjects;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace TEKUtsav.Business.EventType
{
   
        public interface IEventTypeService
        {
            Task<DS.EventType> GetEventTypes();
        }


}
