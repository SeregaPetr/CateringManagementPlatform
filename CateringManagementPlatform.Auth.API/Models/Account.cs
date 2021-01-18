using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CateringManagementPlatform.Auth.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
    }

    public enum Role
    {
        Admin,
        User,
        Barman,
        Chef,
        Waiter
    }
}
