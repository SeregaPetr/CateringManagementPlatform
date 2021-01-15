using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.BarmanDtos;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class BarmanProfile : Profile
    {
        public BarmanProfile()
        {
            CreateMap<BarmanCreateDto, Barman>();
            CreateMap<BarmanUpdateDto, Barman>();
            CreateMap<Barman, BarmanReadDto>()
                .ForMember("NameDepartment", opt => opt.MapFrom(b => b.Department.NameDepartment));
        }
    }
}
