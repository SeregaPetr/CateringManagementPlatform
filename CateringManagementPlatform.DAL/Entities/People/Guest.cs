using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CateringManagementPlatform.DAL.Entities.People
{
    [Table("Guests")]
    public class Guest : Person
    {
        public string Phone { get; set; }

        public ICollection<Table> Tables { get; set; } = new List<Table>();
    }
}
