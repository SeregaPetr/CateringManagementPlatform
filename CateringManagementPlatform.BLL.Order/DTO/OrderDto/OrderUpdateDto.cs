using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderDto
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }

        [Required]
        public int NumberTable { get; set; }

        public ICollection<OrderLineCreateDto> OrderLines { get; set; }

        public OrderUpdateDto()
        {
            OrderLines = new List<OrderLineCreateDto>();
        }
    }
}
