namespace CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.WaiterDtos
{
    public class WaiterReadDto : EmployeeDto
    {
        public int Id { get; set; }
        public int NumberTablesServed { get; set; }
        public string NameDepartment { get; set; }
    }
}
