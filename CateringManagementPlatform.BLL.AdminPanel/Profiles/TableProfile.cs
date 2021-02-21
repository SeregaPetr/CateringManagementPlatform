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
            CreateMap<Table, TableReadDto>();
        }
    }
}
