﻿using AutoMapper;
using CateringManagementPlatform.BLL.Order.DTO.OrderDto;

namespace CateringManagementPlatform.BLL.Platform.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<DAL.Entities.Order, OrderReadDto>()
                .ForMember("StatusOrder", opt => opt.MapFrom(o => o.StatusOrder.NameStatus))
                .ForMember("NumberTable", opt => opt.MapFrom(o => o.Table.NumberTable))
                .ForMember("AccountId", opt => opt.MapFrom(o => o.Guest.AccountId.ToString()))
                .ForMember("NamePaymentType", opt => opt.MapFrom(o => o.PaymentType.NamePaymentType))
                .ForMember("FirstNameWaiter", opt => opt.MapFrom(o => o.Waiter.FirstName))
                .ForMember("LastNameWaiter", opt => opt.MapFrom(o => o.Waiter.LastName));
        }
    }
}
