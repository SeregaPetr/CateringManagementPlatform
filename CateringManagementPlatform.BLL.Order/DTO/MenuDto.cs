using System.Collections.Generic;

namespace CateringManagementPlatform.BLL.Order.DTO
{
    public class MenuDto
    {
        public IEnumerable<MenuCategoryDto> MenuCategories { get; set; }

        public MenuDto()
        {
            MenuCategories = new List<MenuCategoryDto>();
        }
    }
}
