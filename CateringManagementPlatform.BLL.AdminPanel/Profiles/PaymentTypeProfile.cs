using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PaymentTypeDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentType, PaymentTypeReadDto>();
        }
    }
}
