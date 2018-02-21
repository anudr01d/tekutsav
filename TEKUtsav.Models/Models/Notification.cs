using System.Collections.Generic;
using TEKUtsav.Models.Entities;
using System;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class Notification : TableData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AdminDescription { get; set; }
        //public DateTimeOffset? UpdatedAt { get; set; }
        public int order { get; set; }
        public bool IsRegularUserVisible { get; set; }
        public ICollection<NotificationSchedule> NotificationSchedule { get; set; }
        public ICollection<NotificationTracks> NotificationTracks { get; set; }

    }
}
