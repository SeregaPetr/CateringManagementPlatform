using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.DAL.Entities.People;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime CheckOpeningTime { get; set; }
        public DateTime? CheckClosingTime { get; set; }

        public int StatusOrderId { get; set; }
        public StatusOrder StatusOrder { get; set; }

        public int? TableId { get; set; }
        public Table Table { get; set; }

        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int WaiterId { get; set; }
        public Waiter Waiter { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}