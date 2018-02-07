//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Diagnostics;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using TEKUtsav.Infrastructure;
//using TEKUtsav.Infrastructure.Constants;
//using TEKUtsav.Models;
//using TEKUtsav.Ral;
//using TEKUtsav.Ral.CloudUtils;
//using TEKUtsav.Ral.CloutUtils.Impl;
//using TEKUtsav.Ral.Impl;
//using Microsoft.WindowsAzure.MobileServices;
//using Newtonsoft.Json;

//namespace TEKUtsav.Ral.ContainerConditions.Impl
//{
//	public class ContainerConditionsRestApi : IContainerConditionsRestApi
//    {
//		private readonly ICloudService _cloudService;
//		private readonly IAzureClient _azureclient;

//		public ContainerConditionsRestApi(ICloudService cloudService, IAzureClient azureClient)
//		 {
//			if (cloudService == null) throw new ArgumentNullException("cloudservice");
//			if (azureClient == null) throw new ArgumentNullException("azureclient");
//			_cloudService = cloudService;
//			_azureclient = azureClient;
//         }
			                 
//		public async Task<ObservableCollection<ContainerCondition>> GetContainerConditions()
//		{
//			var azureClient = _azureclient.GetClient(Globals.CONTAINER_CONDITIONS, String.Empty, Globals.ORDER);
//			var table = _cloudService.GetTable<ContainerCondition>(azureClient);
//			var list = await table.ReadAllItemsAsync();
//			return list==null ? null : new ObservableCollection<ContainerCondition>(list.ToList().OrderBy(i => i.Order));
//		}

//		public async Task<PurchaseOrderWorkflow> VerifyContainer(PurchaseOrderWorkflow workFlowItem)
//		{
//			var azureClient = _azureclient.GetClient(null, null, null);
//			var poFlow = await _cloudService.InvokeApiAsyncPost<PurchaseOrderWorkflow, PurchaseOrderWorkflow>(azureClient, Globals.CONTAINER_CONDITION_CHECKLIST_API, workFlowItem);
//			return poFlow;
//		}

//		public async Task<PurchaseOrderWorkflow> RejectContainer(PurchaseOrderWorkflow workFlowItem)
//		{
//			var azureClient = _azureclient.GetClient(null, null, null);
//			var poFlow = await _cloudService.InvokeApiAsyncPost<PurchaseOrderWorkflow,PurchaseOrderWorkflow>(azureClient, Globals.CONTAINER_CONDITION_CHECKLIST_API, workFlowItem);
//			return poFlow;
//		}

//    }
//}
