using System.Collections.Generic;
using TEKUtsav.Models.Entities;
using TEKUtsav.Models;

namespace TEKUtsav.Models
{
    public class PurchaseOrderWorkflow : TableData
    {
        public PurchaseOrderWorkflow()
        {
        }

        public string PurchaseOrderId { get; set; }

        public string WorkflowStatusId { get; set; }

        public List<ContainerConditionStatus> ContainerConditionStatuses { get; set; }

        public List<MaterialMeasurement> MaterialMeasurements { get; set; }

        public List<MaterialImage> MaterialImages { get; set; }

        public List<ContainerConditionComment> ContainerConditionComments { get; set; }

        public List<MaterialMeasurementComment> MaterialMeasurementComments { get; set; }
    }
}
