namespace CateringManagementPlatform.DAL.Entities.People.Employees
{
    public class Employee : Person
    {
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
