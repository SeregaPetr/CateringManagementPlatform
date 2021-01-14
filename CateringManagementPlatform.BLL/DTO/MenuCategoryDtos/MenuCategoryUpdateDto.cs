using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.MenuCategoryDtos
{
    public class MenuCategoryUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string NameCategory { get; set; }
    }
}
