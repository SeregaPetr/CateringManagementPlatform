using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.DepartmentDtos;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentReadDto>> GetAllAsync()
        {
            var departments = await _repository.Departments.GetAllAsync();
            return _mapper.Map<IEnumerable<DepartmentReadDto>>(departments);
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
