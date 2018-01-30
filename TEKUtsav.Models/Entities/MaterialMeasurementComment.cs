using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class MaterialMeasurementComment : TableData
    {
        public string MaterialMeasurementId { get; set; }

        public bool IsMaterialApproved { get; set; }

        public string MaterialRejectionComments { get; set; }

        public string MaterialId { get; set; }

        public string WorkflowId { get; set; }
    }
}
