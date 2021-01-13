using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.BarmanDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class BarmanService : IBarmanService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public BarmanService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(BarmanCreateDto barmanCreateDto)
        {
            if (barmanCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var barman = _mapper.Map<Barman>(barmanCreateDto);
            barman.DepartmentId = (int)DepartmentName.Bar;

            _repository.Barmen.Create(barman);
            await _repository.SaveAsync();

            return barman.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var barman = await _repository.Barmen.GetByIdAsync(id);
            if (barman == null)
            {
                throw new ValidationException("Бармен не найден", "");
            }
            _repository.Barmen.Delete(barman);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<BarmanReadDto>> GetAllAsync()
        {
            var barman = await _repository.Barmen.GetAllAsync();
            return _mapper.Map<IEnumerable<BarmanReadDto>>(barman);
        }

        public async Task<BarmanReadDto> GetByIdAsync(int id)
        {
            var barman = await _repository.Barmen.GetByIdAsync(id);
            if (barman == null)
            {
                throw new ValidationException("Бармен не найден", "");
            }
            return _mapper.Map<BarmanReadDto>(barman);
        }

        public async Task UpdateAsync(BarmanUpdateDto barmanUpdateDto)
        {
            var barman = await _repository.Barmen.GetByIdAsync(barmanUpdateDto.Id);
            if (barman == null)
            {
                throw new ValidationException("Бармен не найден", "");
            }
            barman = _mapper.Map<Barman>(barmanUpdateDto);
            barman.DepartmentId = (int)DepartmentName.Bar;

            _repository.Barmen.Update(barman);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
