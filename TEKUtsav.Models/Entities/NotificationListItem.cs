﻿using System;
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
        private string _formattedDateTime;
        public string FormattedDateTime
        {
            get
            {
                return "24 Feb | 10:00";
            }
            set
            {
                _formattedDateTime = "24 Feb | 10:00";
            }
        }

    }
}