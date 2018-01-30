using System;
using TEKUtsav.Models.Entities;
using Newtonsoft.Json;

namespace TEKUtsav.Models
{
	public class PurchaseOrderMaterialStatus : TableData
	{
		public string PurchaseOrderMaterialId { get; set; }
		public bool? IsMaterialRejected { get; set; }

		[JsonIgnore]
		public String MenuImageSource
		{
			get
			{
				switch (this.IsMaterialRejected)
				{
					case true:
						return "rejectedicon";
					case false:
						return "approvedicon";
					default:
						return "default";
				}
			}
		}
	}
}
