using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public int NumberTable { get; set; }
        public bool IsReservation { get; set; } = false;
        public DateTime? DateReservation { get; set; }
        [Required]
        public int CapacityTable { get; set; }
        public int NumberGuests { get; set; } = 0;

        public int? WaiterId { get; set; }
        public Waiter Waiter { get; set; }
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}