using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.MenuDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Order.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuReadDto>();
        }
    }
}
