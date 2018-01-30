using System;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
	public class ScannedMaterial : PurchaseOrder
	{
		public string PurchaseOrderId { get; set; }
		public string MaterialId { get; set; }
		public string Name { get; set; }
		public string Unit { get; set; }
		public string NetWeight { get; set; }
		public string NetWeightWithUnit
		{
			get
			{
				return NetWeight + " " + Unit;
			}
		}
		public int Quantity { get; set; }

		public PurchaseOrderWorkflow PoFlow { get; set; }
	}
}
