using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Order.Profiles
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<Dish, DishDto>();
        }
    }
}
