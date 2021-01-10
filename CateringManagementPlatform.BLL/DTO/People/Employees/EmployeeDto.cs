namespace CateringManagementPlatform.BLL.DTO.People.Employees
{
    public class EmployeeDto : PersonDto
    {
        public int? DepartmentId { get; set; }
        public string NameDepartment { get; set; }
    }
}
