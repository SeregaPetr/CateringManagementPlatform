using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string NameMenu { get; set; }

        public ICollection<MenuCategory> MenuCategories { get; set; } = new List<MenuCategory>();
        public List<MenuCategoryMenu> MenuCategoryMenus { get; set; } = new List<MenuCategoryMenu>();
    }
}
