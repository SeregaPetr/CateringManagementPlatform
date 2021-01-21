using System.Collections.Generic;
using CateringManagementPlatform.BLL.Order.DTO.DishDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos
{
    public class MenuCategoryDto
    {
        public string NameCategory { get; set; }
        public IEnumerable<DishDto> Dishes { get; set; }

        public MenuCategoryDto()
        {
            Dishes = new List<DishDto>();
        }
    }
}
