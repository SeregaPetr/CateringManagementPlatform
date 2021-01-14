using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.GuestDtos;
using CateringManagementPlatform.DAL.Entities.People;

namespace CateringManagementPlatform.BLL.Profiles
{
    public class GuestProfile : Profile
    {
        public GuestProfile()
        {
            CreateMap<GuestCreateDto, Guest>();
            CreateMap<GuestUpdateDto, Guest>();
            CreateMap<Guest, GuestReadDto>();
        }
    }
}
