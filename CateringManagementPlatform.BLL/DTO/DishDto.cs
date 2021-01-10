using System;
using System.Collections.Generic;
using System.Text;

namespace CateringManagementPlatform.BLL.DTO
{
  public class DishDto
    {
        public int Id { get; set; }
        public string NameDish { get; set; }
        public string CompositionDish { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }

        //public int? MenuCategoryId { get; set; }
        //public MenuCategory MenuCategory { get; set; }
        //public ICollection<OrderLine> OrderLines { get; set; }
    }
}
