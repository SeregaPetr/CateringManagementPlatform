using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ManagerDtos;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<ManagerCreateDto, Manager>();
            CreateMap<ManagerUpdateDto, Manager>();
            CreateMap<Manager, ManagerReadDto>()
                .ForMember("NameDepartment", opt => opt.MapFrom(b => b.Department.NameDepartment));
        }
    }
}
