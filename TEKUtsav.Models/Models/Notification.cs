using System.Collections.Generic;


namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class Notification : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<NotificationSchedule> NotificationSchedule { get; set; }
    }
}
