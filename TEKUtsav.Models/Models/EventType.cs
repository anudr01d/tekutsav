using System.Collections.Generic;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventType : TableData
    {
        public EventType()
        {
            Events = new List<Event>();
            EventVotingSchedules = new List<EventVotingSchedule>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        ICollection<Event> Events { get; set; }
        public ICollection<EventVotingSchedule> EventVotingSchedules { get; set; }
    }
}
