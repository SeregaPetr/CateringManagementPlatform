﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class PaymentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NamePaymentType { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }

    public enum PaymentTypeName
    {
        cash = 1,     // наличные
        terminal    // терминал
    }
}
