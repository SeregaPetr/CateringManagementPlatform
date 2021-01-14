using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.BLL.DTO.DishDtos
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
        public bool IsArchive { get; set; }
        [Required]
        public int MenuCategoryId { get; set; }
        public string NameMenuCategory { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string NameDepartment { get; set; }
    }
}
