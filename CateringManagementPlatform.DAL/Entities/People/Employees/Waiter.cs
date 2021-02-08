using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CateringManagementPlatform.DAL.Entities.People.Employees
{
    [Table("Waiters")]
    public class Waiter : Employee
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
