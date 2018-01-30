using System;

namespace TEKUtsav.Models.Entities
{
	public class TodoItem : TableData
	{
		public string Text { get; set; }
		public bool Complete { get; set; }
	}
}
