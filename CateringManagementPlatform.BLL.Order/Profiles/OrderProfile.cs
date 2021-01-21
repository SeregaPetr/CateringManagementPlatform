using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;


namespace CateringManagementPlatform.BLL.Order.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<DAL.Entities.Order, OrderReadDto>()
                .ForMember("StatusOrder", opt => opt.MapFrom(o => o.Status.NameStatus))
                .ForMember("NumberTable", opt => opt.MapFrom(o => o.Table.NumberTable));
        }
    }
}

