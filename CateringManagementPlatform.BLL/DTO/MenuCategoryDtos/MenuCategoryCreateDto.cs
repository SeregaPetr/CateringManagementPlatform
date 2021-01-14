using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.MenuCategoryDtos
{
    public class MenuCategoryCreateDto
    {
        [Required]
        public string NameCategory { get; set; }
    }
}
