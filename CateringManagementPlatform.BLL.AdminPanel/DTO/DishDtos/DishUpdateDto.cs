using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos
{
    public class DishUpdateDto
    {
        public int Id { get; set; }

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
