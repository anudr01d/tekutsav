using Microsoft.Azure.Mobile.Server;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class BaseEntity : EntityData
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
