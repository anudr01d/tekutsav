
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class ContainerConditionStatus : TableData
    {
        public string ContainerId { get; set; }

        public string WorkflowId { get; set; }

        public string ContainerConditionChecklistId { get; set; }

        public bool? IsPassed { get; set; }

        public string Comments { get; set; }

        public string ContainerBarcode { get; set; }

        public string ApprovalStatusId { get; set; }

		public string MaterialId { get; set; }

		public ContainerCondition ContainerConditionChecklist { get; set; }
    }
}
