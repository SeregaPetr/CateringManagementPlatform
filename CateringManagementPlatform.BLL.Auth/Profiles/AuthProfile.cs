using AutoMapper;
using CateringManagementPlatform.BLL.Auth.DTO;
using CateringManagementPlatform.DAL.Entities.People;

namespace CateringManagementPlatform.BLL.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<Account, AccountReadDto>()
                .ForMember("Roles", opt => opt.MapFrom(a => a.UserRoles));
        }
    }
}
