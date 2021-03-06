using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos
{
    public class MenuUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public string NameMenu { get; set; }

        public IEnumerable<MenuCategoryUpdateDto> MenuCategories { get; set; } = new List<MenuCategoryUpdateDto>();

    }
}
