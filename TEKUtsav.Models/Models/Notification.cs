using System.Collections.Generic;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class Notification : TableData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<NotificationSchedule> NotificationTracks { get; set; }
    }
}
