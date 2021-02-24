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

        public ICollection<Menu> Menus { get; set; } = new List<Menu>();
        public ICollection<MenuCategoryMenu> MenuCategoryMenus { get; set; } = new List<MenuCategoryMenu>();
    }
}

