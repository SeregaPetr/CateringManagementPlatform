using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CateringManagementPlatform.DAL.Entities.People
{
    [Table("Guests")]
    public class Guest : Person
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
