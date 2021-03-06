using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities
{
    public class MenuCategoryMenu
    {
       // public int Id { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        public int MenuCategoryId { get; set; }
        public MenuCategory MenuCategory { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
