using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<DishCreateDto, Dish>();
            CreateMap<Dish, DishReadDto>()
                .ForMember("NameMenuCategory", opt => opt.MapFrom(d => d.MenuCategory.NameCategory))
                .ForMember("NameDepartment", opt => opt.MapFrom(d => d.Department.NameDepartment));
        }
    }
}
