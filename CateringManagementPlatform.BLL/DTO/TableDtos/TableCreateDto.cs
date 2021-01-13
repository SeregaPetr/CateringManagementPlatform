using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.TableDtos
{
    public class TableCreateDto
    {
        [Required]
        public int NumberTable { get; set; }
        [Required]
        public int CapacityTable { get; set; }
        [Required]
        public int WaiterId { get; set; }
    }
}
