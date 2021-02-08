using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities.People
{
    public class UserRole
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }

    public enum Role
    {
        Admin = 1,
        User,
        Barman,
        Chef,
        Waiter
    }
}
