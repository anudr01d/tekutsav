using System.Collections.Generic;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventType : BaseModel
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
