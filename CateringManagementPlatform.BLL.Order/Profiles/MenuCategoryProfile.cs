using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.MenuCategoryDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Order.Profiles
{
    public class MenuCategoryProfile : Profile
    {
        public MenuCategoryProfile()
        {
            CreateMap<MenuCategory, MenuCategoryReadDto>();
        }
    }
}
