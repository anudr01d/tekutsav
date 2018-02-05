using Newtonsoft.Json;
using System;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class NotificationSchedule : BaseModel
    {
        public string NotificationId { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        [JsonIgnore]
        public Notification Notification { get; set; }
    }
}
