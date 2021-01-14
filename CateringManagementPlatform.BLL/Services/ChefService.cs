using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CateringManagementPlatform.BLL.DTO.PeopleDto.EmployeesDto.ChefDtos;
using CateringManagementPlatform.BLL.Infrastructure;
using CateringManagementPlatform.BLL.Interfaces;
using CateringManagementPlatform.DAL.Entities;
using CateringManagementPlatform.DAL.Entities.People.Employees;
using CateringManagementPlatform.DAL.Interfaces;

namespace CateringManagementPlatform.BLL.Services
{
    public class ChefService : IChefService
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;

        public ChefService(IUnitOfWork repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> CreateAsync(ChefCreateDto chefCreateDto)
        {
            if (chefCreateDto == null)
            {
                throw new ValidationException("Введите данные", "");
            }
            var chef = _mapper.Map<Chef>(chefCreateDto);
            chef.DepartmentId = (int)DepartmentName.Kitchen;

            _repository.Chefs.Create(chef);
            await _repository.SaveAsync();

            return chef.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var chef = await _repository.Chefs.GetByIdAsync(id);
            if (chef == null)
            {
                throw new ValidationException("Повар не найден", "");
            }
            _repository.Chefs.Delete(chef);
            await _repository.SaveAsync();
        }

        public async Task<IEnumerable<ChefReadDto>> GetAllAsync()
        {
            var chef = await _repository.Chefs.GetAllAsync();
            return _mapper.Map<IEnumerable<ChefReadDto>>(chef);
        }

        public async Task<ChefReadDto> GetByIdAsync(int id)
        {
            var chef = await _repository.Chefs.GetByIdAsync(id);
            if (chef == null)
            {
                throw new ValidationException("Повар не найден", "");
            }
            return _mapper.Map<ChefReadDto>(chef);
        }

        public async Task UpdateAsync(ChefUpdateDto chefUpdateDto)
        {
            var chef = await _repository.Chefs.GetByIdAsync(chefUpdateDto.Id);
            if (chef == null)
            {
                throw new ValidationException("Повар не найден", "");
            }
            chef = _mapper.Map<Chef>(chefUpdateDto);
            chef.DepartmentId = (int)DepartmentName.Kitchen;

            _repository.Chefs.Update(chef);
            await _repository.SaveAsync();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
