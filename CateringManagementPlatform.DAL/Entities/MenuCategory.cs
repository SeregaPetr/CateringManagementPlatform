using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class MenuCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameCategory { get; set; }

        public int? MenuId { get; set; }
        public Menu Menu { get; set; }
        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
