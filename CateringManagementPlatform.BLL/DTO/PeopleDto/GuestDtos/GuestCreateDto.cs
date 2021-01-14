using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.PeopleDto.GuestDtos
{
    public class GuestCreateDto : PersonDto
    {
        [Required]
        public string Phone { get; set; }
    }
}
