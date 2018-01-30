using System;
using TEKUtsav.Models.Entities;
using Newtonsoft.Json;

namespace TEKUtsav.Models
{
	public class PurchaseOrderStatus : TableData
	{
		public string PurchaseOrderId { get; set; }
		public bool? IsSubmitted { get; set; }
		public string Status { get; set; }
	}
}
