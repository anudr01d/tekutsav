using Newtonsoft.Json;



namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class DeviceRegister : BaseModel
    {
        public string UserId { get; set; }
        public string UDID { get; set; }
        public string Type { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
