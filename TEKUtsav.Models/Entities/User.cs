sing System.Collections.Generic;

namespace TEKUtsav.Models.Entities
{
    public class User
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string HAccount { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}