using AutoMapper;
using CateringManagementPlatform.BLL.Platform.DTO.TableInfoDtos;
using CateringManagementPlatform.DAL.Entities;


namespace CateringManagementPlatform.BLL.Platform.Profiles
{
    public class TableInfoProfile : Profile
    {
        public TableInfoProfile()
        {
            CreateMap<Table, TableInfoReadDto>()
                .ForMember("TableId", opt => opt.MapFrom(t => t.Id))
                .ForMember("AccountId", opt => opt.MapFrom(t => t.Account.Id))
                .ForMember("Email", opt => opt.MapFrom(t => t.Account.Email))
                .ForMember("Password", opt => opt.MapFrom(t => t.Account.Password));
        }
    }
}
