using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DepartmentDtos;
using CateringManagementPlatform.DAL.Entities;

namespace CateringManagementPlatform.BLL.AdminPanel.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentReadDto>();
        }
    }
}
