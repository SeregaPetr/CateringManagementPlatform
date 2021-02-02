using System.Collections.Generic;
using CateringManagementPlatform.BLL.Order.DTO.DishDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos
{
    public class MenuCategoryReadDto
    {
        public string NameCategory { get; set; }
        public IEnumerable<DishReadDto> Dishes { get; set; }

        public MenuCategoryReadDto()
        {
            Dishes = new List<DishReadDto>();
        }
    }
}
