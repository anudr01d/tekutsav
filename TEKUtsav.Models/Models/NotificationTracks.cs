using Newtonsoft.Json;
using System;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class NotificationTracks : BaseModel
    {
        public string NotificationId { get; set; }
        public string pushCount { get; set; }
        public DateTimeOffset? EndTime { get; set; }

        [JsonIgnore]
        public virtual Notification Notification { get; set; }
    }
}
