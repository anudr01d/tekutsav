using System.Collections.Generic;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventVote : TableData
    {
        public string EventId { get; set; }

        // 1. This property is required so that computation of winner becomes less intensive and less joins to be applied.
        // 2. This property has nothing to do as of now with JSON to be send to client
        public string EventTypeId { get; set; }
        public int Votes { get; set; }
        public bool isVoteCapturedSuccessfully { get; set; }
        public Event Event { get; set; }
        public ICollection<EventUserDevice> EventUserDevices { get; set; }
    }
}
