using System.ComponentModel.DataAnnotations.Schema;

namespace CateringManagementPlatform.DAL.Entities.People.Employees
{
    [Table("Employees")]
    public class Employee : Person
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
