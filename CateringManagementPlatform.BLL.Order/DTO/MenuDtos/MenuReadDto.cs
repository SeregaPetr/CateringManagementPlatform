using System.Collections.Generic;
using CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.MenuDtos
{
    public class MenuReadDto
    {
        public string NameMenu { get; set; }
        public IEnumerable<MenuCategoryReadDto> MenuCategories { get; set; }

        public MenuReadDto()
        {
            MenuCategories = new List<MenuCategoryReadDto>();
        }
    }
}
