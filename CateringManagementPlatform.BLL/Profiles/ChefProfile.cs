using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ChefDtos;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.Profiles
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
