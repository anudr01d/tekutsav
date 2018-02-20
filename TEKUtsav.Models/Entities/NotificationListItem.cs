using System;
using System.ComponentModel;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class NotificationListItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool pushEnabled { get; set; }
        public string DateTime { get; set; }
        public string FormattedDateTime { get; set; }
        public string notificationId { get; set; }


    }
}
