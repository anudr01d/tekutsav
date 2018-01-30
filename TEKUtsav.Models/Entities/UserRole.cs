using Newtonsoft.Json;

namespace TEKUtsav.Models.Entities
{
    public class UserRole
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public string AppId { get; set; }

        public virtual Role Role { get; set; }
    }
}