using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }

        public ICollection<MenuCategory> MenuCategories { get; set; }
    }
}
