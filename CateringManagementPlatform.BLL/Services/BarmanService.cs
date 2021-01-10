using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.People.Employees;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class BarmanService : IService<BarmanDto>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public BarmanService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(BarmanDto barmanDto)
        {
            if (barmanDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            barmanDto.Id = 0;

            var barman = _mapper.Map<Barman>(barmanDto);

            _repository.Barmen.Create(barman);
            await _repository.SaveAsync();

            barman = await _repository.Barmen.GetByIdAsync(barman.Id);

            barmanDto.Id = barman.Id;
            barmanDto.NameDepartment = barman.Department?.NameDepartment;
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

        public async Task<IEnumerable<BarmanDto>> GetAllAsync()
        {
            var barman = await _repository.Barmen.GetAllAsync();
            return _mapper.Map<IEnumerable<BarmanDto>>(barman);
        }

        public async Task<BarmanDto> GetByIdAsync(int id)
        {
            var barman = await _repository.Barmen.GetByIdAsync(id);
            if (barman == null)
            {
                throw new ValidationException("Бармен не найден", "");
            }
            return _mapper.Map<BarmanDto>(barman);
        }

        public async Task UpdateAsync(BarmanDto barmanDto)
        {
            var barman = await _repository.Barmen.GetByIdAsync(barmanDto.Id);
            if (barman == null)
            {
                throw new ValidationException("Бармен не найден", "");
            }
            barman = _mapper.Map<Barman>(barmanDto);

            _repository.Barmen.Update(barman);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
