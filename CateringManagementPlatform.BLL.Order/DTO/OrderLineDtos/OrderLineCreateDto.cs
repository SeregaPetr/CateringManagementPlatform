using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos
{
    public class OrderLineCreateDto
    {
        [Required]
        public int NumberPortions { get; set; }

        [Required]
        public int DishId { get; set; }
    }
}
