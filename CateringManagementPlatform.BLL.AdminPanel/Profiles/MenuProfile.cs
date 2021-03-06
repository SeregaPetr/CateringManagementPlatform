using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.MenuDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuReadDto>();
            CreateMap<MenuUpdateDto, Menu>();
            CreateMap<MenuCreateDto, Menu>();
        }
    }
}
