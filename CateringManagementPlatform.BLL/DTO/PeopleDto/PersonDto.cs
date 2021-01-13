using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.PeopleDto
{
    public class PersonDto
    {
        //   public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Patronymic { get; set; }
    }
}
