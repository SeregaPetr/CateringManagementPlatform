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
        public ICollection<OrderLineReadDto> OrderLines { get; set; }

        public OrderReadDto()
        {
            OrderLines = new List<OrderLineReadDto>();
        }
    }
}
