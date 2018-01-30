using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEKUtsav.Infrastructure;
using TEKUtsav.Infrastructure.Constants;
using TEKUtsav.Models;
using TEKUtsav.Ral;
using TEKUtsav.Ral.CloudUtils;
using TEKUtsav.Ral.CloutUtils.Impl;
using Microsoft.WindowsAzure.MobileServices;

namespace TEKUtsav.Ral.PurchaseOrders.Impl
{
    public class PurchaseOrdersRestApi : IPurchaseOrdersRestApi
    {
		private readonly ICloudService _cloudService;
		private readonly IAzureClient _azureclient;

		public PurchaseOrdersRestApi(ICloudService cloudService, IAzureClient azureClient)
		 {
			if (cloudService == null) throw new ArgumentNullException("cloudservice");
			_cloudService = cloudService;
			_azureclient = azureClient;
         }
			                 
		public async Task<List<PurchaseOrder>> GetPurchaseOrders()
		{
			var azureclient = _azureclient.GetClient(Globals.PURCHASE_ORDER, Globals.PURCHASEORDERS_KEY, Globals.DATE);
			var table = _cloudService.GetTable<PurchaseOrder>(azureclient);
			var list = await table.ReadAllItemsAsync();
			return list==null ? null : list.ToList();
		}

		public async Task<List<PurchaseOrder>> GetCompletedPurchaseOrders()
		{
			var azureclient = _azureclient.GetClient(Globals.PURCHASE_ORDER, Globals.COMPLETEDPURCHASEORDERS_KEY, Globals.DATE);
			var table = _cloudService.GetTable<PurchaseOrder>(azureclient);
			var list = await table.ReadAllItemsAsync();
			return list == null ? null : list.ToList();
		}

		public async Task<PurchaseOrder> GetPurchaseOrder(string PurchaseOrderId)
		{
			var azureclient = _azureclient.GetClient(Globals.PURCHASE_ORDER, Globals.PURCHASEORDER_KEY, string.Empty);
			var table = _cloudService.GetTable<PurchaseOrder>(azureclient);
			var list = await table.ReadItemAsync(PurchaseOrderId);
			return list;
		}

		public async Task<PurchaseOrder> GetContainerChecklist(string PurchaseOrderId)
		{
			var azureclient = _azureclient.GetClient(Globals.PURCHASE_ORDER, Globals.CONTAINER_CHECKLIST, string.Empty);
			var table = _cloudService.GetTable<PurchaseOrder>(azureclient);
			var list = await table.ReadItemAsync(PurchaseOrderId);
			return list;
		}

		public async Task<PurchaseOrder> SubmitPurchaseOrder(PurchaseOrder porder)
		{
			var expandedClient = _azureclient.GetClient(string.Empty, string.Empty, string.Empty);
			var table = _cloudService.GetTable<PurchaseOrder>(expandedClient);
			var po = await table.UpdateItemAsync(porder);
			return po;
		}

		public async Task<PurchaseOrderWorkflow> ApprovePurchaseOrder(PurchaseOrderWorkflow porder)
		{
			var expandedClient = _azureclient.GetClient(string.Empty, string.Empty, string.Empty);
			var table = _cloudService.GetTable<PurchaseOrderWorkflow>(expandedClient);
			var po = await table.UpdateItemAsync(porder);
			return po;
		}

		public async Task<bool> SyncSapData()
		{
			var azureClient = _azureclient.GetClient(null, null, null);
			var poFlow = await _cloudService.InvokeApiAsyncGet<bool>(azureClient, Globals.PURCHASEORDER_SYNC);
			return poFlow;
		}
	}
}
