using TEKUtsav.Models.Entities;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class Event : TableData
    {
        public string EventTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
    }
}
