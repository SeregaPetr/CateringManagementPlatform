using System;
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

        public DateTime? DateReservation { get; set; }

        [Required]
        public int CapacityTable { get; set; }

        public int? NumberGuests { get; set; }

        public int? WaiterId { get; set; }

        public int? GuestId { get; set; }
    }
}
