using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderDto
{
    public class OrderCreateDto
    {
        [Required]
        public int NumberTable { get; set; }

       // public string Comment { get; set; }

        public ICollection<OrderLineCreateDto> OrderLines { get; set; }

        public OrderCreateDto()
        {
            OrderLines = new List<OrderLineCreateDto>();
        }
    }
}
