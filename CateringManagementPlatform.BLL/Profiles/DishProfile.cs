using AutoMapper;
using CateringManagementPlatform.BLL.DTO.DishDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<DishCreateDto, Dish>();
            CreateMap<Dish, DishReadDto>();
        }
    }
}
