using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CateringManagementPlatform.DAL.Entities.People.Employees
{
    [Table("Managers")]
    public class Manager : Person
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
