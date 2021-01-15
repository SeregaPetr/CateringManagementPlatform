using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.GuestDtos
{
    public class GuestCreateDto : PersonDto
    {
        [Required]
        public string Phone { get; set; }
    }
}
