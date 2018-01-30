using System;
using System.Collections.Generic;
using TEKUtsav.Models.Entities;
using Newtonsoft.Json;

namespace TEKUtsav.Models
{
	public class PurchaseOrder : TableData
	{
		public string ContainerType { get; set; }
		public string BatchNumber { get; set; }
		public string Supplier { get; set; }

		[JsonIgnore]
		public string PoDate
		{
			get
			{
				return Date.Value.Date.ToString("MM/dd/yyyy")!=null ? Date.Value.Date.ToString("MM/dd/yyyy") : DateTime.Now.ToString("MM/dd/yyyy");
			}
		}

		public DateTimeOffset? Date { get; set; }
		public string Number { get; set; }
		public List<PurchaseOrderMaterial> PurchaseOrderMaterials { get; set; }
		public List<PurchaseOrderWorkflow> PurchaseOrderWorkFlow { get; set; }
		public PurchaseOrderStatus PurchaseOrderStatus { get; set; }


		[JsonIgnore]
		public String MenuImageSource
		{
			get
			{
				if (this.PurchaseOrderStatus != null)
				{
					switch (this.PurchaseOrderStatus.IsSubmitted)
					{
						case true:
							return "approvedicon";
						case false:
							return "rejectedicon";
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
