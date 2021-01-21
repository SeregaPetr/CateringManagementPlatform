using System.Collections.Generic;
using CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.MenuDtos
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
