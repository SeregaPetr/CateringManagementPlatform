using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CateringManagementPlatform.DAL.Entities
{
    public class MenuCategory
    {
        public int Id { get; set; }
        [Required]
        public string NameCategory { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Dish> Dishes { get; set; }
    }
}
