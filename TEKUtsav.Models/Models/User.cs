using System.Collections.Generic;
using TEKUtsav.Models.Entities;
//using TEKUtsav.Models.Models;

namespace TEKUtsav.Mobile.Service.Domain.DataObjects
{
    public class User : TableData
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int CountryCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string WorkLocation { get; set; }
        public bool IsAdmin { get; set; }
        public bool isAccessAllowed { get; set; }
        public virtual ICollection<DeviceRegister> Devices { get; set; }
    }
}
