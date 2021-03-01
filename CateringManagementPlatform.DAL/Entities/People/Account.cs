using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities.People
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public int? TableId { get; set; }
        public Table Table { get; set; }

        public Person Person { get; set; }
    }
}
