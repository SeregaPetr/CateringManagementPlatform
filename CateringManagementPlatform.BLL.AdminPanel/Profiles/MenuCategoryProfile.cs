using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class MenuCategoryProfile : Profile
    {
        public MenuCategoryProfile()
        {
            CreateMap<MenuCategory, MenuCategoryReadDto>();
            CreateMap<MenuCategoryCreateDto, MenuCategory>();
            CreateMap<MenuCategoryUpdateDto, MenuCategory>();
        }
    }
}
