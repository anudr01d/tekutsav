using Newtonsoft.Json;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventVotingSchedule : BaseModel
    {
        public string EventTypeId { get; set; }
        public bool IsVotingOpen { get; set; }

        [JsonIgnore]
        public EventType EventType { get; set; }
    }
}
