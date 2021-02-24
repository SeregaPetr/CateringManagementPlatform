using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DishDtos;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuCategoryDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class MenuCategoryProfile : Profile
    {
        public MenuCategoryProfile()
        {
    //CreateMap<MenuCategory, MenuCategoryReadDto>()
    //            .ForMember("Dishes", opt => opt.MapFrom(mc => mc.MenuCategoryMenus
    //            .Select(x => x.Dishes).ToList()));

        }
    }
}
