using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKUtsav.Mobile.Service.Domain.DataObjects;
using TEKUtsav.Models;
using TEKUtsav.Ral.EventApi;

namespace TEKUtsav.Business.EventService.Impl
{
    public class EventBusinessService : IEventBusinessService
    {
		private readonly IEventRestApi _eventRestApi;
        public EventBusinessService(IEventRestApi eventRestApi)
		 {
            if (eventRestApi == null) throw new ArgumentNullException("eventRestApi");
            _eventRestApi = eventRestApi;
         }

        public async Task<IEnumerable<Event>> GetEvents()
		{
            return await _eventRestApi.GetEvents();
		}
	}
}
