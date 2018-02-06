

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class Event : BaseModel
    {
        public string EventTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public EventType EventType { get; set; }
    }
}
