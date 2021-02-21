using System;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.TableDtos
{
    public class TableReadDto
    {
        public int Id { get; set; }
        public int NumberTable { get; set; }
        public bool IsReservation { get; set; }
        public int CapacityTable { get; set; }
        public int? NumberGuests { get; set; }
    }
}
