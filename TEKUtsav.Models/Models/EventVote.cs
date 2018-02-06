using System.Collections.Generic;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventVote : BaseModel
    {
        public string EventId { get; set; }

        // 1. This property is required so that computation of winner becomes less intensive and less joins to be applied.
        // 2. This property has nothing to do as of now with JSON to be send to client
        public string EventTypeId { get; set; }
        public int Votes { get; set; }
        public Event Event { get; set; }
        public ICollection<EventUserDevice> EventUserDevices { get; set; }
    }
}
