using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos
{
    public class MenuUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public string NameMenu { get; set; }
    }
}
