using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.WaiterDtos;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class WaiteProfile : Profile
    {
        public WaiteProfile()
        {
            CreateMap<WaiterCreateDto, Waiter>();
            CreateMap<WaiterUpdateDto, Waiter>();
            CreateMap<Waiter, WaiterReadDto>()
                .ForMember("NameDepartment", opt => opt.MapFrom(b => b.Department.NameDepartment));
        }
    }
}
