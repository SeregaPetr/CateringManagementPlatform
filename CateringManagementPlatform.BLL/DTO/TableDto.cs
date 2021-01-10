using System;
using System.Collections.Generic;
using System.Text;

namespace CateringManagementPlatform.BLL.DTO
{
   public class TableDto
    {
        public int Id { get; set; }
        public int NumberTable { get; set; }
        public bool IsReservation { get; set; } = false;
        public DateTime? DateReservation { get; set; }
        public int CapacityTable { get; set; }
        public int NumberGuests { get; set; } = 0;

        //public int? WaiterId { get; set; }
        //public Waiter Waiter { get; set; }
        //public int? GuestId { get; set; }
        //public Guest Guest { get; set; }
        //public ICollection<Order> Orders { get; set; }
    }
}
