using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.PeopleDto.GuestDtos
{
    public class GuestUpdateDto : PersonDto
    {
        public int Id { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}
