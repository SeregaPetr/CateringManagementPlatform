using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string NameDepartment { get; set; }

        public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
        public ICollection<Waiter> Waiters { get; set; } = new List<Waiter>();
        public ICollection<Barman> Barmen { get; set; } = new List<Barman>();
        public ICollection<Chef> Chefs { get; set; } = new List<Chef>();
        public ICollection<Manager> Managers { get; set; } = new List<Manager>();
    }

    public enum DepartmentName
    {
        Bar = 1,
        Kitchen,
        Waiters,
        Managers
    }
}
