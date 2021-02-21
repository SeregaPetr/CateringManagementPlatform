using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.TableDtos
{
    public class TableUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public int NumberTable { get; set; }

        [Required]
        public bool IsReservation { get; set; }

        [Required]
        public int CapacityTable { get; set; }

        public int? NumberGuests { get; set; }
    }
}
