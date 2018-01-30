using System.Collections.Generic;
using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class ContainerConditionComment : TableData
    {
        public ContainerConditionComment()
        {
        }

        public bool IsContainerApproved { get; set; }

        public string ContainerRejectionComments { get; set; }

        public string MaterialId { get; set; }

        public string WorkflowId { get; set; }
    }
}
