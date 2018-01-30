using System;
namespace TEKUtsav.Models.Entities
{
	public abstract class TableData
	{
		public string Id { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public byte[] Version { get; set; } 
		public bool Deleted { get; set; }
		public string ModifiedBy { get; set; }
		public string CreatedBy { get; set; }
	}
}
