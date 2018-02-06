using System;
namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public abstract class BaseModel
    {
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public byte[] Version { get; set; }
        public bool Deleted { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
