using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities.People
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public Person Person { get; set; }
    }
}
