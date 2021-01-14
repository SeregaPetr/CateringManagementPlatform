using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PaymentTypeDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.Profiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentType, PaymentTypeReadDto>();
        }
    }
}
