using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.DishDtos
{
    public class DishUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public bool IsArchive { get; set; }
    }
}
