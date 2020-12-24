using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        public string NameDepartment { get; set; }

        public ICollection<MenuCategory> MenuCategories { get; set; }
        public ICollection<Waiter> Waiters { get; set; }
        public ICollection<Barman> Barmen { get; set; }
        public ICollection<Chef> Chefs { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }

}
