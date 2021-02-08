using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class OrderLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumberPortions { get; set; }

        public int? StatusOrderLineId { get; set; }
        public StatusOrderLine StatusOrderLine { get; set; }
        public int DishId { get; set; }
        public Dish Dish { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}