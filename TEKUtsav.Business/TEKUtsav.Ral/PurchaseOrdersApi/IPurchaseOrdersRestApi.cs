using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TEKUtsav.Models;

namespace TEKUtsav.Ral.PurchaseOrders
{
	public interface IPurchaseOrdersRestApi
	{
		Task<List<PurchaseOrder>> GetPurchaseOrders();
		Task<PurchaseOrder> GetPurchaseOrder(string PurchaseOrderId);
		Task<PurchaseOrder> SubmitPurchaseOrder(PurchaseOrder porder);
		Task<List<PurchaseOrder>> GetCompletedPurchaseOrders();
		Task<PurchaseOrder> GetContainerChecklist(string PurchaseOrderId);
		Task<PurchaseOrderWorkflow> ApprovePurchaseOrder(PurchaseOrderWorkflow porder);
		Task<bool> SyncSapData();
	}
}
