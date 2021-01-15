using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.ChefDtos;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class ChefProfile : Profile
    {
        public ChefProfile()
        {
            CreateMap<ChefCreateDto, Chef>();
            CreateMap<ChefUpdateDto, Chef>();
            CreateMap<Chef, ChefReadDto>()
                .ForMember("NameDepartment", opt => opt.MapFrom(b => b.Department.NameDepartment));
        }
    }
}
