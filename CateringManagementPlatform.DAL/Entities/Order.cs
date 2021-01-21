using System;
using System.Collections.Generic;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OpeningTimeCheck { get; set; }
        public DateTime? СlosingЕimeСheck { get; set; }
        public string Comment { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public int? PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }

        public Order()
        {
            OrderLines = new List<OrderLine>();
        }
    }
}