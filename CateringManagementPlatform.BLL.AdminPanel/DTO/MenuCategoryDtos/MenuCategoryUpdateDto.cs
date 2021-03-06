using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos
{
    public class MenuCategoryUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string NameCategory { get; set; }

        public IEnumerable<DishUpdateDto> Dishes { get; set; } = new List<DishUpdateDto>();

    }
}
