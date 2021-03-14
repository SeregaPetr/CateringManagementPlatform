using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DepartmentDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishReadDto>()
                .ForMember("Department", opt => opt.MapFrom(d =>
                     new DepartmentReadDto { Id = d.Department.Id, NameDepartment = d.Department.NameDepartment }));
            CreateMap<DishCreateDto, Dish>();
            CreateMap<DishUpdateDto, Dish>();
        }
    }
}
