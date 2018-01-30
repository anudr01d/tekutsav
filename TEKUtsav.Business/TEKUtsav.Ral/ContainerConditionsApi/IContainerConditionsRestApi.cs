using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TEKUtsav.Models;

namespace TEKUtsav.Ral.ContainerConditions
{
	public interface IContainerConditionsRestApi
	{
		Task<ObservableCollection<ContainerCondition>> GetContainerConditions();
		Task<PurchaseOrderWorkflow> VerifyContainer(PurchaseOrderWorkflow workFlowItem);
		Task<PurchaseOrderWorkflow> RejectContainer(PurchaseOrderWorkflow workFlowItem);
	}
}
