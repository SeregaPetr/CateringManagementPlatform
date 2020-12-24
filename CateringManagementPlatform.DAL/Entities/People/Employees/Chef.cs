using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CateringManagementPlatform.DAL.Entities.People.Employees
{
    [Table("Chefs")]
    public class Chef : Person
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
