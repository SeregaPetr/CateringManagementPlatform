using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.TableDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class TableProfile : Profile
    {
        public TableProfile()
        {
            CreateMap<TableCreateDto, Table>();
            CreateMap<TableUpdateDto, Table>();
            //CreateMap<Table, TableReadDto>()
            //    .ForMember("FullNameWaiter", opt => opt.MapFrom
            //    (t => t.Waiter.LastName + " " + t.Waiter.FirstName + " " + t.Waiter.Patronymic))
            //    .ForMember("FullNameGuest", opt => opt.MapFrom
            //    (t => t.Guest.LastName + " " + t.Guest.FirstName + " " + t.Guest.Patronymic));
        }
    }
}
