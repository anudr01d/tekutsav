using TEKUtsav.Models.Entities;

namespace TEKUtsav.Models
{
    public class MaterialImage : TableData
    {
        public string WorkflowId { get; set; }

        public string MaterialId { get; set; }

        public string ImageName { get; set; }

        public byte[] Image { get; set; }
    }
}
