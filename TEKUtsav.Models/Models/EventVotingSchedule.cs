using Newtonsoft.Json;
using TEKUtsav.Models.Entities;



namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventVotingSchedule : TableData
    {
        public string EventTypeId { get; set; }
        public bool IsVotingopen { get; set; }

        [JsonIgnore]
        public EventType EventType { get; set; }
    }
}
