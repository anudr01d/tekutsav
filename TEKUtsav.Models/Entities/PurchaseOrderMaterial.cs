using System;
using System.Collections.Generic;
using TEKUtsav.Models.Entities;
using Newtonsoft.Json;

namespace TEKUtsav.Models
{
	public class PurchaseOrderMaterial : TableData
	{
		public string PurchaseOrderId { get; set; }
		public string MaterialId { get; set; }
		public string Name { get; set; }
		public string ContainerType { get; set; }
		public Decimal? OverDelivery { get; set; }
		public Decimal? UnderDelivery { get; set; }
		public string Unit { get; set; }
		public string NetWeight { get; set; }
		public PurchaseOrderMaterialStatus PurchaseOrderMaterialStatus { get; set; }

		[JsonIgnore]
		public string NetWeightWithUnit
		{
			get
			{
				return NetWeight + " " + Unit;
			}
		}


		[JsonIgnore]
		public String MenuImageSource
		{
			get
			{
				if (this.PurchaseOrderMaterialStatus != null)
				{
					switch (this.PurchaseOrderMaterialStatus.IsMaterialRejected)
					{
						case true:
							return "rejectedicon";
						case false:
							return "approvedicon";
						default:
							return "default";
					}
				}
				else
				{
					return "default";
				}
			}
		}

	}
}
