using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderDto
{
    public class OrderCreateDto
    {
        [Required]
        public int NumberTable { get; set; }

        [Required]
        public int GuestId { get; set; }

        [Required]
        public int WaiterId { get; set; }

        public ICollection<OrderLineCreateDto> OrderLines { get; set; }

        public OrderCreateDto()
        {
            OrderLines = new List<OrderLineCreateDto>();
        }
    }
}
