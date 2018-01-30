using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Models;

namespace TEKUtsav.Business.PurchaseOrders
{
	public interface IPurchaseOrdersBusinessService
	{
		Task<List<PurchaseOrder>> GetPurchaseOrders();
		Task<PurchaseOrder> GetPurchaseOrder(string PurachaseOrderItemId);
		Task<ScannedMaterial> GetPurchaseOrderMaterial(string PurchaseOrderId, string MaterialId);
		Task<PurchaseOrder> SubmitPurchaseOrder(PurchaseOrder porder);
		Task<List<PurchaseOrder>> GetCompletedPurchaseOrders();
		Task<PurchaseOrder> GetContainerChecklist(string PurchaseOrderId);
		Task<PurchaseOrderWorkflow> ApprovePurchaseOrder(PurchaseOrderWorkflow porder);
		Task<bool> SyncSapData();
	}
}
