using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Dish
    {
        public int Id { get; set; }
        [Required]
        public string NameDish { get; set; }
        [Required]
        public  string CompositionDish { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public decimal Price { get; set; }
        public bool IsArchive { get; set; }

        public int? MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }
}