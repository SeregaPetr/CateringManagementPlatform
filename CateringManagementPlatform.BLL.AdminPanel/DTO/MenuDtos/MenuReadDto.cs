using System.Collections.Generic;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos
{
    public class MenuReadDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string NameMenu { get; set; }
        public IEnumerable<MenuCategoryReadDto> MenuCategories { get; set; } = new List<MenuCategoryReadDto>();
    }
}
