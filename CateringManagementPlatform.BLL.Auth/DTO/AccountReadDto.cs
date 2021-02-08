using System.Collections.Generic;
using CateringManagementPlatform.DAL.Entities.People;

namespace CateringManagementPlatform.BLL.Auth.DTO
{
    public class AccountReadDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    //    public Person Person { get; set; }
    }
}
