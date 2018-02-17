using System;
using System.ComponentModel;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
	public class AdminListItem
	{
		public string Description { get; set; }
		public string Title { get; set; }
        public string Id { get; set; }
        public bool IsVotingOpen { get; set; }
	}
}
