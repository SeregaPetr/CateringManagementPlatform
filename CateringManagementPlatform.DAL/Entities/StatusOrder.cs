using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class StatusOrder
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameStatus { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public enum StatusNameOrder
    {
        Open = 1,      //счет открыт
        Closed,    //счет закрыт
    }
}