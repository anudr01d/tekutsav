using System;
namespace TEKUtsav.Models
{
	public class ScanResult
	{
		public string ResultText { get; set; }
		public bool RemoveScan { get; set; }
		public string MaterialId { get; set; }
		public string PurchaseOrderId { get; set; }
		public string WorkFlowId { get; set; }
	}
}
