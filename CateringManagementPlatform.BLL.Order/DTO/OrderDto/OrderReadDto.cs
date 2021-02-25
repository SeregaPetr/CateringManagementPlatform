using System;
using System.Collections.Generic;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderDto
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public DateTime CheckOpeningTime { get; set; }
        public string StatusOrder { get; set; }
        public int NumberTable { get; set; }
        public string AccountId { get; set; }
        public string NamePaymentType { get; set; }
        public string FirstNameWaiter { get; set; }
        public string LastNameWaiter { get; set; }

        public ICollection<OrderLineReadDto> OrderLines { get; set; } = new List<OrderLineReadDto>();
    }
}
