using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Platform.Profiles
{
    public class OrderLineProfile : Profile
    {
        public OrderLineProfile()
        {
            CreateMap<OrderLine, OrderLineReadDto>()
                .ForMember("NameStatus", opt => opt.MapFrom(o => o.StatusOrderLine.NameStatus))
                .ForMember("NameDish", opt => opt.MapFrom(o => o.Dish.NameDish))
                .ForMember("PriceDish", opt => opt.MapFrom(o => o.Dish.Price))
                .ForMember("CountPortions", opt => opt.MapFrom(o => o.CountPortions))
                .ForMember("NumberTable", opt => opt.MapFrom(o => o.Order.Table.NumberTable))
                .ForMember("FullNameWaiter", opt => opt.MapFrom(o => $"{ o.Order.Waiter.FirstName} {o.Order.Waiter.LastName}"));
        }
    }
}
