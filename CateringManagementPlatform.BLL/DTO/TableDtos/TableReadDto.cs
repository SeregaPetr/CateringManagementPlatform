using System;

namespace CateringManagementPlatform.BLL.DTO.TableDtos
{
    public class TableReadDto
    {
        public int Id { get; set; }
        public int NumberTable { get; set; }
        public bool IsReservation { get; set; }
        public DateTime? DateReservation { get; set; }
        public int CapacityTable { get; set; }
        public int? NumberGuests { get; set; }
        public int? WaiterId { get; set; }
        public string FullNameWaiter { get; set; }
        public int? GuestId { get; set; }
        public string FullNameGuest { get; set; }
    }
}
