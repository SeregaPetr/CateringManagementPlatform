using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.AdminPanel.DTO.PeopleDto.EmployeesDto.WaiterDtos;
using CateringManagementPlatform.BLL.AdminPanel.Infrastructure;
using CateringManagementPlatform.BLL.AdminPanel.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.AdminPanel.Services
{
    public class WaiterService : IWaiterService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public WaiterService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(WaiterCreateDto waiterCreateDto)
        {
            if (waiterCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var waiter = _mapper.Map<Waiter>(waiterCreateDto);
            waiter.DepartmentId = (int)DepartmentName.Waiters;

            _repository.Waiters.Create(waiter);
            await _repository.SaveAsync();

            return waiter.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var waiter = await _repository.Waiters.GetByIdAsync(id);
            if (waiter == null)
            {
                throw new ValidationException("Официант не найден", "");
            }
            _repository.Waiters.Delete(waiter);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<WaiterReadDto>> GetAllAsync()
        {
            var waiters = await _repository.Waiters.GetAllAsync();
            return _mapper.Map<IEnumerable<WaiterReadDto>>(waiters);
        }

        public async Task<WaiterReadDto> GetByIdAsync(int id)
        {
            var waiter = await _repository.Waiters.GetByIdAsync(id);
            if (waiter == null)
            {
                throw new ValidationException("Официант не найден", "");
            }
            return _mapper.Map<WaiterReadDto>(waiter);
        }

        public async Task UpdateAsync(WaiterUpdateDto waiterUpdateDto)
        {
            var waiter = await _repository.Waiters.GetByIdAsync(waiterUpdateDto.Id);
            if (waiter == null)
            {
                throw new ValidationException("Официант не найден", "");
            }
            waiter = _mapper.Map<Waiter>(waiterUpdateDto);
            waiter.DepartmentId = (int)DepartmentName.Waiters;

            _repository.Waiters.Update(waiter);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
