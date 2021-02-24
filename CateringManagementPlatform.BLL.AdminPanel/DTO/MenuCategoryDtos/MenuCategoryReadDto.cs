using System.Collections.Generic;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos
{
    public class MenuCategoryReadDto
    {
        //   public int Id { get; set; }
        public string NameCategory { get; set; }
        public IEnumerable<DishReadDto> Dishes { get; set; } = new List<DishReadDto>();
    }
}
