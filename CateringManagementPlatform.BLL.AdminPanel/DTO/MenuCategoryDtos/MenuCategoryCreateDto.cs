using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos
{
    public class MenuCategoryCreateDto
    {
        [Required]
        public string NameCategory { get; set; }
    }
}
