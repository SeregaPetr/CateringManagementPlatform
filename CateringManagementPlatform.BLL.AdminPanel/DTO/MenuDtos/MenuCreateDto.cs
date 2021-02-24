using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos
{
    public class MenuCreateDto
    {
        [Required]
        public string NameMenu { get; set; }
    }
}
