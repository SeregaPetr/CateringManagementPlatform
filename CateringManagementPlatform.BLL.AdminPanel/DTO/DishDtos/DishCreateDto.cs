using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos
{
    public class DishCreateDto
    {
        [Required]
        public string NameDish { get; set; }

        [Required]
        public string CompositionDish { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}
