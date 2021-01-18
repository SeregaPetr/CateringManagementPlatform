using System.Collections.Generic;

namespace CateringManagementPlatform.BLL.Order.DTO
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
