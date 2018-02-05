using Newtonsoft.Json;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class EventUserDevice : BaseModel
    {
        public string EventVoteId { get; set; }
        public string EventId { get; set; }
        public string UDID { get; set; }

        [JsonIgnore]
        public virtual EventVote EventVote { get; set; }
    }
}
