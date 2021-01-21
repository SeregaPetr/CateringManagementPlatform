using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Table
    {
        [Key]
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
        public Waiter Waiter { get; set; }
        public int? Guestid { get; set; } //сделать связь многие ко многим
        public Guest Guest { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}