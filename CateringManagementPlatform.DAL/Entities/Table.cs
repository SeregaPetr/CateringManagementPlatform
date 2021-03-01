using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.DAL.Entities.People;
using Microsoft.EntityFrameworkCore;

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

        [Required]
        public bool IsArchive { get; set; }

        [Required]
        public int CapacityTable { get; set; }

        public int? NumberGuests { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public Account Account { get; set; }
    }
}