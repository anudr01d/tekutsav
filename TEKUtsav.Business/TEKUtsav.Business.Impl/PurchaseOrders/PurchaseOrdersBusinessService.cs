//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TEKUtsav.Models;

//namespace TEKUtsav.Business.PurchaseOrders.Impl
//{
//    public class PurchaseOrdersBusinessService : IPurchaseOrdersBusinessService
//    {
//		private readonly IPurchaseOrdersStore _purchaseOrdersStore;
//		public PurchaseOrdersBusinessService(IPurchaseOrdersStore purchaseOrdersStore)
//		 {
//			if (purchaseOrdersStore == null) throw new ArgumentNullException("purchaseordersstore");
//			_purchaseOrdersStore = purchaseOrdersStore;
//         }

//		public async Task<List<PurchaseOrder>> GetPurchaseOrders()
//		{
//			return await _purchaseOrdersStore.GetPurchaseOrders();
//		}

//		public async Task<PurchaseOrder> GetPurchaseOrder(string PurchaseOrderItemId)
//		{
//			return await _purchaseOrdersStore.GetPurchaseOrder(PurchaseOrderItemId);
//		}

//		public async Task<ScannedMaterial> GetPurchaseOrderMaterial(string PurchaseOrderId, string MaterialId)
//		{
//			var purchaseOrder = await _purchaseOrdersStore.GetPurchaseOrder(PurchaseOrderId);
//			var purchaseOrderMaterial = purchaseOrder.PurchaseOrderMaterials.Where(o => o.MaterialId == MaterialId).FirstOrDefault();
//			return new ScannedMaterial
//			{
//				MaterialId = MaterialId,
//				PurchaseOrderId = PurchaseOrderId,
//				BatchNumber = purchaseOrder.BatchNumber,
//                ContainerType = purchaseOrderMaterial.ContainerType,
//				Quantity = purchaseOrder.PurchaseOrderMaterials.Count(),
//				NetWeight = purchaseOrderMaterial.NetWeight,
//				Unit = purchaseOrderMaterial.Unit,
//				Name = purchaseOrderMaterial.Name,
//				Number = purchaseOrder.Number,
//				PoFlow = purchaseOrder.PurchaseOrderWorkFlow.FirstOrDefault()
//			};
//		}

//		public async Task<PurchaseOrder> SubmitPurchaseOrder(PurchaseOrder porder)
//		{
//			return await _purchaseOrdersStore.SubmitPurchaseOrder(porder);
//		}

//		public async Task<List<PurchaseOrder>> GetCompletedPurchaseOrders()
//		{
//			return await _purchaseOrdersStore.GetCompletedPurchaseOrders();
//		}

//		public async Task<PurchaseOrder> GetContainerChecklist(string PurchaseOrderId)
//		{
//			return await _purchaseOrdersStore.GetContainerChecklist(PurchaseOrderId);
//		}

//		public async Task<PurchaseOrderWorkflow> ApprovePurchaseOrder(PurchaseOrderWorkflow porder)
//		{
//			return await _purchaseOrdersStore.ApprovePurchaseOrder(porder);
//		}

//		public async Task<bool> SyncSapData()
//		{
//			return await _purchaseOrdersStore.SyncSapData();
//		}
//	}
//}
