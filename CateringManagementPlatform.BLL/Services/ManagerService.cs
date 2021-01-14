using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ManagerDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public ManagerService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ManagerCreateDto managerCreateDto)
        {
            if (managerCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var manager = _mapper.Map<Manager>(managerCreateDto);
            manager.DepartmentId = (int)DepartmentName.Managers;

            _repository.Managers.Create(manager);
            await _repository.SaveAsync();

            return manager.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var manager = await _repository.Managers.GetByIdAsync(id);
            if (manager == null)
            {
                throw new ValidationException("Менеджер не найден", "");
            }
            _repository.Managers.Delete(manager);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ManagerReadDto>> GetAllAsync()
        {
            var managers = await _repository.Managers.GetAllAsync();
            return _mapper.Map<IEnumerable<ManagerReadDto>>(managers);
        }

        public async Task<ManagerReadDto> GetByIdAsync(int id)
        {
            var manager = await _repository.Managers.GetByIdAsync(id);
            if (manager == null)
            {
                throw new ValidationException("Менеджер не найден", "");
            }
            return _mapper.Map<ManagerReadDto>(manager);
        }

        public async Task UpdateAsync(ManagerUpdateDto managerUpdateDto)
        {
            var manager = await _repository.Managers.GetByIdAsync(managerUpdateDto.Id);
            if (manager == null)
            {
                throw new ValidationException("Менеджер не найден", "");
            }
            manager = _mapper.Map<Manager>(managerUpdateDto);
            manager.DepartmentId = (int)DepartmentName.Managers;

            _repository.Managers.Update(manager);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
