using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.People.Employees;
using CateringManagementPlatform.DAL.Entities.People.Employees;

namespace CateringManagementPlatform.BLL.Profiles
{
    public class BarmanProfile : Profile
    {
        public BarmanProfile()
        {
            CreateMap<Barman, BarmanDto>().ForMember("DepartmentId", opt => opt.MapFrom(b => b.Department.Id))
                .ForMember("NameDepartment", opt => opt.MapFrom(b => b.Department.NameDepartment));


            CreateMap<BarmanDto, Barman>();
           
        }
    }
}
