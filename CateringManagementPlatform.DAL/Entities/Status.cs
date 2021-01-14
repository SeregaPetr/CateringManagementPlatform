using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        public string NameStatus { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }

    public enum StatusName
    {

    }
}